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
        [Key]
        public int DemoRaceID { get; set; }

        [Required]
        [StringLength(100)]
        public string DemoRaceName { get; set; }

        [Required]
        [StringLength(50)]
        public string DemoRaceValue { get; set; }
    }
}
