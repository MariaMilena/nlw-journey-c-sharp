using Journey.Infrastructure.Entities;
using Journey.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;

public static class DataSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var tripId = Guid.NewGuid();
        var activityId = Guid.NewGuid();

        var trip1 = new Trip
        {
            Id = Guid.NewGuid(),
            Name = "Viagem a Paris",
            StartDate = new DateTime(2024, 7, 1),
            EndDate = new DateTime(2024, 7, 10)
        };

        var trip2 = new Trip
        {
            Id = Guid.NewGuid(),
            Name = "Viagem ao Japão",
            StartDate = new DateTime(2024, 8, 15),
            EndDate = new DateTime(2024, 8, 25)
        };

        modelBuilder.Entity<Activity>().HasData(new Activity
        {
            Id = Guid.NewGuid(),
            Name = "Visita a Kyoto",
            Date = new DateTime(2024, 8, 20),
            Status = ActivityStatus.Pending,
            TripId = trip1.Id
        });

        modelBuilder.Entity<Activity>().HasData(new Activity
        {
            Id = Guid.NewGuid(),
            Name = "Visita a Torre Eiffel",
            Date = new DateTime(2024, 7, 2),
            Status = ActivityStatus.Pending,
            TripId = trip1.Id
        });

        modelBuilder.Entity<Activity>().HasData(new Activity
        {
            Id = Guid.NewGuid(),
            Name = "Cruzamento no Rio Sena",
            Date = new DateTime(2024, 7, 6),
            Status = ActivityStatus.Pending,
            TripId = trip1.Id
        });

        modelBuilder.Entity<Activity>().HasData(new Activity
        {
            Id = Guid.NewGuid(),
            Name = "Visita a Tokyo Tower",
            Date = new DateTime(2024, 7, 6),
            Status = ActivityStatus.Pending,
            TripId = trip2.Id
        });

        modelBuilder.Entity<Activity>().HasData(new Activity
        {
            Id = Guid.NewGuid(),
            Name = "Passeio em Shibuya",
            Date = new DateTime(2024, 7, 6),
            Status = ActivityStatus.Pending,
            TripId = trip2.Id
        });

        modelBuilder.Entity<Activity>().HasData(new Activity
        {
            Id = Guid.NewGuid(),
            Name = "Visita a Kyoto",
            Date = new DateTime(2024, 7, 6),
            Status = ActivityStatus.Pending,
            TripId = trip2.Id
        });

        // Adicionar dados ao ModelBuilder
        modelBuilder.Entity<Trip>().HasData(trip1, trip2);
    }
}
