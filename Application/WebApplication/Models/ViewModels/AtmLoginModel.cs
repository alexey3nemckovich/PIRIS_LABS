using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class AtmLoginModel
    {
        [Required]
        [StringLength(16)]
        public string CreditCardNumber { get; set; }

        [Required]
        [StringLength(4)]
        public string PinCode { get; set; }
    }
}