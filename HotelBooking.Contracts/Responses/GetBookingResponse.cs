namespace HotelBooking.Contracts.Responses;

/// <summary>
/// Response model containing detailed information about a booking.
/// </summary>
public class GetBookingResponse
{
    /// <summary>
    /// The unique identifier of the booking.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The date and time when the booking was created in the system.
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// The start date of the booking period.
    /// </summary>
    public DateTime StartingDate { get; set; }

    /// <summary>
    /// The end date of the booking period.
    /// </summary>
    public DateTime EndingDate { get; set; }

    /// <summary>
    /// The unique identifier of the room associated with this booking.
    /// </summary>
    public Guid RoomId { get; set; }
}