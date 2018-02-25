using System;
using System.Collections.Generic;
using System.Linq;
using BL.Services.Account;
using BL.Services.Common;
using BL.Services.Common.Model;
using BL.Services.Deposit.Models;
using BL.Services.Transaction;
using Microsoft.Practices.Unity;

namespace BL.Services.Deposit
{
    public class DepositService : BaseService, IDepositService
    {
        [Dependency]
        public IPlanOfAccountService PlanOfAccountService { get; set; }

        [Dependency]
        public IAccountService AccountService { get; set; }

        [Dependency]
        public ISystemInformationService SystemInformationService { get; set; }

        [Dependency]
        public ITransactionService TransactionService { get; set; }

        public DepositService() : base()
        {
        }

        public void Create(DepositModel deposit)
        {
            if (deposit.Amount == 0)
            {
                throw new ServiceException("Amount cannot be zero.");
            }

            var dbDeposit = Mapper.Map<DepositModel, ORMLibrary.Deposit>(deposit);

            dbDeposit.PlanOfDeposit = Context.PlanOfDeposits.FirstOrDefault(e => e.Id == deposit.PlanId);
            dbDeposit.Client = Context.Clients.FirstOrDefault(e => e.Id == deposit.ClientId);
            AccountService.CreateAccountsForDeposit(dbDeposit);
            dbDeposit.StartDate = SystemInformationService.CurrentBankDay;
            dbDeposit.EndDate = dbDeposit.StartDate.AddDays(dbDeposit.PlanOfDeposit.DayPeriod);
            dbDeposit.Amount = deposit.Amount;

            Context.Deposits.Add(dbDeposit);
            Context.SaveChanges();

            HoldMoneyOnDeposit(dbDeposit);
            Context.SaveChanges();
        }

        public DepositModel Get(int id)
        {
            var deposit = Context.Deposits.FirstOrDefault(e => e.Id == id);
            return Mapper.Map<ORMLibrary.Deposit, DepositModel>(deposit);
        }

        public IEnumerable<DepositModel> GetAll()
        {
            var deposits = Context.Deposits.ToArray();
            var openedDeposits = deposits.Where(e => e.Amount != 0);
            var closedDeposits = deposits.Where(e => e.Amount == 0);
            return openedDeposits.Concat(closedDeposits).Select(Mapper.Map<ORMLibrary.Deposit, DepositModel>);
        }

        public void CloseBankDay()
        {
            var deposits =
                Context.Deposits.Where(
                    e => SystemInformationService.CurrentBankDay >= e.StartDate && 
                         SystemInformationService.CurrentBankDay <= e.EndDate &&
                         e.Amount > 0
                ).ToArray();

            foreach (var deposit in deposits)
            {
                CommitPercents(deposit);
            }
        }

        private void CommitPercents(ORMLibrary.Deposit deposit)
        {
            decimal percentAmount = deposit.Amount*(decimal) (deposit.PlanOfDeposit.Percent/100/SystemInformationService.CountDaysInYear);

            TransactionService.CommitTransaction(
                AccountService.GetDevelopmentFundAccount(), 
                deposit.PercentAccount,
                percentAmount
            );
        }

        public void WithdrawPercents(int id)
        {
            var deposit = Context.Deposits.FirstOrDefault(e => e.Id == id);

            if (deposit.PlanOfDeposit.Revocable)
            {
                throw new ServiceException("Cannot withdraw percents before deposit program ended.");
            }

            if ((SystemInformationService.CurrentBankDay - deposit.StartDate).TotalDays % SystemInformationService.CountDaysInMonth != 0)
            {
                throw new ServiceException("Cannot withdraw percents before month ended.");
            }

            var percentAmount = deposit.PercentAccount.Balance;

            TransactionService.CommitTransaction(
                deposit.PercentAccount, 
                AccountService.GetCashDeskAccount(),
                percentAmount
            );

            TransactionService.WithDrawCashDeskTransaction(percentAmount);

            Context.SaveChanges();
        }

        public void CloseDeposit(int id)
        {
            var deposit = Context.Deposits.FirstOrDefault(e => e.Id == id);

            if (!deposit.PlanOfDeposit.Revocable && deposit.EndDate > SystemInformationService.CurrentBankDay)
            {
                throw new SystemException("Cannot close deposit before deposit term ended.");
            }

            if (deposit.Amount == 0)
            {
                throw new SystemException("Deposit already have been closed.");
            }

            TransactionService.CommitTransaction(
                AccountService.GetDevelopmentFundAccount(), 
                deposit.MainAccount,
                deposit.Amount
            );

            TransactionService.CommitTransaction(
                deposit.MainAccount, 
                AccountService.GetCashDeskAccount(),
                deposit.Amount
            );

            var percentBalance = deposit.PercentAccount.Balance;

            TransactionService.CommitTransaction(
                deposit.PercentAccount, 
                AccountService.GetCashDeskAccount(),
                percentBalance
            );

            TransactionService.WithDrawCashDeskTransaction(deposit.MainAccount.CreditValue + percentBalance);

            deposit.Amount = 0;

            Context.SaveChanges();
        }

        private void HoldMoneyOnDeposit(ORMLibrary.Deposit deposit)
        {
            TransactionService.CommitCashDeskDebitTransaction(deposit.Amount);

            TransactionService.CommitTransaction(
                AccountService.GetCashDeskAccount(), 
                deposit.MainAccount,
                deposit.Amount
            );

            TransactionService.CommitTransaction(
                deposit.MainAccount,
                AccountService.GetDevelopmentFundAccount(),
                deposit.Amount
            );
        }
    }
}
