﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BL.Services.Client;
using BL.Services.Client.Models;
using BL.Services.Common;
using BL.Services.Credit;
using BL.Services.Credit.Models;
using BL.Services.Deposit;
using BL.Services.Deposit.Models;
using BL.Services.Transaction.Models;
using Microsoft.Practices.Unity;
using WebApplication.Models.ViewModels;

namespace WebApplication.Infrastructure
{
    public static class MappingRegistrar
    {
        public static IMapper CreareMapper()
        {
            MapperConfiguration config = new MapperConfiguration(e =>
            {
                #region PlanOfDepositMapper

                e.CreateMap<PlanOfDepositModel, PlanOfDeposit>();
                e.CreateMap<PlanOfDeposit, PlanOfDepositModel>();

                #endregion

                #region DepositMapper

                e.CreateMap<DepositModel, Deposit>();
                e.CreateMap<Deposit, DepositModel>();
                e.CreateMap<CreateDepositModel, DepositModel>();

                #endregion

                #region PlanOfCreditMapper

                e.CreateMap<PlanOfCreditModel, PlanOfCredit>();
                e.CreateMap<PlanOfCredit, PlanOfCreditModel>();

                #endregion

                #region CreditMapper

                e.CreateMap<CreditModel, Credit>();
                e.CreateMap<Credit, CreditModel>();
                e.CreateMap<CreateCreditModel, CreditModel>();
                e.CreateMap<PlanOfPaymentModel, PlanOfPayment>();

                #endregion

                #region TransactionMapper

                #endregion
            });
            return config.CreateMapper();
        }

        public static Client ToClient(this Client client, IClientService clientService)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Client, Client>().ForMember(r => r.DisabilityStatuses,
                    r => r.MapFrom(t => clientService.GetDisabilities().Select(y => y.Status)))
                .ForMember(r => r.Citizenships,
                    r => r.MapFrom(t => clientService.GetCitizenships().Select(y => y.Country)))
                .ForMember(r => r.Towns,
                    r => r.MapFrom(t => clientService.GetTowns().Select(y => y.Name)))
                .ForMember(r => r.MartialStatuses,
                    r => r.MapFrom(t => clientService.GetMaritalStatuses().Select(y => y.Status))));
            return Mapper.Map<Client, Client>(client);
        }

        public static Client ToClient(this ClientModel client, IClientService clientService)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ClientModel, Client>()
                .ForMember(r => r.Disability, r => r.MapFrom(t => t.Disability.Status))
                .ForMember(r => r.Citizenship, r => r.MapFrom(t => t.Citizenship.Country))
                .ForMember(r => r.MaritalStatus, r => r.MapFrom(t => t.MartialStatus.Status))
                .ForMember(r => r.ResidenceActualPlace, r => r.MapFrom(t => t.Town.Name))
                .ForMember(r => r.DisabilityStatuses,
                    r => r.MapFrom(t => clientService.GetDisabilities().Select(y => y.Status)))
                .ForMember(r => r.Citizenships,
                    r => r.MapFrom(t => clientService.GetCitizenships().Select(y => y.Country)))
                .ForMember(r => r.Towns,
                    r => r.MapFrom(t => clientService.GetTowns().Select(y => y.Name)))
                .ForMember(r => r.MartialStatuses,
                    r => r.MapFrom(t => clientService.GetMaritalStatuses().Select(y => y.Status))));
            return Mapper.Map<ClientModel, Client>(client);
        }

        public static ClientModel ToClientModel(this Client client, IClientService clientService)
        {
            Mapper.Initialize(e =>
            {
                e.CreateMap<Client, ClientModel>()
                    .ForMember(r => r.Disability,
                        r =>
                            r.MapFrom(
                                t => clientService.GetDisabilities().FirstOrDefault(y => y.Status == t.Disability)))
                    .ForMember(r => r.Town,
                        r =>
                            r.MapFrom(
                                t => clientService.GetTowns().FirstOrDefault(y => y.Name == t.ResidenceActualPlace)))
                    .ForMember(r => r.Citizenship,
                        r =>
                            r.MapFrom(
                                t => clientService.GetCitizenships().FirstOrDefault(y => y.Country == t.Citizenship)))
                    .ForMember(r => r.MartialStatus,
                        r =>
                            r.MapFrom(
                                t => clientService.GetMaritalStatuses().FirstOrDefault(y => y.Status == t.MaritalStatus)));
            });
            return Mapper.Map<Client, ClientModel>(client);
        }

        public static CreateCreditModel ToCreateCreditModel(this CreditModel credit, IPlanOfCreditService planService, IClientService clientService)
        {
            Mapper.Initialize(e => e.CreateMap<CreditModel, CreateCreditModel>()
                .ForMember(t => t.CreditPlans, t => t.MapFrom(
                    r => planService.GetAll().Select(Mapper.Map<PlanOfCreditModel, PlanOfCredit>)))
                .ForMember(t => t.Clients,
                    t => t.MapFrom(r => clientService.GetAll().Select(y => y.ToClient(clientService)))));
            return Mapper.Map<CreditModel, CreateCreditModel>(credit);
        }

        public static CreateCreditModel ToCreateCreditModel(this CreateCreditModel credit, IPlanOfCreditService planService, IClientService clientService)
        {
            Mapper.Initialize(e => {
                e.CreateMap<ClientModel, Client>();
                e.CreateMap<PlanOfCreditModel, PlanOfCredit>();
                e.CreateMap<CreateCreditModel, CreateCreditModel>()
                    .ForMember(t => t.CreditPlans, t => t.MapFrom(
                        r => planService.GetAll().Select(Mapper.Map<PlanOfCreditModel, PlanOfCredit>)))
                    .ForMember(t => t.Clients,
                        t => t.MapFrom(r => clientService.GetAll().Select(y => y.ToClient(clientService))));
            });
            return Mapper.Map<CreateCreditModel, CreateCreditModel>(credit);
        }

        public static CreateDepositModel ToCreateDepositModel(this DepositModel deposit, IPlanOfDepositService planService, IClientService clientService)
        {
            Mapper.Initialize(e => e.CreateMap<DepositModel, CreateDepositModel>()
                .ForMember(t => t.DepositPlans, t => t.MapFrom(
                    r => planService.GetAll().Select(Mapper.Map<PlanOfDepositModel, PlanOfDeposit>)))
                .ForMember(t => t.Clients,
                    t => t.MapFrom(r => clientService.GetAll().Select(y => y.ToClient(clientService)))));
            return Mapper.Map<DepositModel, CreateDepositModel>(deposit);
        }

        public static CreateDepositModel ToCreateDepositModel(this CreateDepositModel deposit,
            IPlanOfDepositService planService, IClientService clientService)
        {
            Mapper.Initialize(e =>
            {
                e.CreateMap<ClientModel, Client>();
                e.CreateMap<PlanOfDepositModel, PlanOfDeposit>();
                e.CreateMap<CreateDepositModel, CreateDepositModel>()
                    .ForMember(t => t.DepositPlans, t => t.MapFrom(
                        r => planService.GetAll().Select(Mapper.Map<PlanOfDepositModel, PlanOfDeposit>)))
                    .ForMember(t => t.Clients,
                        t => t.MapFrom(r => clientService.GetAll().Select(y => y.ToClient(clientService))));
            });
            return Mapper.Map<CreateDepositModel, CreateDepositModel>(deposit);
        }

        public static Credit ToCredit(this CreditModel credit, ICommonService commonService)
        {
            Mapper.Initialize(e =>
            {
                e.CreateMap<ClientModel, Client>();
                e.CreateMap<PlanOfCreditModel, PlanOfCredit>();
                e.CreateMap<CreditModel, Credit>()
                    .ForMember(t => t.Balance,
                        t => t.MapFrom(r => r.MainAccount.Balance))
                    .ForMember(t => t.StartDate,
                        t => t.MapFrom(r => commonService.StartDate + new TimeSpan(r.StartDate, 0, 0, 0)))
                    .ForMember(t => t.EndDate,
                        t => t.MapFrom(r => commonService.StartDate + new TimeSpan(r.EndDate, 0, 0, 0)))
                    .ForMember(t => t.CurrentPercentAmount, t => t.MapFrom(r => Math.Abs(r.PercentAccount.Balance)))
                    .ForMember(t => t.IsCanCloseToday,
                        t =>
                            t.MapFrom(
                                r =>
                                    (r.EndDate <= commonService.CurrentBankDay) &&
                                    r.Amount > 0))
                    .ForMember(t => t.IsCanPayPercentToday,
                        t =>
                            t.MapFrom(
                                r =>
                                    (commonService.CurrentBankDay - r.StartDate)%commonService.MonthLength == 0 &&
                                    r.Amount > 0));
            });
            return Mapper.Map<CreditModel, Credit>(credit);
        }

        public static Deposit ToDeposit(this DepositModel deposit, ICommonService commonService)
        {
            Mapper.Initialize(e =>
            {
                e.CreateMap<ClientModel, Client>();
                e.CreateMap<PlanOfDepositModel, PlanOfDeposit>();
                e.CreateMap<DepositModel, Deposit>()
                    .ForMember(t => t.CurrentPercentAmount, t => t.MapFrom(r => r.PercentAccount.Balance))
                    .ForMember(t => t.PercentAmountForDay,
                        t => t.MapFrom(r => (double) r.Amount*r.PlanOfDeposit.Percent/100/commonService.YearLength))
                    .ForMember(t => t.StartDate,
                        t => t.MapFrom(r => commonService.StartDate + new TimeSpan(r.StartDate, 0, 0, 0)))
                    .ForMember(t => t.EndDate,
                        t => t.MapFrom(r => commonService.StartDate + new TimeSpan(r.EndDate, 0, 0, 0)))
                    .ForMember(t => t.IsCanCloseToday,
                        t =>
                            t.MapFrom(
                                r =>
                                    (r.PlanOfDeposit.Revocable || r.EndDate < commonService.CurrentBankDay) &&
                                    r.Amount > 0))
                    .ForMember(t => t.IsCanWithdrawPercentsToday,
                        t =>
                            t.MapFrom(
                                r =>
                                    !r.PlanOfDeposit.Revocable &&
                                    (commonService.CurrentBankDay - r.StartDate)%commonService.MonthLength == 0 &&
                                    r.Amount > 0));
            });
            return Mapper.Map<DepositModel, Deposit>(deposit);
        }
    }
}