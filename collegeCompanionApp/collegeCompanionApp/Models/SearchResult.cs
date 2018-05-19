namespace collegeCompanionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SearchResult
    {
        [Key]
        public int SearchResultsID { get; set; }

        public int? CompanionID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string StateName { get; set; }

        [Required]
        [StringLength(25)]
        public string City { get; set; }

        [StringLength(25)]
        public string Accreditor { get; set; }

        public int Ownership { get; set; }

        public int Cost { get; set; }

        public int ZipCode { get; set; }

        [StringLength(100)]
        public string Degree { get; set; }

        [StringLength(100)]
        public string DegreeType { get; set; }

        public virtual CompanionUser CompanionUser { get; set; }
    }
}
