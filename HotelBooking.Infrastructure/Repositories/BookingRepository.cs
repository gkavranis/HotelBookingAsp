namespace HotelBooking.Infrastructure.Repositories;

using AutoMapper;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Repositories;
using HotelBooking.Infrastructure.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Repository implementation for managing booking data persistence operations.
/// Handles database interactions for creating, retrieving, and validating room availability for bookings.
/// </summary>
internal class BookingRepository : IBookingRepository
{
    private readonly HotelBookingDbContext _dbContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookingRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The <see cref="HotelBookingDbContext"/> for accessing booking data.</param>
    /// <param name="mapper">The <see cref="IMapper"/> instance for mapping.</param>
    public BookingRepository(HotelBookingDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<Booking?> AddAsync(Booking booking)
    {
        var bookingDbEntity = _mapper.Map<BookingDBEntity>(booking);
        bookingDbEntity.CreationDate = DateTime.Now;
        bookingDbEntity.Id = Guid.NewGuid();
        var result = await _dbContext.Bookings.AddAsync(bookingDbEntity);
        await _dbContext.SaveChangesAsync();
        return bookingDbEntity == null ? null : _mapper.Map<Booking>(bookingDbEntity);
    }

    /// <inheritdoc/>
    public async Task<Booking?> GetByIdAsync(Guid id)
    {
        var bookingDbEntity = await _dbContext.Bookings
            .Include(b => b.Room)
            .FirstOrDefaultAsync(b => b.Id == id);

        return bookingDbEntity == null ? null : _mapper.Map<Booking>(bookingDbEntity);
    }

    /// <inheritdoc/>
    public async Task<bool> IsRoomAvailableAsync(Guid roomId, DateTime fromDate, DateTime toDate)
    {
        var hasOverlappingBookings = await _dbContext.Bookings
            .Where(b => b.RoomId == roomId)
            .AnyAsync(b => b.StartingDate < toDate && b.EndingDate > fromDate);

        return !hasOverlappingBookings;
    }
}