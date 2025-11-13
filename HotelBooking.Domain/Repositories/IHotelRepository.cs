namespace HotelBooking.Domain.Repositories;

using HotelBooking.Domain.Entities;

/// <summary>
/// Repository interface for managing hotel data persistence operations.
/// </summary>
public interface IHotelRepository
{
    /// <summary>
    /// Retrieves a hotel by its unique identifier.
    /// Includes associated room information in the result.
    /// </summary>
    /// <param name="id">The unique identifier of the hotel to retrieve.</param>
    Task<Hotel> GetByIdAsync(Guid id);

    /// <summary>
    /// Retrieves hotels by name using case-insensitive partial matching.
    /// Searches for hotels whose names contain the specified search term.
    /// </summary>
    /// <param name="name">The name or partial name of the hotel to search for.</param>
    Task<IEnumerable<Hotel>> GetByNameAsync(string name);
}