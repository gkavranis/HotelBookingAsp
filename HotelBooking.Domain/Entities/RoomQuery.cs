namespace HotelBooking.Domain.Entities;

public class RoomQuery
{
    public Guid HotelId { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public int Guests { get; set; }
}