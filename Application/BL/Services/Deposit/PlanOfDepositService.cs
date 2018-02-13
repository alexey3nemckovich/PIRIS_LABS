using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BL.Services.Account;
using BL.Services.Deposit.Models;
using Microsoft.Practices.Unity;
using ORMLibrary;

namespace BL.Services.Deposit
{
    public class PlanOfDepositService : BaseService, IPlanOfDepositService
    {
        [Dependency]
        public IPlanOfAccountService PlanService { get; set; }

        public PlanOfDepositService() : base()
        {
        }

        public void Create(PlanOfDepositModel plan)
        {
            var dbPlan = Mapper.Map<PlanOfDepositModel, PlanOfDeposit>(plan);
            dbPlan.MainPlanOfAccount = Context.PlanOfAccounts.FirstOrDefault(e => e.AccountNumber == "3014");
            dbPlan.PercentPlanOfAccount = Context.PlanOfAccounts.FirstOrDefault(e => e.AccountNumber == "3014");
            Context.PlanOfDeposits.Add(dbPlan);
            Context.SaveChanges();
        }

        public IEnumerable<PlanOfDepositModel> GetAll()
        {
            return Context.PlanOfDeposits.ToArray().Select(Mapper.Map<PlanOfDeposit, PlanOfDepositModel>);
        }
    }
}
