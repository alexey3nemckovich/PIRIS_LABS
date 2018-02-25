namespace ORMLibrary
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanOfDeposit")]
    public partial class PlanOfDeposit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlanOfDeposit()
        {
            Deposits = new HashSet<Deposit>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("Day period")]
        public int DayPeriod { get; set; }

        public double Percent { get; set; }

        public bool Revocable { get; set; }

        [Column(TypeName = "money")]
        public decimal? MinAmount { get; set; }

        public int MainAccountPlanId { get; set; }

        public int PercentAccountPlanId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deposit> Deposits { get; set; }

        public virtual PlanOfAccount MainPlanOfAccount { get; set; }

        public virtual PlanOfAccount PercentPlanOfAccount { get; set; }
    }
}
