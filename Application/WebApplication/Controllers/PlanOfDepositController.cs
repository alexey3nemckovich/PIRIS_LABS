using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BL.Services.Deposit;
using BL.Services.Deposit.Models;
using Microsoft.Practices.Unity;
using WebApplication.Infrastructure;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class PlanOfDepositController : Controller
    {
        [Dependency]
        public IPlanOfDepositService PlanService { get; set; }

        public IMapper Mapper { get; set; } =MappingRegistrar.CreareMapper();

        public ActionResult Index()
        {
            var plans = PlanService.GetAll();
            return View(plans.Select(Mapper.Map<PlanOfDepositModel, PlanOfDeposit>));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new PlanOfDeposit());
        }

        [HttpPost]
        public ActionResult Create(PlanOfDeposit plan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PlanService.Create(Mapper.Map<PlanOfDeposit, PlanOfDepositModel>(plan));
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(plan);
                }
            }
            return View(plan);
        }
    }
}