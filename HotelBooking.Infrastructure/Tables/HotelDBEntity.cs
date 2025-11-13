namespace HotelBooking.Infrastructure.Tables;
internal class HotelDBEntity: DbEntity
{
    public required string Name { get; set; }

    public ICollection<RoomDbEntity> Rooms { get; set; } = new List<RoomDbEntity>();
}