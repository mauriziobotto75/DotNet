 csharp Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace MyApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Immobile> Immobili { get; set; }
        public DbSet<Spesa> Spese { get; set; }
        public DbSet<Contatto> Contatti { get; set; }
        public DbSet<Bolletta> Bollette { get; set; }
        public DbSet<AgendaItem> Agenda { get; set; }
        public DbSet<Parcella> Parcelle { get; set; }
        public DbSet<Sollecito> Solleciti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace with your SQL Server connection string
            optionsBuilder.UseSqlServer("Server=.;Database=Amministratori;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure relationships/indexes if necessary
            base.OnModelCreating(modelBuilder);
        }
    }
}
