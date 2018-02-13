using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class CreateCreditModel
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int ClientId { get; set; }
        public decimal Amount { get; set; }
        public bool CreateCreditCard { get; set; }
        public IEnumerable<PlanOfCredit> CreditPlans { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}