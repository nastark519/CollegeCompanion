namespace collegeCompanionApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CompaionContext : DbContext
    {
        public CompaionContext()
            : base("name=CompaionContext")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<CollegeFavorite> CollegeFavorites { get; set; }
        public virtual DbSet<Party> Parties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(e => e.CityName)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.CityState)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Colleges)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Party>()
                .Property(e => e.PartyEmail)
                .IsUnicode(false);
        }
    }
}
