using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class PlanOfAccount
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
    }
}