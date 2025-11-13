namespace HotelBooking.Contracts.Requests;

/// <summary>
/// Request model for creating a new hotel in the system.
/// Contains the basic information required to register a hotel.
/// </summary>
public class CreateHotelRequest
{
    /// <summary>
    /// The name of the hotel to be created.
    /// </summary>
    public required string Name { get; set; }

}
