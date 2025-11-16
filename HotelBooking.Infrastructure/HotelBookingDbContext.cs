using HotelBooking.Infrastructure.Configurations;

namespace HotelBooking.Infrastructure;

using HotelBooking.Infrastructure.Tables;
using Microsoft.EntityFrameworkCore;

internal class HotelBookingDbContext : DbContext
{
    public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options)
        : base(options)
    {
    }


    public DbSet<HotelDBEntity> Hotels { get; set; }
    public DbSet<RoomDbEntity> Rooms { get; set; }
    public DbSet<BookingDBEntity> Bookings { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{

    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ConfigureIndexes()
            .SeedData();
    }
}
