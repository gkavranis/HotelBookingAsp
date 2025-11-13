namespace HotelBooking.Domain.Entities;

public class Room 
{
    public Guid Id { get; set; }

    public int Number { get; set; }

    public required string Type { get; set; }

    public int Capacity { get; set; }
}
