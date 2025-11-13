namespace HotelBooking.Infrastructure.Tables;

internal class BookingDBEntity: DbEntity
{
    public DateTime CreationDate { get; set; } = DateTime.MinValue;

    public DateTime StartingDate { get; set; } = DateTime.MinValue;

    public DateTime EndingDate { get; set; } = DateTime.MinValue;

    public RoomDbEntity Room { get; set; } = null!;

    public Guid RoomId { get; set; }
}