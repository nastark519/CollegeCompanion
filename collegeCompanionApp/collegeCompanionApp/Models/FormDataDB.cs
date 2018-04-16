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
            : base("name=formdataDB_Context")
        {
        }

        public virtual DbSet<FinLimitList> FinLimitLists { get; set; }
        public virtual DbSet<PrivacyList> PrivacyLists { get; set; }
        public virtual DbSet<StateList> StateLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
