namespace collegeCompanionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CompanionUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanionUser()
        {
            College_User_Relations = new HashSet<College_User_Relations>();
        }

        [Key]
        public int CompanionID { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(128)]
        public string ASPIdentityID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<College_User_Relations> College_User_Relations { get; set; }
    }
}
