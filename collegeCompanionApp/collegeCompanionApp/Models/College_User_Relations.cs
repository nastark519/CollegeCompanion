namespace collegeCompanionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class College_User_Relations
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CompanionID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CollegeID { get; set; }

        //public bool Favorite { get; set; } // maybe change to an int and look for == 0 and < 0.

        //public bool Saved { get; set; }

        public virtual College College { get; set; }

        public virtual CompanionUser CompanionUser { get; set; }

        //In the tutorial for 461 we need to add this for fallowing option 3 
        //public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
