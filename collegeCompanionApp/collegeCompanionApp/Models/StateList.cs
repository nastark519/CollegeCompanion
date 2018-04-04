namespace collegeCompanionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StateList")]
    public partial class StateList
    {
        [Key]
        public int StateID { get; set; }

        [Required]
        [StringLength(50)]
        public string QueryName { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(2)]
        public string StateAbbr { get; set; }
    }
}
