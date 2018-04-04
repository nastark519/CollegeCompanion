namespace collegeCompanionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Party")]
    public partial class Party
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Party()
        {
            CollegeFavorites = new HashSet<CollegeFavorite>();
        }

        public int PartyID { get; set; }

        [Required]
        [StringLength(50)]
        public string PartyName { get; set; }

        [Required]
        [StringLength(45)]
        public string PartyEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CollegeFavorite> CollegeFavorites { get; set; }
    }
}
