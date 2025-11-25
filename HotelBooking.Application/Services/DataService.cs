namespace HotelBooking.Application.Services;

using HotelBooking.Domain.Repositories;
using HotelBooking.Domain.Services;
using System.Threading.Tasks;

/// <summary>
/// Service for managing database operations including reset, seed, and migration tasks.
/// Provides high-level orchestration of database management operations for development and testing purposes.
/// </summary>
public class DataService : IDataService
{
    private readonly IDataRepository _dataRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataService"/> class.
    /// </summary>
    /// <param name="dataRepository">Repository for executing database operations.</param>
    public DataService(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }

    /// <inheritdoc/>
    public async Task ResetAndSeedDatabaseAsync(CancellationToken token = default)
    {
        await ResetDatabaseAsync(token);
        await SeedDatabaseAsync(token);
    }

    /// <inheritdoc/>
    public async Task ResetDatabaseAsync(CancellationToken token = default)
    {
        await _dataRepository.DeleteDatabaseAsync(token);
    }

    /// <inheritdoc/>
    public async Task SeedDatabaseAsync(CancellationToken token = default)
    {
        await _dataRepository.RunMigrationsAsync(token);
    }
}
