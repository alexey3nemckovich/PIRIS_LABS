using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Common
{
    public interface ICommonService
    {
        void IncreaseCurrentBankDay();
        int MonthLength { get; }
        int YearLength { get; }
        int StartBankDay { get; }
        int CurrentBankDay { get; }
        DateTime StartDate { get; }
    }
}
