using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BL.Services.Credit;
using BL.Services.Credit.Models;
using Microsoft.Practices.Unity;
using WebApplication.Infrastructure;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class PlanOfCreditController : Controller
    {
        [Dependency]
        public IPlanOfCreditService PlanService { get; set; }

        public IMapper Mapper { get; set; } = MappingRegistrar.CreareMapper();

        public ActionResult Index()
        {
            var plans = PlanService.GetAll();
            return View(plans.Select(Mapper.Map<PlanOfCreditModel, PlanOfCredit>));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PlanOfCredit plan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PlanService.Create(Mapper.Map<PlanOfCredit, PlanOfCreditModel>(plan));
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(plan);
                }
            }
            return View(plan);
        }
    }
}
