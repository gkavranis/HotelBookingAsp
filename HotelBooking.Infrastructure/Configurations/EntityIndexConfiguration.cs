namespace HotelBooking.Infrastructure.Configurations;

using HotelBooking.Infrastructure.Tables;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Configures database indexes for improved query performance.
/// </summary>
internal static class EntityIndexConfiguration
{
    /// <summary>
    /// Applies index configurations to all entities.
    /// </summary>
    public static ModelBuilder ConfigureIndexes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HotelDBEntity>()
            .HasIndex(h => h.Name)
            .HasDatabaseName("IX_Hotels_Name");

        modelBuilder.Entity<RoomDbEntity>()
            .HasIndex(r => r.HotelId)
            .HasDatabaseName("IX_Rooms_HotelId");

        modelBuilder.Entity<RoomDbEntity>()
            .HasIndex(r => r.Capacity)
            .HasDatabaseName("IX_Rooms_Capacity");

        // Composite index for the most common query pattern:
        modelBuilder.Entity<RoomDbEntity>()
            .HasIndex(r => new { r.HotelId, r.Capacity })
            .HasDatabaseName("IX_Rooms_HotelId_Capacity");

        // Foreign key index - for checking room availability
        modelBuilder.Entity<BookingDBEntity>()
            .HasIndex(b => b.RoomId)
            .HasDatabaseName("IX_Bookings_RoomId");

        // Date range index for availability queries
        modelBuilder.Entity<BookingDBEntity>()
            .HasIndex(b => new { b.StartingDate, b.EndingDate })
            .HasDatabaseName("IX_Bookings_DateRange");

        // Composite index for the availability check query
        modelBuilder.Entity<BookingDBEntity>()
            .HasIndex(b => new { b.RoomId, b.StartingDate, b.EndingDate })
            .HasDatabaseName("IX_Bookings_RoomId_DateRange");

        return modelBuilder;
    }
}