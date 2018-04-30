namespace collegeCompanionApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CompanionContext : DbContext
    {
        public CompanionContext()
            : base("name=CompanionContextDB")
        {
        }

        public virtual DbSet<College_User_Relations> College_User_Relations { get; set; }
        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<CompanionUser> CompanionUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
