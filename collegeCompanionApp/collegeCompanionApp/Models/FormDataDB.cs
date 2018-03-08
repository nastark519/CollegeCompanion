namespace collegeCompanionApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FormDataDB : DbContext
    {
        public FormDataDB()
            : base("name=FormDataDB_Context")
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
