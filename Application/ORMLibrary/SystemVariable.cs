namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SystemVariable
    {
        public int Id { get; set; }

        public int CurrentBankDay { get; set; }

        public int StartBankDay { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
    }
}
