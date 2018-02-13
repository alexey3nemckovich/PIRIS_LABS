namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Credits = new HashSet<Credit>();
            Deposits = new HashSet<Deposit>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Patronymic { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        public bool Male { get; set; }

        [Required]
        [StringLength(2)]
        public string PassportSeries { get; set; }

        [Required]
        [StringLength(7)]
        public string PassportNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string IssuedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime IssueDate { get; set; }

        [Required]
        [StringLength(50)]
        public string IdentificationNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string BirthPlace { get; set; }

        public int ResidenceActualPlaceId { get; set; }

        [Required]
        [StringLength(50)]
        public string ResidenceActualAddress { get; set; }

        [StringLength(50)]
        public string HomePhoneNumber { get; set; }

        [StringLength(50)]
        public string MobilePhoneNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string ResidenceAddress { get; set; }

        public int MaritalStatusId { get; set; }

        public int CitezenshipId { get; set; }

        public int DisabilityId { get; set; }

        public bool Pensioner { get; set; }

        [Column(TypeName = "money")]
        public decimal? MonthlyIncome { get; set; }

        public virtual Citizenship Citizenship { get; set; }

        public virtual Disability Disability { get; set; }

        public virtual MartialStatus MartialStatus { get; set; }

        public virtual Town Town { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Credit> Credits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deposit> Deposits { get; set; }
    }
}
