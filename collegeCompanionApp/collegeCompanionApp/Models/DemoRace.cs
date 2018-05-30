namespace collegeCompanionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DemoRace")]
    public partial class DemoRace
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public DemoRace()
        //{
        //    SearchResults = new HashSet<SearchResult>();
        //}

        [Key]
        public int DemoRaceID { get; set; }

        [Required]
        [StringLength(100)]
        public string DemoRaceName { get; set; }

        [Required]
        [StringLength(50)]
        public string DemoRaceValue { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SearchResult> SearchResults { get; set; }
    }
}
