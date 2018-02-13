namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Deposit")]
    public partial class Deposit
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int PlanId { get; set; }

        public int StartDate { get; set; }

        public int EndDate { get; set; }

        public int MainAccountId { get; set; }

        public int PercentAccountId { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public virtual Account MainAccount { get; set; }

        public virtual Account PercentAccount { get; set; }

        public virtual Client Client { get; set; }

        public virtual PlanOfDeposit PlanOfDeposit { get; set; }
    }
}
