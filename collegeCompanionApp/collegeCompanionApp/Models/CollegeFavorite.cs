namespace collegeCompanionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CollegeFavorite")]
    public partial class CollegeFavorite
    {
        public int CollegeFavoriteID { get; set; }

        public int? CollegeID { get; set; }

        public int? PartyID { get; set; }

        public virtual College College { get; set; }

        public virtual Party Party { get; set; }
    }
}
