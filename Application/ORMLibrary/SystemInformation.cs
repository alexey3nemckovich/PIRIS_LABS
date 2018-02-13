namespace ORMLibrary
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SystemInformation")]
    public partial class SystemInformation
    {
        public SystemInformation()
        {

        }

        public SystemInformation(DateTime date)
        {
            CurrentBankDate = date;
        }

        public int Id { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime CurrentBankDate { get; set; }
    }
}
