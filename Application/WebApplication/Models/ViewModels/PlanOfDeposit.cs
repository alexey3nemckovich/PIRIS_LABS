using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.ViewModels
{
    public class PlanOfDeposit
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Time period(in days)")]
        public int DayPeriod { get; set; }

        [Required]
        [Display(Name = "Percent a year")]
        public double Percent { get; set; }

        public bool Revocable { get; set; }

        [HiddenInput]
        public decimal? MinAmount { get; set; }
    }
}
