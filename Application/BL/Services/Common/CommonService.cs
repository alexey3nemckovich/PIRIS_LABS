using System;
using System.Linq;

namespace BL.Services.Common
{
    public class CommonService : BaseService, ICommonService
    {

        static CommonService()
        {
            int startDate = 0;
            try
            {
                startDate = Context.Transactions?.Max(e => e.TransactionDay) ?? 0;
            }
            catch
            {
                
            }
            currentBankDay =  startDate;
        }

        public static int currentBankDay;
        public static DateTime startDate = DateTime.Now;

        public int MonthLength { get; } = 30;

        public int YearLength { get; } = 365;

        public int StartBankDay { get; } = 0;

        public int CurrentBankDay => currentBankDay;

        public DateTime StartDate => startDate;

        public void IncreaseCurrentBankDay()
        {
            currentBankDay++;
        }
    }
}
