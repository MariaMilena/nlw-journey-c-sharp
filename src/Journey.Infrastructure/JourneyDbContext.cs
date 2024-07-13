using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Infrastructure;

public class JourneyDbContext : DbContext
{
    public DbSet<Trip> Trips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=D:\\Github\\nlw-journey-c-sharp\\src\\Journey.Infrastructure\\JourneyDatabase.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar relacionamento
        modelBuilder.Entity<Trip>()
            .HasMany(t => t.Activities)
            .WithOne()
            .HasForeignKey(a => a.TripId);

        // Chamar método de seeding
        DataSeeder.Seed(modelBuilder);
    }
}
