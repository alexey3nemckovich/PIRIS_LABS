using System;
using System.Linq;

namespace BL.Services.Common
{
    public class SystemInformationService : BaseService, ISystemInformationService
    {

        public int CountDaysInMonth { get; } = 30;

        public int CountDaysInYear { get; } = 365;

        public int CountMonthesInYear { get; } = 12;

        public DateTime CurrentBankDay
        {
            get
            {
                if(null == Context.SystemInformations.FirstOrDefault())
                {
                    Context.SystemInformations.Add(new ORMLibrary.SystemInformation(DateTime.Now));
                    Context.SaveChanges();
                }

                return Context.SystemInformations.First().CurrentBankDate;
            }
        }

        public void IncreaseCurrentBankDay()
        {
            var systemInformation = Context.SystemInformations.FirstOrDefault();
            systemInformation.CurrentBankDate = systemInformation.CurrentBankDate.AddDays(1);
            Context.SaveChanges();
        }

    }
}
