using HotelBooking.Infrastructure.Configurations;

namespace HotelBooking.Infrastructure;

using HotelBooking.Domain;
using HotelBooking.Infrastructure.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            .SeedData();
            //.ConfigureTables()
            //.ConfigureRelations()
    }
}
