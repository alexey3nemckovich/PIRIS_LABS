namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlanOfAccount")]
    public partial class PlanOfAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlanOfAccount()
        {
            Accounts = new HashSet<Account>();
            MainAccountPlanOfCredits = new HashSet<PlanOfCredit>();
            PercentAccountPlanOfCredits = new HashSet<PlanOfCredit>();
            MainAccountPlanOfDeposits = new HashSet<PlanOfDeposit>();
            PercentAccountPlanOfDeposits = new HashSet<PlanOfDeposit>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(4)]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountName { get; set; }

        [Required]
        [StringLength(1)]
        public string AccountType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanOfCredit> MainAccountPlanOfCredits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanOfCredit> PercentAccountPlanOfCredits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanOfDeposit> MainAccountPlanOfDeposits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanOfDeposit> PercentAccountPlanOfDeposits { get; set; }
    }
}
