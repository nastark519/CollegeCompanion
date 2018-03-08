namespace collegeCompanionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PrivacyList")]
    public partial class PrivacyList
    {
        [Key]
        public int PrivacyID { get; set; }

        public int PrivacyNumber { get; set; }

        [Required]
        [StringLength(25)]
        public string PrivacyType { get; set; }
    }
}
