namespace HotelBooking.Application.Services;

using FluentValidation;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Repositories;
using HotelBooking.Domain.Services;
using System.Collections.Generic;

/// <summary>
/// Service for managing room-related business logic operations.
/// Provides methods for checking room availability and validating room identifiers.
/// </summary>
public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IValidator<RoomQuery> _roomQueryValidator;

    /// <summary>
    /// Initializes a new instance of the <see cref="RoomService"/> class.
    /// </summary>
    /// <param name="roomRepository">Repository for accessing room data.</param>
    /// <param name="roomQueryValidator">Validator for room query operations.</param>
    public RoomService(IRoomRepository roomRepository, IValidator<RoomQuery> roomQueryValidator)
    {
        _roomRepository = roomRepository;
        _roomQueryValidator = roomQueryValidator;
    }

    /// <summary>
    /// Retrieves available rooms based on hotel, date range, and guest capacity criteria.
    /// Validates the query parameters before executing the search.
    /// </summary>
    /// <param name="roomQuery">Query object containing hotel ID, date range, and number of guests.</param>
    /// <exception cref="ValidationException">Thrown when the room query validation fails.</exception>
    public Task<IEnumerable<Room>> GetAvailableRooms(RoomQuery roomQuery)
    {
        _roomQueryValidator.ValidateAndThrow(roomQuery);
        return  _roomRepository.GetAvailableRoomAsync(roomQuery);
    }

    /// <summary>
    /// Validates whether a room with the specified identifier exists in the system.
    /// </summary>
    /// <param name="id">The unique identifier of the room to validate.</param>
    public Task<bool> ValidateIdAsync(Guid id) => _roomRepository.ExistsAsync(id);
}