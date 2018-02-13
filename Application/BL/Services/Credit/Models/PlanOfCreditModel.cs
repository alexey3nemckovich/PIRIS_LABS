using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Account.Models;

namespace BL.Services.Credit.Models
{
    public class PlanOfCreditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MonthPeriod { get; set; }
        public double Percent { get; set; }
        public bool Anuity { get; set; }
        public decimal? MinAmount { get; set; }
        public int MainAccountPlanId { get; set; }
        public int PercentAccountPlanId { get; set; }
        public virtual PlanOfAccountModel MainPlanOfAccount { get; set; }
        public virtual PlanOfAccountModel PercentPlanOfAccount { get; set; }
    }
}
