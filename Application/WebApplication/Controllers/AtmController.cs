using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BL.Services.ATM;
using BL.Services.Credit;
using Microsoft.Practices.Unity;
using WebApplication.Infrastructure;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class AtmController : Controller
    {
        [Dependency]
        public IAtmService AtmService{ get; set; }

        [Dependency]
        public ICreditService CreditService { get; set; }

        public IMapper Mapper { get; set; } = MappingRegistrar.CreareMapper();
        // GET: Atm
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(AtmLoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var credit = AtmService.LoginUser(model.CreditCardNumber, model.PinCode);
                    if (credit != null)
                        return RedirectToAction("WorkPage", new {creditId = credit.Id});
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Incorrect account number or pin code.");
                    return View(model);
                }
            }
            return View(model);
        }

        public ActionResult WorkPage(int creditId)
        {
            var credit = CreditService.Get(creditId);
            return View(new AtmAccountModel() {CreditId = credit.Id, Amount = credit.MainAccount.Balance});
        }

        public ActionResult WithdrawMoney(int creditId, decimal amount)
        {
            AtmService.WithDrawMoney(creditId, amount);
            return RedirectToAction("WorkPage", new {creditId = creditId});
        }

        public ActionResult TransferMoney(int creditId, string accountNumber, decimal amount)
        {
            AtmService.TransferMoney(creditId, accountNumber, amount);
            return RedirectToAction("WorkPage", new {creditId = creditId});
        }
    }
}