namespace HotelBooking.Contracts.Responses;

/// <summary>
/// Response model returned after successfully creating a booking.
/// </summary>
public class CreateBookingResponse
{
    /// <summary>
    /// The unique identifier of the newly created booking.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The date and time when the booking was created in the system.
    /// </summary>
    public DateTime CreationDate { get; set; }
}