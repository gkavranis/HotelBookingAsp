namespace HotelBooking.Domain.Repositories;

using HotelBooking.Domain.Entities;
using System;

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
    Task DeleteDatabaseAsync();

    /// <summary>
    /// Applies pending Entity Framework migrations to the database.
    /// Creates or updates the database schema and seeds initial data if configured.
    /// </summary>
    Task RunMigrationsAsync();

}