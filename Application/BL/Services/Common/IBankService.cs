using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Common.Model;

namespace BL.Services.Common
{
    public interface IBankService
    {
        AccountReportModel GenerateAccountReport();
        TransactionReportModel GenerateTransactionReport(int day);
        void CloseBankDay();
        void CloseBankMonth();
        void CloseBankYear();
    }
}
