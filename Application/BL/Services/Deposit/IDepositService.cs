using System.Collections.Generic;
using BL.Services.Deposit.Models;

namespace BL.Services.Deposit
{
    public interface IDepositService
    {
        void Create(DepositModel deposit);
        DepositModel Get(int id);
        IEnumerable<DepositModel> GetAll();
        void CloseBankDay();
        void WithdrawPercents(int id);
        void CloseDeposit(int id);
    }
}
