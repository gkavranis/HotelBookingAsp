namespace HotelBooking.Domain.Entities;

using System;

public class Booking 
{
    public Guid Id { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime EndingDate { get; set; }

    public required Room Room { get; set; }
}
