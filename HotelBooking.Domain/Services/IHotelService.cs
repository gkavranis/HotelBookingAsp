namespace HotelBooking.Domain.Services;

using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Service interface for managing hotel-related business logic operations.
/// Handles hotel retrieval and identifier validation.
/// </summary>
public interface IHotelService
{
    /// <summary>
    /// Retrieves a hotel by its unique identifier.
    /// Validates the ID before querying and includes associated room information in the result.
    /// </summary>
    /// <param name="id">The unique identifier of the hotel to retrieve.</param>
    /// <exception cref="ArgumentException">Thrown when the ID is empty.</exception>
    /// <exception cref="KeyNotFoundException">Thrown when no hotel with the specified ID exists.</exception>
    Task<Hotel> GetByIdAsync(Guid id);

    /// <summary>
    /// Retrieves hotels by name using case-insensitive partial matching.
    /// Searches for hotels whose names contain the specified search term.
    /// </summary>
    /// <param name="name">The name or partial name of the hotel to search for.</param>
    /// <exception cref="ValidationException">Thrown when the name validation fails.</exception>
    Task<IEnumerable<Hotel>> GetByNameAsync(string name);

    /// <summary>
    /// Validates that a hotel identifier is not empty.
    /// </summary>
    /// <param name="id">The hotel ID to validate.</param>
    /// <exception cref="ArgumentException">Thrown when the ID is empty.</exception>
    Task ValidateIdAsync(Guid id);
}
