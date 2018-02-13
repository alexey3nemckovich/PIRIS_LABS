using System.Collections.Generic;

namespace BL.Services.Account.Models
{
    public class PlanOfAccountModel
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public virtual ICollection<AccountModel> Accounts { get; set; }
    }
}
