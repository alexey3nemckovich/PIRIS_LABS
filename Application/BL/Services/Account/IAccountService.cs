using System.Collections.Generic;
using BL.Services.Account.Models;
using BL.Services.Client.Models;
using BL.Services.Credit.Models;
using BL.Services.Deposit.Models;

namespace BL.Services.Account
{
    public interface IAccountService
    {
        AccountModel Create(AccountModel account, ClientModel client);
        IEnumerable<AccountModel> GetAll();

        ORMLibrary.Deposit CreateAccountsForDeposit(ORMLibrary.Deposit deposit);
        ORMLibrary.Credit CreateAccountsForCredit(ORMLibrary.Credit credit);
        ORMLibrary.Account GetCashDeskAccount();
        ORMLibrary.Account GetDevelopmentFundAccount();
    }
}
