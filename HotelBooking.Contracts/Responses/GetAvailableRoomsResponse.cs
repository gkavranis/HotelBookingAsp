namespace HotelBooking.Contracts.Responses;

/// <summary>
/// Response model containing information about an available room.
/// </summary>
public class GetAvailableRoomsResponse
{
    /// <summary>
    /// The unique identifier of the room.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The room number within the hotel.
    /// </summary>
    public required int Number { get; init; }

    /// <summary>
    /// The type or category of the room (e.g., "Single", "Double", "Suite").
    /// </summary>
    public required string Type { get; init; }

    /// <summary>
    /// The maximum number of guests the room can accommodate.
    /// </summary>
    public required int Capacity { get; init; }
}