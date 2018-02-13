using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Account.Models;

namespace BL.Services.Transaction.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDay { get; set; }
        public virtual AccountModel DebetAccount { get; set; }
        public virtual AccountModel CreditAccount { get; set; }
    }
}
