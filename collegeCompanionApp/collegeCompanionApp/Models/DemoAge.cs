namespace collegeCompanionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DemoAge")]
    public partial class DemoAge
    {
        [Key]
        public int DemoAgeID { get; set; }

        [Required]
        [StringLength(100)]
        public string DemoAgeRange { get; set; }

        [Required]
        [StringLength(50)]
        public string DemoAgeRangeValue { get; set; }
    }
}
