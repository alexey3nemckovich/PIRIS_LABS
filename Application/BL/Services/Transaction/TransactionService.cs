using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using BL.Services.Account;
using BL.Services.Account.Models;
using BL.Services.Common;
using BL.Services.Transaction.Models;
using Microsoft.Practices.Unity;
using AppContext = ORMLibrary.AppContext;
using ORMLibrary;

namespace BL.Services.Transaction
{
    public class TransactionService : BaseService, ITransactionService
    {
        [Dependency]
        public IAccountService AccountService { get; set; }
        [Dependency]
        public ISystemInformationService SystemInformationService { get; set; }

        public TransactionService() : base()
        {
        }

        public void CommitCashDeskDebitTransaction(decimal amount)
        {
            var account = AccountService.GetCashDeskAccount();
            account.DebitValue += amount;
            account.Balance = account.DebitValue - account.CreditValue;
        }

        public void WithDrawCashDeskTransaction(decimal amount)
        {
            var account = AccountService.GetCashDeskAccount();
            account.CreditValue += amount;
            account.Balance = account.DebitValue - account.CreditValue;
        }

        public void CommitTransaction(int debitAccountId, int creditAccountId, decimal amount)
        {
            var debitAccount = Context.Accounts.FirstOrDefault(e => e.Id == debitAccountId);
            var creditAccount = Context.Accounts.FirstOrDefault(e => e.Id == creditAccountId);

            if (debitAccount == null || creditAccount == null)
                throw new AccountNotFoundException("One of transaction account was not found.");

            CommitTransaction(debitAccount, creditAccount, amount);
        }

        public void CommitTransaction(ORMLibrary.Account debitAccount, ORMLibrary.Account creditAccount, decimal amount)
        {
            if (debitAccount.PlanOfAccount.AccountType == "P")
            {
                debitAccount.DebitValue += amount;
                debitAccount.Balance = debitAccount.CreditValue - debitAccount.DebitValue;
            }
            else
            {
                debitAccount.CreditValue += amount;
                debitAccount.Balance = debitAccount.DebitValue - debitAccount.CreditValue;
            }

            if (creditAccount.PlanOfAccount.AccountType == "P")
            {
                creditAccount.CreditValue += amount;
                creditAccount.Balance = creditAccount.CreditValue - creditAccount.DebitValue;
            }
            else
            {
                creditAccount.DebitValue += amount;
                creditAccount.Balance = creditAccount.DebitValue - creditAccount.CreditValue;
            }

            ORMLibrary.Transaction trs = new ORMLibrary.Transaction()
            {
                DebetAccountId = debitAccount.Id,
                CreditAccountId = creditAccount.Id,
                Amount = amount,
                TransactionDay = SystemInformationService.CurrentBankDay
            };

            Context.Transactions.Add(trs);
        }

        public IEnumerable<TransactionModel> GetAll()
        {
            return
                Context.Transactions.ToArray()
                    .Select(Mapper.Map<ORMLibrary.Transaction, TransactionModel>);
        }

        public IEnumerable<TransactionModel> GetAll(int accountId)
        {
            return
                Context.Transactions.ToArray()
                    .Where(e => e.DebetAccountId == accountId || e.CreditAccountId == accountId).ToArray()
                    .Select(Mapper.Map<ORMLibrary.Transaction, TransactionModel>);
        }

        public IEnumerable<TransactionModel> GetAllByDay(int bankDayNumber)
        {
            return Context.Transactions.ToArray().Reverse().Select(Mapper.Map<ORMLibrary.Transaction, TransactionModel>);
        }
    }
}
