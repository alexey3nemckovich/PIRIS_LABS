﻿using System;

namespace BL.Services.Common
{
    public interface ISystemInformationService
    {
        int CountDaysInMonth { get; }
        int CountDaysInYear { get; }

        void IncreaseCurrentBankDay();
        DateTime CurrentBankDay { get; }
    }
}
