namespace HotelBooking.Contracts.Requests;

using HotelBooking.Contracts.Attributes;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Request model for creating a new hotel booking.
/// </summary>
public class CreateBookingRequest
{
    /// <summary>
    /// The unique identifier of the room to be booked.
    /// </summary>
    public Guid RoomId { get; set; }

    /// <summary>
    /// Start date of the booking in ISO 8601 format (yyyy-MM-dd), e.g., 2025-12-01
    /// </summary>
    [Required]
    [Iso8601DateAttribute]
    public string FromDate { get; set; } = string.Empty;

    /// <summary>
    /// End date of the booking in ISO 8601 format (yyyy-MM-dd), e.g., 2025-12-05
    /// </summary>
    [Required]
    [Iso8601DateAttribute]
    public string ToDate { get; set; } = string.Empty;
}
