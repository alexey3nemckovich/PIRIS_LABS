using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BL.Services.Client;
using BL.Services.Credit;
using BL.Services.Credit.Models;
using Microsoft.Practices.Unity;
using WebApplication.Infrastructure;
using WebApplication.Models.ViewModels;
using BL.Services.Common;

namespace WebApplication.Controllers
{
    public class CreditController : Controller
    {
        [Dependency]
        public ICreditService CreditService { get; set; }

        [Dependency]
        public IPlanOfCreditService PlanOfCreditService { get; set; }

        [Dependency]
        public ISystemInformationService SystemInformationService { get; set; }

        [Dependency]
        public IClientService ClientService { get; set; }

        public IMapper Mapper { get; set; } = MappingRegistrar.CreareMapper();

        public ActionResult Index()
        {
            var credits = CreditService.GetAll();
            return View(credits.Select(e => e.ToCredit(SystemInformationService)));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateCreditModel().ToCreateCreditModel(PlanOfCreditService, ClientService));
        }

        [HttpPost]
        public ActionResult Create(CreateCreditModel credit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CreditService.Create(Mapper.Map<CreateCreditModel, CreditModel>(credit), credit.CreateCreditCard);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(credit.ToCreateCreditModel(PlanOfCreditService, ClientService));
                }
            }
            return View(credit.ToCreateCreditModel(PlanOfCreditService, ClientService));
        }

        [HttpGet]
        public ActionResult Details(int creditId)
        {
            var credit = CreditService.Get(creditId);
            return View(credit.ToCredit(SystemInformationService));
        }

        [HttpGet]
        public ActionResult PaymentSchedule(int creditId)
        {
            var schedule = CreditService.GetPaymentSchedule(creditId);
            return View("Schedule", Mapper.Map<PlanOfPaymentModel, PlanOfPayment>(schedule));
        }


        [HttpPost]
        public ActionResult PayPercents(int creditId)
        {
            CreditService.PayPercents(creditId);
            return RedirectToAction("Details", new { CreditId = creditId });
        }

        [HttpPost]
        public ActionResult CloseCredit(int creditId)
        {
            CreditService.CloseCredit(creditId);
            return RedirectToAction("Details", new { CreditId = creditId });
        }
    }
}