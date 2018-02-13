using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models.ViewModels
{
    public class PlanOfCredit
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Credit name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Period")]
        public int BankDayPeriod { get; set; }

        [Required]
        [Display(Name = "Percent a year")]
        public double Percent { get; set; }

        public bool Anuity { get; set; }

        [HiddenInput]
        public decimal? MinAmount { get; set; }
    }
}