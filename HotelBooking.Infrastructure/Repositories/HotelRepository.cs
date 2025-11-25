namespace HotelBooking.Infrastructure.Repositories;

using AutoMapper;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

/// <inheritdoc/>
internal class HotelRepository : IHotelRepository
{
    private readonly HotelBookingDbContext _dbContext;
    private readonly IMapper _mapper;

    public HotelRepository(
        HotelBookingDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<Hotel> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return _mapper.Map<Hotel>(
            await _dbContext.Hotels
            .Include(h => h.Rooms)
            .FirstOrDefaultAsync(x => x.Id == id, token));
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Hotel>> GetByNameAsync(string name, CancellationToken token = default)
    {
        var hotelEntities = await _dbContext.Hotels.Include(r=> r.Rooms).Where(h => EF.Functions.Like(h.Name, $"%{name}%")).ToListAsync(token);
        return _mapper.Map<IEnumerable<Hotel>>(hotelEntities);
    }
}
