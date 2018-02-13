using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Account;
using BL.Services.Account.Models;
using BL.Services.Common.Model;
using BL.Services.Credit;
using BL.Services.Deposit;
using BL.Services.Transaction;
using Microsoft.Practices.Unity;
using AppContext = ORMLibrary.AppContext;

namespace BL.Services.Common
{
    public class BankService : BaseService, IBankService
    {
        [Dependency]
        public IAccountService AccountService { get; set; }
        [Dependency]
        public ICreditService CreditService { get; set; }

        [Dependency]
        public IDepositService DepositService { get; set; }

        [Dependency]
        public ITransactionService TransactionService { get; set; }

        [Dependency]
        public ISystemInformationService SystemInformationService { get; set; }

        public BankService() : base()
        {
        }

        private void CloseBankDayWork()
        {
            DepositService.CloseBankDay();
            CreditService.CloseBankDay();
            SystemInformationService.IncreaseCurrentBankDay();
        }

        public AccountReportModel GenerateAccountReport()
        {
            AccountReportModel result = new AccountReportModel();
            {
                result.DevelopmentFundAccount =
                    Mapper.Map<ORMLibrary.Account, AccountModel>(AccountService.GetDevelopmentFundAccount());
                result.CashdeskAccount =
                    Mapper.Map<ORMLibrary.Account, AccountModel>(AccountService.GetCashDeskAccount());
                result.Credits = CreditService.GetAll();
                result.Deposits = DepositService.GetAll();
            }
            return result;
        }

        public TransactionReportModel GenerateTransactionReport(int day)
        {
            TransactionReportModel result = new TransactionReportModel();
            result.Transactions = TransactionService.GetAllByDay(day);
            return result;
        }

        public void CloseBankDay()
        {
            CloseBankDayWork();
            Context.SaveChanges();
        }

        public void CloseBankMonth()
        {
            for (int i = 0; i < SystemInformationService.CountDaysInMonth; i++)
            {
                CloseBankDayWork();
            }
            Context.SaveChanges();
        }

        public void CloseBankYear()
        {
            for (int i = 0; i < SystemInformationService.CountDaysInYear; i++)
            {
                CloseBankDayWork();
            }
            Context.SaveChanges();
        }     
    }
}
