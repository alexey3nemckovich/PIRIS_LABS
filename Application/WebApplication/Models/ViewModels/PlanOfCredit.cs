using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.ViewModels
{
    public class PlanOfCredit
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Time period(in monthes)")]
        public int MonthPeriod { get; set; }

        [Required]
        [Display(Name = "Percent a year")]
        public double Percent { get; set; }

        public bool Anuity { get; set; }

        [HiddenInput]
        public decimal? MinAmount { get; set; }
    }
}
