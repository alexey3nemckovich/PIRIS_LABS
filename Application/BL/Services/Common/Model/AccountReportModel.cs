using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Account.Models;
using BL.Services.Credit.Models;
using BL.Services.Deposit.Models;

namespace BL.Services.Common.Model
{
    public class AccountReportModel
    {
        public AccountModel DevelopmentFundAccount { get; set; }
        public AccountModel CashdeskAccount { get; set; }
        public IEnumerable<DepositModel> Deposits { get; set; }
        public IEnumerable<CreditModel> Credits { get; set; }
    }
}
