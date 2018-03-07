namespace collegeCompanionApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CompanionContext : DbContext
    {
        public CompanionContext()
            : base("name=CompanionContext")
        {
        }

        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<CollegeFavorite> CollegeFavorites { get; set; }
        public virtual DbSet<Party> Parties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Party>()
                .Property(e => e.PartyEmail)
                .IsUnicode(false);
        }
    }
}
