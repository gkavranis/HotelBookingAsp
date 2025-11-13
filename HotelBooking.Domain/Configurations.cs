namespace HotelBooking.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Configuration class for managing database connection strings.
/// Bound to the application configuration section via the Options pattern.
/// </summary>
public class ConnectionStrings
{
    /// <summary>
    /// The connection string for the SQL Server database.
    /// Used by <see cref="Microsoft.EntityFrameworkCore.DbContext"/> to establish database connections.
    /// </summary>
    public string SqlServer { get; init; } = string.Empty;
}