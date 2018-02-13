using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.Services.Account.Models;
using BL.Services.Client.Models;
using BL.Services.Credit.Models;
using BL.Services.Deposit.Models;
using BL.Services.Transaction.Models;
using ORMLibrary;

namespace BL.Services.Utilities
{
    public static class MappingRegistrar
    {
        public static MapperConfiguration CreateMapperConfiguration()
        {
            var config = new MapperConfiguration(e =>
            {
                e.CreateMap<Town, TownModel>();
                e.CreateMap<Disability, DisabilityModel>();
                e.CreateMap<MartialStatus, MaritalStatusModel>();
                e.CreateMap<Citizenship, CitizenshipModel>();
                e.CreateMap<ORMLibrary.Client, ClientModel>();
                e.CreateMap<ClientModel, ORMLibrary.Client>()
                    .ForMember(t => t.Citizenship, r => r.Ignore())
                    .ForMember(t => t.Disability, r => r.Ignore())
                    .ForMember(t => t.MartialStatus, r => r.Ignore())
                    .ForMember(t => t.Town, r => r.Ignore());

                e.CreateMap<PlanOfAccount, PlanOfAccountModel>();

                e.CreateMap<PlanOfCredit, PlanOfCreditModel>();
                e.CreateMap<PlanOfCreditModel, PlanOfCredit>()
                    .ForMember(r => r.MainPlanOfAccount, r => r.Ignore())
                    .ForMember(r => r.PercentPlanOfAccount, r => r.Ignore());

                e.CreateMap<PlanOfDeposit, PlanOfDepositModel>();
                e.CreateMap<PlanOfDepositModel, PlanOfDeposit>()
                    .ForMember(r => r.MainPlanOfAccount, r => r.Ignore())
                    .ForMember(r => r.PercentPlanOfAccount, r => r.Ignore());

                e.CreateMap<ORMLibrary.Account, AccountModel>();
                e.CreateMap<AccountModel, ORMLibrary.Account>();

                e.CreateMap<ORMLibrary.Credit, CreditModel>();
                e.CreateMap<CreditModel, ORMLibrary.Credit>()
                    .ForMember(t => t.MainAccount, r => r.Ignore())
                    .ForMember(t => t.PercentAccount, r => r.Ignore());

                e.CreateMap<ORMLibrary.Deposit, DepositModel>();
                e.CreateMap<DepositModel, ORMLibrary.Deposit>()
                    .ForMember(t => t.MainAccount, r => r.Ignore())
                    .ForMember(t => t.PercentAccount, r => r.Ignore());

                e.CreateMap<ORMLibrary.Transaction, TransactionModel>();
                e.CreateMap<TransactionModel, ORMLibrary.Transaction>();
            });
            return config;
        }
    }
}
