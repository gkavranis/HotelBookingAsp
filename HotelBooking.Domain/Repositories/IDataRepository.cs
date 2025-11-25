namespace HotelBooking.Domain.Repositories;

/// <summary>
/// Repository interface for managing database-level operations.
/// Provides methods for database maintenance, including deletion and migration execution.
/// Intended for development and testing scenarios.
/// </summary>
public interface IDataRepository
{
    /// <summary>
    /// Deletes the entire database, removing all tables and data.
    /// This operation is destructive and cannot be undone.
    /// </summary>
    /// <param name="token">Optional cancellation token to cancel the operation.</param>
    Task DeleteDatabaseAsync(CancellationToken token = default);

    /// <summary>
    /// Applies pending Entity Framework migrations to the database.
    /// Creates or updates the database schema and seeds initial data if configured.
    /// </summary>
    /// <param name="token">Optional cancellation token to cancel the operation.</param>
    Task RunMigrationsAsync(CancellationToken token = default);

}