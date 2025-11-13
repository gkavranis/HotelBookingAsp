namespace HotelBooking.Domain.Repositories;

using HotelBooking.Domain.Entities;
using System;
using System.Threading.Tasks;

/// <summary>
/// Repository interface for managing booking data persistence operations.
/// </summary>
public interface IBookingRepository
{
    /// <summary>
    /// Creates a new booking in the data store.
    /// Persists the booking information including room assignment and date range.
    /// </summary>
    /// <param name="booking">The booking entity to be created containing room, start date, and end date.</param>
    Task<Booking?> AddAsync(Booking booking);

    /// <summary>
    /// Retrieves a booking by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the booking to retrieve.</param>
    Task<Booking?> GetByIdAsync(Guid id);
    
    /// <summary>
    /// Checks if a room is available for booking during the specified date range.
    /// Verifies that no existing bookings conflict with the requested period.
    /// </summary>
    /// <param name="roomId">The unique identifier of the room to check.</param>
    /// <param name="fromDate">The start date of the requested booking period.</param>
    /// <param name="toDate">The end date of the requested booking period.</param>
    Task<bool> IsRoomAvailableAsync(Guid roomId, DateTime fromDate, DateTime toDate);
}