namespace HotelBooking.Domain.Services;

using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Service interface for managing room-related business logic operations.
/// Handles room availability queries and identifier validation.
/// </summary>
public interface IRoomService
{
    /// <summary>
    /// Retrieves available rooms based on hotel, date range, and guest capacity criteria.
    /// Validates the query parameters and filters rooms that are not booked during the specified period.
    /// </summary>
    /// <param name="roomQuery">Query object containing hotel ID, date range, and guest capacity requirements.</param>
    /// <exception cref="ValidationException">Thrown when the room query validation fails.</exception>
    Task<IEnumerable<Room>> GetAvailableRooms(RoomQuery roomQuery);

    /// <summary>
    /// Validates whether a room with the specified identifier exists in the system.
    /// </summary>
    /// <param name="id">The unique identifier of the room to validate.</param>
    Task<bool> ValidateIdAsync(Guid id);
}