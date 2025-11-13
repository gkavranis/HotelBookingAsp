namespace HotelBooking.Contracts.Requests;

/// <summary>
/// Request model for creating a new room in a hotel.
/// </summary>
public class CreateRoomRequest
{
    /// <summary>
    /// The room number identifier within the hotel.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// The type or category of the room (e.g., "Single", "Double", "Suite").
    /// </summary>
    public required string Type { get; set; }

    /// <summary>
    /// The maximum number of guests the room can accommodate.
    /// </summary>
    public int Capacity { get; set; }

    /// <summary>
    /// The unique identifier of the hotel to which this room belongs.
    /// </summary>
    public Guid HotelId { get; set; }

}
