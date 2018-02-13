using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BL.Services.Account;
using BL.Services.Credit.Models;
using Microsoft.Practices.Unity;
using ORMLibrary;
using AppContext = ORMLibrary.AppContext;

namespace BL.Services.Credit
{
    public class PlanOfCreditService : BaseService, IPlanOfCreditService
    {
        [Dependency]
        public IPlanOfAccountService PlanService { get; set; }

        public PlanOfCreditService() : base()
        {
        }

        public void Create(PlanOfCreditModel plan)
        {
            var dbPlan = Mapper.Map<PlanOfCreditModel, PlanOfCredit>(plan);
            dbPlan.MainPlanOfAccount = Context.PlanOfAccounts.FirstOrDefault(e => e.AccountNumber == "2400");
            dbPlan.PercentPlanOfAccount = Context.PlanOfAccounts.FirstOrDefault(e => e.AccountNumber == "2400");
            Context.PlanOfCredits.Add(dbPlan);
            Context.SaveChanges();
        }

        public IEnumerable<PlanOfCreditModel> GetAll()
        {
            return Context.PlanOfCredits.ToArray().Select(Mapper.Map<PlanOfCredit, PlanOfCreditModel>);
        }
    }
}
