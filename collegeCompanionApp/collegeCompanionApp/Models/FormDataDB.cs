namespace collegeCompanionApp.Models
{
    using collegeCompanionApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public partial class FormdataDB : DbContext
    {
        public FormdataDB()
            : base("name=CompanionContextDB")
        {
        }

        public virtual DbSet<FinLimitList> FinLimitLists { get; set; }
        public virtual DbSet<PrivacyList> PrivacyLists { get; set; }
        public virtual DbSet<StateList> StateLists { get; set; }
        public virtual DbSet<DegreeList> DegreeLists { get; set; }
        public virtual DbSet<DegreeType> DegreeTypes { get; set; }
        public virtual DbSet<AcceptanceRate> AcceptanceRates { get; set; }
        public virtual DbSet<DemoRace> DemoRaces { get; set; }
        public virtual DbSet<DemoAge> DemoAges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
