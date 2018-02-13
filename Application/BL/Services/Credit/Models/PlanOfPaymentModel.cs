using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Credit.Models
{
    public class PlanOfPaymentModel
    {
        public int CreditId { get; set; }
        public DateTime CurrentDay { get; set; }
        public IDictionary<DateTime, double> PaymentSchedule { get; set; }
    }
}
