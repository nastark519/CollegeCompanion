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

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AcceptanceRate> AcceptanceRates { get; set; }
        public virtual DbSet<CompanionUser> CompanionUsers { get; set; }
        public virtual DbSet<DegreeList> DegreeLists { get; set; }
        public virtual DbSet<DegreeType> DegreeTypes { get; set; }
        public virtual DbSet<FinLimitList> FinLimitLists { get; set; }
        public virtual DbSet<PrivacyList> PrivacyLists { get; set; }
        public virtual DbSet<SearchResult> SearchResults { get; set; }
        public virtual DbSet<StateList> StateLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanionUser>()
                .HasMany(e => e.SearchResults)
                .WithOptional(e => e.CompanionUser)
                .WillCascadeOnDelete();
        }
    }
}
