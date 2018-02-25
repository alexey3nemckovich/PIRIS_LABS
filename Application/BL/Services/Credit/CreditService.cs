using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Account;
using BL.Services.Common;
using BL.Services.Credit.Models;
using BL.Services.Transaction;
using AppContext = ORMLibrary.AppContext;
using AutoMapper;
using BL.Services.Common.Model;
using Microsoft.Practices.Unity;

namespace BL.Services.Credit
{
    public class CreditService : BaseService, ICreditService
    {
        [Dependency]
        public IPlanOfAccountService PlanOfAccountService { get; set; }

        [Dependency]
        public IAccountService AccountService { get; set; }

        [Dependency]
        public ISystemInformationService SystemInformationService { get; set; }

        [Dependency]
        public ITransactionService TransactionService { get; set; }

        public CreditService() : base()
        {
        }

        public void Create(CreditModel credit, bool isCardNeeded)
        {
            if (credit.Amount == 0)
            {
                throw new ServiceException("Amount cannot be zero.");
            }

            var dbCredit = Mapper.Map<CreditModel, ORMLibrary.Credit>(credit);

            dbCredit.PlanOfCredit = Context.PlanOfCredits.FirstOrDefault(e => e.Id == credit.PlanId);
            dbCredit.Client = Context.Clients.FirstOrDefault(e => e.Id == credit.ClientId);
            AccountService.CreateAccountsForCredit(dbCredit);
            dbCredit.StartDate = SystemInformationService.CurrentBankDay;
            dbCredit.EndDate = dbCredit.StartDate.AddMonths(dbCredit.PlanOfCredit.MonthPeriod);
            dbCredit.Amount = credit.Amount;

            if (isCardNeeded)
            {
                InitializeCredidCardCredentials(dbCredit);
            }

            Context.Credits.Add(dbCredit);
            Context.SaveChanges();

            TakeMoneyForCredit(dbCredit);
            if (!isCardNeeded)
            {
                WithDrawCreditFromCashDesk(dbCredit);
            }
            Context.SaveChanges();
        }

        private void InitializeCredidCardCredentials(ORMLibrary.Credit credit)
        {
            Random random = new Random();
            credit.CreditCardNumber = credit.MainAccount.AccountNumber + random.Next(0, 1000).ToString("000");
            credit.CreditCardPin = random.Next(0, 10000).ToString("0000");
        }

        public CreditModel Get(int id)
        {
            var credit = Context.Credits.FirstOrDefault(e => e.Id == id);
            return Mapper.Map<ORMLibrary.Credit, CreditModel>(credit);
        }

        public IEnumerable<CreditModel> GetAll()
        {
            var credits = Context.Credits.ToArray();
            var openedCredits = credits.Where(e => e.Amount != 0);
            var closedCredits = credits.Where(e => e.Amount == 0);
            return openedCredits.Concat(closedCredits).Select(Mapper.Map<ORMLibrary.Credit, CreditModel>);
        }

        public PlanOfPaymentModel GetPaymentSchedule(int creditId)
        {
            var credit = Context.Credits.FirstOrDefault(e => e.Id == creditId);

            PlanOfPaymentModel result = new PlanOfPaymentModel();

            result.CreditId = credit.Id;
            result.CurrentDay = SystemInformationService.CurrentBankDay;
            result.PaymentSchedule = new Dictionary<DateTime, double>();

            int countMonthes = credit.PlanOfCredit.MonthPeriod;
            double percentPerMonth = credit.PlanOfCredit.Percent / SystemInformationService.CountMonthesInYear;

            if (credit.PlanOfCredit.Anuity)
            {
                double anuityCoefficient =
                    (percentPerMonth * Math.Pow(1 + percentPerMonth, countMonthes)) /
                    (Math.Pow(1 + percentPerMonth, countMonthes) - 1);

                double paymentPerMonth = anuityCoefficient * (double)credit.Amount;

                DateTime paymentDate = credit.StartDate.AddMonths(1);
                for (int i = 0; i < countMonthes; i++)
                {
                    result.PaymentSchedule.Add(paymentDate, paymentPerMonth);

                    paymentDate = paymentDate.AddMonths(1);
                }
            }
            else
            {
                double creditRest = (double)credit.Amount;
                double monthlyReturningCreditBodyPart = (double)credit.Amount / countMonthes;

                DateTime paymentDate = credit.StartDate.AddMonths(1);
                for (int i = 0; i < countMonthes; i++)
                {
                    double thisMonthPayment = monthlyReturningCreditBodyPart + creditRest * percentPerMonth;
                    result.PaymentSchedule.Add(paymentDate, thisMonthPayment);

                    creditRest -= monthlyReturningCreditBodyPart;
                    paymentDate = paymentDate.AddMonths(1);
                }
            }

            return result;
        }

        public void CloseBankDay()
        {
            var credits =
                Context.Credits.Where(
                    e =>
                        e.StartDate <= SystemInformationService.CurrentBankDay && e.EndDate >= SystemInformationService.CurrentBankDay &&
                        e.Amount > 0).ToArray();
            foreach (var credit in credits)
            {
                CommitPercents(credit);
            }
        }

        private void CommitPercents(ORMLibrary.Credit credit)
        {
            decimal percentAmount;
            int countMonthes = credit.PlanOfCredit.MonthPeriod;
            double percentPerMonth = credit.PlanOfCredit.Percent / SystemInformationService.CountMonthesInYear;

            if (credit.PlanOfCredit.Anuity)
            {
                double anuityCoefficient =
                    (percentPerMonth * Math.Pow(1 + percentPerMonth, countMonthes)) /
                    (Math.Pow(1 + percentPerMonth, countMonthes) - 1);

                double paymentPerMonth = anuityCoefficient * (double)credit.Amount;

                percentAmount = (decimal)paymentPerMonth / SystemInformationService.CountDaysInMonth;
            }
            else
            {
                double creditRest = (double)credit.Amount;
                double dayReturningCreditBodyPart = (double)credit.Amount / countMonthes / SystemInformationService.CountDaysInMonth;
                double percentPerDay = percentPerMonth / SystemInformationService.CountDaysInMonth;

                for (int i = 0; i < (SystemInformationService.CurrentBankDay - credit.StartDate).TotalDays; i++)
                {
                    double thisDayPayment = dayReturningCreditBodyPart + creditRest * percentPerDay;
                    creditRest -= dayReturningCreditBodyPart;
                }

                percentAmount = (decimal)(dayReturningCreditBodyPart + creditRest * percentPerDay);
            }

            TransactionService.CommitTransaction(
                credit.PercentAccount, 
                AccountService.GetDevelopmentFundAccount(),
                percentAmount
            );
        }

        public void CloseCredit(int id)
        {
            var credit = Context.Credits.FirstOrDefault(e => e.Id == id);

            if (credit.EndDate > SystemInformationService.CurrentBankDay)
            {
                throw new SystemException("Cannot close credit before credit term ended.");
            }

            if (credit.Amount == 0)
            {
                throw new SystemException("Credit already have been closed.");
            }

            if (!credit.PlanOfCredit.Anuity)
            {
                TransactionService.CommitCashDeskDebitTransaction(
                    credit.Amount
                );

                TransactionService.CommitTransaction(
                    AccountService.GetCashDeskAccount(), 
                    credit.MainAccount,
                    credit.Amount
                );

                TransactionService.CommitTransaction(
                    credit.MainAccount, 
                    AccountService.GetDevelopmentFundAccount(),
                    credit.Amount
                );
            }

            TransactionService.CommitCashDeskDebitTransaction(credit.PercentAccount.Balance);

            TransactionService.CommitTransaction(
                AccountService.GetCashDeskAccount(),
                credit.PercentAccount,
                credit.PercentAccount.Balance
            );

            credit.Amount = 0;

            Context.SaveChanges();
        }

        public void PayPercents(int id)
        {
            var credit = Context.Credits.FirstOrDefault(e => e.Id == id);

            if (credit.Amount == 0)
            {
                throw new ServiceException("Cannot pay percents for closed credit.");
            }

            var amount = Math.Abs(credit.PercentAccount.Balance);

            TransactionService.WithDrawCashDeskTransaction(amount);

            TransactionService.CommitTransaction(
                AccountService.GetCashDeskAccount(), 
                credit.PercentAccount, 
                amount
            );
        }

        private void TakeMoneyForCredit(ORMLibrary.Credit dbCredit)
        {
            TransactionService.CommitTransaction(
                AccountService.GetDevelopmentFundAccount(), 
                dbCredit.MainAccount,
                dbCredit.Amount
            );           
        }

        private void WithDrawCreditFromCashDesk(ORMLibrary.Credit dbCredit)
        {
            TransactionService.CommitTransaction(
                dbCredit.MainAccount, 
                AccountService.GetCashDeskAccount(),
                dbCredit.Amount
            );
            TransactionService.WithDrawCashDeskTransaction(dbCredit.Amount);
        }
    }
}
