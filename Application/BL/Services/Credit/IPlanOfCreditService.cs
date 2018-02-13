using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Credit.Models;

namespace BL.Services.Credit
{
    public interface IPlanOfCreditService
    {
        void Create(PlanOfCreditModel plan);
        IEnumerable<PlanOfCreditModel> GetAll();
    }
}
