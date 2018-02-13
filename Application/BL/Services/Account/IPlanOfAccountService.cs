using System.Collections.Generic;
using BL.Services.Account.Models;
using ORMLibrary;

namespace BL.Services.Account
{
    public interface IPlanOfAccountService
    {
        IEnumerable<PlanOfAccountModel> GetAll();

        PlanOfAccount GetByNumber(string number);

        PlanOfAccount GetById(int id);
    }
}
