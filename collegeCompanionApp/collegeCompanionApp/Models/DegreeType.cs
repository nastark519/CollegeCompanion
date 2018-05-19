namespace collegeCompanionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DegreeType")]
    public partial class DegreeType
    {
        public int DegreeTypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string DegreeTypeName { get; set; }

        [Required]
        [StringLength(50)]
        public string DegreeTypeValue { get; set; }
    }
}
