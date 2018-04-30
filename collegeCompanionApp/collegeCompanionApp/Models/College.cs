namespace collegeCompanionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class College
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public College()
        {
            College_User_Relations = new HashSet<College_User_Relations>();
        }

        public int CollegeID { get; set; }

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

        public string Ownership { get; set; }

        public int Cost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<College_User_Relations> College_User_Relations { get; set; }
    }
}
