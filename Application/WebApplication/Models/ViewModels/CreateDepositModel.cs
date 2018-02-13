using System.Collections.Generic;

namespace WebApplication.Models.ViewModels
{
    public class CreateDepositModel
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int ClientId { get; set; }
        public decimal Amount { get; set; }

        public IEnumerable<PlanOfDeposit> DepositPlans { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}
