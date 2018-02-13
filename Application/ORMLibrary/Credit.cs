namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Credit")]
    public partial class Credit
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int PlanId { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public int MainAccountId { get; set; }

        public int PercentAccountId { get; set; }

        [StringLength(16)]
        public string CreditCardNumber { get; set; }

        [StringLength(4)]
        public string CreditCardPin { get; set; }

        public virtual Account MainAccount { get; set; }

        public virtual Account PercentAccount { get; set; }

        public virtual Client Client { get; set; }

        public virtual PlanOfCredit PlanOfCredit { get; set; }
    }
}
