using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Deposit.Models;

namespace BL.Services.Deposit
{
    public interface IPlanOfDepositService
    {
        void Create(PlanOfDepositModel plan);
        IEnumerable<PlanOfDepositModel> GetAll();
    }
}
