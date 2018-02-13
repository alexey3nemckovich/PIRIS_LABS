using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class PlanOfPayment
    {
        public int CreditId { get; set; }
        public DateTime CurrentDay { get; set; }
        public IDictionary<DateTime, decimal> PaymentSchedule { get; set; }
    }
}
