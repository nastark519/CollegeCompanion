namespace collegeCompanionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FinLimitList")]
    public partial class FinLimitList
    {
        [Key]
        public int FinLimitID { get; set; }

        public int LowerLimit { get; set; }

        public int UpperLimit { get; set; }
    }
}
