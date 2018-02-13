namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        public int Id { get; set; }

        public int DebetAccountId { get; set; }

        public int CreditAccountId { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public int TransactionDay { get; set; }

        public virtual Account DebetAccount { get; set; }

        public virtual Account CreditAccount { get; set; }
    }
}
