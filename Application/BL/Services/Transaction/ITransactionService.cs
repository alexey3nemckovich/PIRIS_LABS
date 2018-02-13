using System.Collections.Generic;
using BL.Services.Transaction.Models;

namespace BL.Services.Transaction
{
    public interface ITransactionService
    {
        void CommitTransaction(int debitAccountId, int creditAccountId, decimal amount);
        void CommitTransaction(ORMLibrary.Account debitAccount, ORMLibrary.Account creditAccount, decimal amount);
        void CommitCashDeskDebitTransaction(decimal amount);
        void WithDrawCashDeskTransaction(decimal amount);
        IEnumerable<TransactionModel> GetAll();
        IEnumerable<TransactionModel> GetAll(int accountId);
        IEnumerable<TransactionModel> GetAllByDay(int bankDayNumber);
    }
}
