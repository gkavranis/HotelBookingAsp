namespace HotelBooking.Domain.Repositories;

using HotelBooking.Domain.Entities;
using System;

/// <summary>
/// Repository interface for managing room data persistence operations.
/// </summary>
public interface IRoomRepository
{
    /// <summary>
    /// Checks whether a room with the specified identifier exists in the data store.
    /// </summary>
    /// <param name="id">The unique identifier of the room to check.</param>
    /// <param name="token">Optional cancellation token to cancel the operation.</param>
    Task<bool> ExistsAsync(Guid id, CancellationToken token = default);

    /// <summary>
    /// Retrieves available rooms based on hotel, date range, and guest capacity criteria.
    /// Filters rooms that are not booked during the specified period and can accommodate the requested number of guests.
    /// </summary>
    /// <param name="roomQuery">Query object containing hotel ID, date range, and guest capacity requirements.</param>
    /// <param name="token">Optional cancellation token to cancel the operation.</param>
    Task<IEnumerable<Room>> GetAvailableRoomAsync(RoomQuery roomQuery, CancellationToken token = default);
}