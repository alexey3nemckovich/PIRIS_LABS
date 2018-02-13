using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BL.Services.Client;
using BL.Services.Common;
using BL.Services.Deposit;
using BL.Services.Deposit.Models;
using Microsoft.Practices.Unity;
using WebApplication.Infrastructure;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class DepositController : Controller
    {
        [Dependency]
        public IDepositService DepositService { get; set; }

        [Dependency]
        public IPlanOfDepositService PlanOfDepositService { get; set; }

        [Dependency]
        public IClientService ClientService { get; set; }

        [Dependency]
        public ISystemInformationService SystemInformationService { get; set; }

        public IMapper Mapper { get; set; } = MappingRegistrar.CreareMapper();

        public ActionResult Index()
        {
            var deposits = DepositService.GetAll();
            return View(deposits.Select(e => e.ToDeposit(SystemInformationService)));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateDepositModel().ToCreateDepositModel(PlanOfDepositService, ClientService));
        }

        [HttpPost]
        public ActionResult Create(CreateDepositModel deposit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DepositService.Create(Mapper.Map<CreateDepositModel, DepositModel>(deposit));
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(deposit.ToCreateDepositModel(PlanOfDepositService, ClientService));
                }
            }
            return View(deposit.ToCreateDepositModel(PlanOfDepositService, ClientService));
        }

        [HttpGet]
        public ActionResult Details(int depositId)
        {
            var deposit = DepositService.Get(depositId);
            return View(deposit.ToDeposit(SystemInformationService));
        }

        [HttpPost]
        public ActionResult TakePercents(int depositId)
        {
            try
            {
                DepositService.WithdrawPercents(depositId);
                return RedirectToAction("Details", new {depositId = depositId});
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("", ex);
                return RedirectToAction("Details", new { depositId = depositId });
            }
        }

        [HttpPost]
        public ActionResult CloseDeposit(int depositId)
        {
            try
            {
                DepositService.CloseDeposit(depositId);
                return RedirectToAction("Details", new {depositId = depositId});
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("", ex);
                return RedirectToAction("Details", new {depositId = depositId});
            }
        }
    }
}