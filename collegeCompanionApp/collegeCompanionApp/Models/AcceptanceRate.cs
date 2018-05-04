namespace collegeCompanionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AcceptanceRate")]
    public partial class AcceptanceRate
    {
        [Key]
        public int AcceptanceRateID { get; set; }

        [Required]
        [StringLength(50)]
        public string AcceptanceRateValue { get; set; }
    }
}
