namespace HotelBooking.Contracts.Requests;

using HotelBooking.Contracts.Attributes;

/// <summary>
/// Request model for querying available rooms based on hotel, date range, and guest capacity.
/// Used to search for rooms that are not booked during the specified period.
/// </summary>
public class GetAvailableRoomsRequest
{
    /// <summary>
    /// The unique identifier of the hotel to search for available rooms.
    /// </summary>
    public Guid HotelId { get; set; }

    /// <summary>
    /// Start date of the desired booking period in ISO 8601 format (yyyy-MM-dd), e.g., 2025-12-01
    /// </summary>
    [Iso8601DateAttribute]
    public required string FromDate { get; set; }

    /// <summary>
    /// End date of the desired booking period in ISO 8601 format (yyyy-MM-dd), e.g., 2025-12-05
    /// </summary>
    [Iso8601DateAttribute]
    public required string ToDate { get; set; }

    /// <summary>
    /// The number of guests that need to be accommodated.
    /// Used to filter rooms by their capacity.
    /// </summary>
    public int Guests { get; set; }
    
}