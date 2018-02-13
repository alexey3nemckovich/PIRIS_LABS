using System;
using BL.Services.Account.Models;
using BL.Services.Client.Models;

namespace BL.Services.Credit.Models
{
    public class CreditModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
        public int MainAccountId { get; set; }
        public int PercentAccountId { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardPin { get; set; }
        public virtual AccountModel MainAccount { get; set; }
        public virtual AccountModel PercentAccount { get; set; }
        public virtual ClientModel Client { get; set; }
        public virtual PlanOfCreditModel PlanOfCredit { get; set; }
    }
}
