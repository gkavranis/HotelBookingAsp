namespace HotelBooking.Contracts.Responses;

/// <summary>
/// Response model containing detailed information about a hotel.
/// </summary>
public class GetHotelResponse
{
    /// <summary>
    /// The unique identifier of the hotel.
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// The name of the hotel.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Collection of rooms belonging to this hotel.
    /// </summary>
    public List<GetAvailableRoomsResponse> Rooms { get; init; } = [];
}