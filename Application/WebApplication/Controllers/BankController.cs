using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BL.Services.Common;
using BL.Services.Transaction;
using Microsoft.Practices.Unity;
using WebApplication.Infrastructure;

namespace WebApplication.Controllers
{
    public class BankController : Controller
    {
        [Dependency]
        public IBankService BankService { get; set; }

        [Dependency]
        public ITransactionService TransactionService { get; set; }

        [Dependency]
        public ICommonService CommonService { get; set; }

        public IMapper Mapper { get; set; } = MappingRegistrar.CreareMapper();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CloseBankDay()
        {
            BankService.CloseBankDay();
            return RedirectToAction("Index");
        }

        public ActionResult CloseBankMonth()
        {
            BankService.CloseBankMonth();
            return RedirectToAction("Index");
        }

        public ActionResult CloseBankYear()
        {
            BankService.CloseBankYear();
            return RedirectToAction("Index");
        }

        public ActionResult DayTransactionsReport()
        {
            var report = BankService.GenerateTransactionReport(CommonService.CurrentBankDay);
            return View("TransactionReport", report);
        }

        public ActionResult PreviousDayTransactionsReport()
        {
            var report =
                BankService.GenerateTransactionReport(CommonService.CurrentBankDay == 0
                    ? 0
                    : CommonService.CurrentBankDay - 1);
            return View("TransactionReport", report);
        }

        public ActionResult AccountReport()
        {
            var report = BankService.GenerateAccountReport();
            return View("AccountReport", report);
        }
    }
}