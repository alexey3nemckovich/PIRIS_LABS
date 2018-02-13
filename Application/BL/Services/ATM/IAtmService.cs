using BL.Services.Credit.Models;

namespace BL.Services.ATM
{
    public interface IAtmService
    {
        CreditModel LoginUser(string creditCardNumber, string pin);
        void WithDrawMoney(int creditId, decimal amount);
        void TransferMoney(int creditId, string accountNumber, decimal amount);
    }
}
