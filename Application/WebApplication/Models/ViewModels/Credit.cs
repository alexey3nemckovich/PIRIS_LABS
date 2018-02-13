using System;

namespace WebApplication.Models.ViewModels
{
    public class Credit
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public decimal CurrentPercentAmount { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardPin { get; set; }
        public bool IsCanPayPercentToday { get; set; }
        public bool IsCanCloseToday { get; set; }
        public Client Client { get; set; }
        public PlanOfCredit PlanOfCredit { get; set; }
    }
}
