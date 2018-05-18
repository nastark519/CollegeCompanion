namespace collegeCompanionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DegreeList")]
    public partial class DegreeList
    {
        [Key]
        public int DegreeID { get; set; }

        [Required]
        [StringLength(100)]
        public string DegreeName { get; set; }

        [Required]
        [StringLength(50)]
        public string DegreeValue { get; set; }
    }
}
