namespace HotelBooking.Infrastructure.Repositories;

using HotelBooking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

/// <inheritdoc/>
internal class DataRepository : IDataRepository
{
    private readonly HotelBookingDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The <see cref="HotelBookingDbContext"/> for executing database operations.</param>
    public DataRepository(HotelBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task DeleteDatabaseAsync()
    {
        await _dbContext.Database.EnsureDeletedAsync();
    }

    /// <inheritdoc/>
    public async Task RunMigrationsAsync()
    {
        await _dbContext.Database.MigrateAsync();
    }
}
