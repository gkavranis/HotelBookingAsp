namespace HotelBooking.Domain.Services;

using HotelBooking.Domain.Entities;
using System;
using System.Threading.Tasks;

/// <summary>
/// Service interface for managing booking business logic operations.
/// </summary>
public interface IBookingService
{
    /// <summary>
    /// Creates a new booking in the system.
    /// Validates the booking details and persists the booking information including room assignment and date range.
    /// </summary>
    /// <param name="booking">The booking entity to be created containing room, start date, and end date.</param>
    /// <param name="token">Optional cancellation token to cancel the operation.</param>
    Task<Booking?> AddAsync(Booking booking, CancellationToken token = default);

    /// <summary>
    /// Retrieves a booking by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the booking to retrieve.</param>
    /// <param name="token">Optional cancellation token to cancel the operation.</param>
    Task<Booking?> GetByIdAsync(Guid id, CancellationToken token = default);

    /// <summary>
    /// Checks if a room is available for booking during the specified date range.
    /// Verifies that no existing bookings conflict with the requested period.
    /// </summary>
    /// <param name="roomId">The unique identifier of the room to check.</param>
    /// <param name="fromDate">The start date of the requested booking period.</param>
    /// <param name="toDate">The end date of the requested booking period.</param>
    /// <param name="token">Optional cancellation token to cancel the operation.</param>
    Task<bool> IsRoomAvailableAsync(Guid roomId, DateTime fromDate, DateTime toDate, CancellationToken token = default);
}

