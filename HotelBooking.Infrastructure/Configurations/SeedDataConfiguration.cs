namespace HotelBooking.Infrastructure.Configurations;

using HotelBooking.Infrastructure.Tables;
using Microsoft.EntityFrameworkCore;

internal static class SeedDataConfiguration
{
    public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
    {
        var hotel1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var hotel2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");

        modelBuilder.Entity<HotelDBEntity>().HasData(
            new HotelDBEntity { Id = hotel1Id, Name = "Grand Plaza Hotel" },
            new HotelDBEntity { Id = hotel2Id, Name = "Seaside Resort" }
        );

        // Hotel 1 rooms
        var room1Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
        var room2Id = Guid.Parse("44444444-4444-4444-4444-444444444444");
        var room3Id = Guid.Parse("55555555-5555-5555-5555-555555555555");
        var room4Id = Guid.Parse("66666666-6666-6666-6666-666666666666");
        var room5Id = Guid.Parse("77777777-7777-7777-7777-777777777777");
        var room6Id = Guid.Parse("88888888-8888-8888-8888-888888888888");

        // Hotel 2 rooms
        var room7Id = Guid.Parse("99999999-9999-9999-9999-999999999999");
        var room8Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        var room9Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        var room10Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
        var room11Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");
        var room12Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");

        modelBuilder.Entity<RoomDbEntity>().HasData(
            // Grand Plaza Hotel rooms
            new RoomDbEntity { Id = room1Id, Number = 101, Type = "Double", Capacity = 2, HotelId = hotel1Id },
            new RoomDbEntity { Id = room2Id, Number = 102, Type = "Double", Capacity = 2, HotelId = hotel1Id },
            new RoomDbEntity { Id = room3Id, Number = 103, Type = "Double", Capacity = 2, HotelId = hotel1Id },
            new RoomDbEntity { Id = room4Id, Number = 104, Type = "Double", Capacity = 2, HotelId = hotel1Id },
            new RoomDbEntity { Id = room5Id, Number = 105, Type = "Deluxe", Capacity = 2, HotelId = hotel1Id },
            new RoomDbEntity { Id = room6Id, Number = 106, Type = "Deluxe", Capacity = 2, HotelId = hotel1Id },

            // Seaside Resort rooms
            new RoomDbEntity { Id = room7Id, Number = 201, Type = "Single", Capacity = 1, HotelId = hotel2Id },
            new RoomDbEntity { Id = room8Id, Number = 202, Type = "Single", Capacity = 1, HotelId = hotel2Id },
            new RoomDbEntity { Id = room9Id, Number = 203, Type = "Double", Capacity = 2, HotelId = hotel2Id },
            new RoomDbEntity { Id = room10Id, Number = 204, Type = "Double", Capacity = 2, HotelId = hotel2Id },
            new RoomDbEntity { Id = room11Id, Number = 205, Type = "Double", Capacity = 2, HotelId = hotel2Id },
            new RoomDbEntity { Id = room12Id, Number = 206, Type = "Double", Capacity = 2, HotelId = hotel2Id }
        );

        modelBuilder.Entity<BookingDBEntity>().HasData(
            new BookingDBEntity
            {
                Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                CreationDate = new DateTime(2025, 11, 9),
                StartingDate = new DateTime(2025, 11, 16),
                EndingDate = new DateTime(2025, 11, 19),
                RoomId = room1Id
            },
            new BookingDBEntity
            {
                Id = Guid.Parse("0dcbc9c6-c37e-4ac6-bc3f-9aed741cbda7"),
                CreationDate = new DateTime(2025, 11, 3),
                StartingDate = new DateTime(2025, 11, 13),
                EndingDate = new DateTime(2025, 11, 23),
                RoomId = room10Id
            }

        );

        return modelBuilder;
    }
}