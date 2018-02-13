namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            MainAccountCredits = new HashSet<Credit>();
            PercentAccountCredits = new HashSet<Credit>();
            MainAccountDeposits = new HashSet<Deposit>();
            PercentAccountDeposits = new HashSet<Deposit>();
            DebitTransactions = new HashSet<Transaction>();
            CreditTransactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }

        public int PlanId { get; set; }

        [Required]
        [StringLength(13)]
        public string AccountNumber { get; set; }

        [Column(TypeName = "money")]
        public decimal DebitValue { get; set; }

        [Column(TypeName = "money")]
        public decimal CreditValue { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        public virtual PlanOfAccount PlanOfAccount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Credit> MainAccountCredits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Credit> PercentAccountCredits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deposit> MainAccountDeposits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deposit> PercentAccountDeposits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> DebitTransactions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> CreditTransactions { get; set; }
    }
}
