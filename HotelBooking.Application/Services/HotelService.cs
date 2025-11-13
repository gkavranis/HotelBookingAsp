namespace HotelBooking.Application.Services;

using FluentValidation;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Repositories;
using HotelBooking.Domain.Services;

/// <summary>
/// Service for managing hotel-related business logic operations.
/// Provides methods for retrieving hotel information with validation.
/// </summary>
public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IValidator<HotelQuery> _hotelQueryValidator;

    /// <summary>
    /// Initializes a new instance of the <see cref="HotelService"/> class.
    /// </summary>
    /// <param name="hotelRepository">Repository for accessing hotel data.</param>
    /// <param name="hotelQueryValidator">Validator for hotel query operations.</param>
    public HotelService(IHotelRepository hotelRepository, IValidator<HotelQuery> hotelQueryValidator)
    {
        _hotelRepository = hotelRepository;
        _hotelQueryValidator = hotelQueryValidator;
    }

    /// <summary>
    /// Retrieves a hotel by its unique identifier.
    /// Validates the ID before querying and throws an exception if the hotel is not found.
    /// </summary>
    /// <param name="id">The unique identifier of the hotel.</param>
    /// <exception cref="KeyNotFoundException">Thrown when no hotel with the specified ID exists.</exception>
    public async Task<Hotel> GetByIdAsync(Guid id)
    {
        await ValidateIdAsync(id);
        
        var hotel = await _hotelRepository.GetByIdAsync(id);
        
        if (hotel == null)
        {
            throw new KeyNotFoundException($"Hotel with ID {id} not found.");
        }
        
        return hotel;
    }

    /// <summary>
    /// Retrieves hotels by name using case-insensitive wildcard matching.
    /// Validates the query before executing the search.
    /// </summary>
    /// <param name="name">The name or partial name of the hotel to search for.</param>
    /// <exception cref="ValidationException">Thrown when the query validation fails.</exception>
    public async Task<IEnumerable<Hotel>> GetByNameAsync(string name)
    {
        _hotelQueryValidator.ValidateAndThrow(new HotelQuery { QueryName = name });

        string searchPattern = name.Contains('*') ? name.Replace('*', '%') : name;

        return  await _hotelRepository.GetByNameAsync(searchPattern);
    }

    /// <summary>
    /// Validates that a hotel ID is not empty.
    /// </summary>
    /// <param name="id">The hotel ID to validate.</param>
    /// <exception cref="ArgumentException">Thrown when the ID is empty.</exception>
    public Task ValidateIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Hotel ID cannot be empty.", nameof(id));
        }

        return Task.CompletedTask;
    }
}