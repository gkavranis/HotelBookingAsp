namespace HotelBooking.Infrastructure.Tables;
internal class RoomDbEntity : DbEntity
{
    public required int Number { get; set; }

    public required string Type { get; set; }

    public int Capacity { get; set; }

    public Guid HotelId { get; set; }
    
    public HotelDBEntity Hotel { get; set; } = null!;

    public List<BookingDBEntity> Bookings { get; } = new();
}