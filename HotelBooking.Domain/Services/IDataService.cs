namespace HotelBooking.Domain.Services;

using System;
using System.Threading.Tasks;

/// <summary>
/// Service interface for managing database maintenance operations.
/// Intended for development and testing environments only.
/// </summary>
public interface IDataService
{
    /// <summary>
    /// Resets the database by removing all data from tables.
    /// Deletes the database entirely to ensure a clean state.
    /// </summary>
    /// <param name="token">Optional cancellation token to cancel the operation.</param>
    Task ResetDatabaseAsync(CancellationToken token = default);

    /// <summary>
    /// Seeds the database with test data.
    /// Applies any pending migrations and populates tables with predefined data.
    /// </summary>
    /// <param name="token">Optional cancellation token to cancel the operation.</param>
    Task SeedDatabaseAsync(CancellationToken token = default);

    /// <summary>
    /// Resets and seeds the database in a single operation.
    /// First removes all existing data, then applies migrations and populates with test data.
    /// </summary>
    /// <param name="token">Optional cancellation token to cancel the operation.</param>
    Task ResetAndSeedDatabaseAsync(CancellationToken token = default);

}

