using System.Collections.Generic;
using BL.Services.Transaction.Models;

namespace BL.Services.Account.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public string AccountNumber { get; set; }
        public decimal DebitValue { get; set; }
        public decimal CreditValue { get; set; }
        public decimal Balance { get; set; }
        public virtual PlanOfAccountModel PlanOfAccount { get; set; }
        public virtual ICollection<TransactionModel> DebitTransactions { get; set; }
        public virtual ICollection<TransactionModel> CreditTransactions { get; set; }
    }
}
