using System;

namespace WebApplication.Models.ViewModels
{
    public class Deposit
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentPercentAmount { get; set; }
        public decimal PercentAmountForDay { get; set; }
        public bool IsCanWithdrawPercentsToday { get; set; }
        public bool IsCanCloseToday { get; set; }
        public Client Client { get; set; }
        public PlanOfDeposit PlanOfDeposit { get; set; }
    }
}
