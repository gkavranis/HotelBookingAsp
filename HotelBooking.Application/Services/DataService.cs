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

    /// <summary>
    /// Resets and seeds the database in a single operation.
    /// First removes all existing data, then applies migrations and populates with seed data.
    /// </summary>
    public async Task ResetAndSeedDatabaseAsync()
    {
        await ResetDatabaseAsync();
        await SeedDatabaseAsync();
    }

    /// <summary>
    /// Resets the database by removing all data from tables.
    /// Deletes the database entirely to ensure a clean state.
    /// </summary>
    public async Task ResetDatabaseAsync()
    {
        await _dataRepository.DeleteDatabaseAsync();
    }

    /// <summary>
    /// Seeds the database with test data.
    /// Applies any pending migrations and populates tables with predefined data.
    /// </summary>
    public async Task SeedDatabaseAsync()
    {
        await _dataRepository.RunMigrationsAsync();
    }
}
