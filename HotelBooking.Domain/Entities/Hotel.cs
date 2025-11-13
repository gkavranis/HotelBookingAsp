namespace HotelBooking.Domain.Entities;

public class Hotel 
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required List<Room> Rooms { get; set; }

}
