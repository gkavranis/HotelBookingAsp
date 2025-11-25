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

    /// <inheritdoc/>
    public async Task<IEnumerable<Room>> GetAvailableRooms(RoomQuery roomQuery, CancellationToken token = default)
    {
        await _roomQueryValidator.ValidateAndThrowAsync(roomQuery, token);
        return await _roomRepository.GetAvailableRoomAsync(roomQuery, token);
    }

    /// <inheritdoc/>
    public Task<bool> ValidateIdAsync(Guid id, CancellationToken token = default) => _roomRepository.ExistsAsync(id, token);
}