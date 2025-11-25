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

    /// <inheritdoc/>
    public async Task<Hotel> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        await ValidateIdAsync(id, token);
        
        var hotel = await _hotelRepository.GetByIdAsync(id, token) ?? throw new KeyNotFoundException($"Hotel with ID {id} not found.");
        return hotel;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Hotel>> GetByNameAsync(string name, CancellationToken token = default)
    {
        await _hotelQueryValidator.ValidateAndThrowAsync(new HotelQuery { QueryName = name }, token);

        string searchPattern = name.Contains('*') ? name.Replace('*', '%') : name;

        return  await _hotelRepository.GetByNameAsync(searchPattern, token);
    }

    /// <inheritdoc/>
    public Task ValidateIdAsync(Guid id, CancellationToken token = default)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Hotel ID cannot be empty.", nameof(id));
        }

        return Task.CompletedTask;
    }
}