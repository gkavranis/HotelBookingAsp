namespace HotelBooking.Infrastructure.Repositories;

using AutoMapper;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <inheritdoc/>
internal class RoomRepository : IRoomRepository
{
    private readonly HotelBookingDbContext _dbContext;
    private readonly IMapper _mapper;

    public RoomRepository(HotelBookingDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Room>> GetAvailableRoomAsync(RoomQuery roomQuery)
    {
        var requestedFromDate = roomQuery.FromDate;
        var requestedToDate = roomQuery.ToDate;

        var rooms = await _dbContext.Rooms
            .Include(r => r.Bookings)
            .Where(r => r.HotelId == roomQuery.HotelId)
            .Where(r => r.Capacity >= roomQuery.Guests)
            .Where(r => !r.Bookings.Any(b => b.StartingDate < requestedToDate && b.EndingDate > requestedFromDate))
            .ToListAsync();

        return _mapper.Map<IEnumerable<Room>>(rooms);
    }

    /// <inheritdoc/>
    public Task<bool> ExistsAsync(Guid id) =>
            _dbContext.Rooms.AnyAsync(room => room.Id == id);
}
