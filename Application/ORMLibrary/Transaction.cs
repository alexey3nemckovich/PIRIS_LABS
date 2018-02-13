namespace ORMLibrary
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Transaction")]
    public partial class Transaction
    {
        public int Id { get; set; }

        public int DebetAccountId { get; set; }

        public int CreditAccountId { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime TransactionDay { get; set; }

        public virtual Account DebetAccount { get; set; }

        public virtual Account CreditAccount { get; set; }
    }
}
