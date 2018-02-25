namespace ORMLibrary
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanOfCredit")]
    public partial class PlanOfCredit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlanOfCredit()
        {
            Credits = new HashSet<Credit>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("Time period(in monthes)")]
        public int MonthPeriod { get; set; }

        public double Percent { get; set; }

        public bool Anuity { get; set; }

        [Column(TypeName = "money")]
        public decimal? MinAmount { get; set; }

        public int MainAccountPlanId { get; set; }

        public int PercentAccountPlanId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Credit> Credits { get; set; }

        public virtual PlanOfAccount MainPlanOfAccount { get; set; }

        public virtual PlanOfAccount PercentPlanOfAccount { get; set; }
    }
}
