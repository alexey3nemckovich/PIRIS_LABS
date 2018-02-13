using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models.ViewModels
{
    public class PlanOfDeposit
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Deposit plan name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Period")]
        public int BankDayPeriod { get; set; }

        [Required]
        [Display(Name = "Percent a year")]
        public double Percent { get; set; }

        public bool Revocable { get; set; }

        [HiddenInput]
        public decimal? MinAmount { get; set; }
    }
}