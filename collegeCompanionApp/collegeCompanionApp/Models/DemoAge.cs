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
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public DemoAge()
        //{
        //    SearchResults = new HashSet<SearchResult>();
        //}

        [Key]
        public int DemoAgeID { get; set; }

        [Required]
        [StringLength(100)]
        public string DemoAgeRange { get; set; }

        [Required]
        [StringLength(50)]
        public string DemoAgeRangeValue { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SearchResult> SearchResults { get; set; }
    }
}
