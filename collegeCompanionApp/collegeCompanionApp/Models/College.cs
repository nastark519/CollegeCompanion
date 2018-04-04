namespace collegeCompanionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("College")]
    public partial class College
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public College()
        {
            CollegeFavorites = new HashSet<CollegeFavorite>();
        }

        public int CollegeID { get; set; }

        [StringLength(200)]
        public string CityName { get; set; }

        [Required]
        [StringLength(200)]
        public string StateName { get; set; }

        [Required]
        [StringLength(200)]
        public string CollegeName { get; set; }

        [StringLength(200)]
        public string Focus { get; set; }

        [StringLength(200)]
        public string Accreditor { get; set; }

        public int? Ownership { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CollegeFavorite> CollegeFavorites { get; set; }
    }
}
