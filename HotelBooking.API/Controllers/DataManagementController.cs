namespace HotelBooking.API.Controllers;

using HotelBooking.Domain.Services;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// API controller for database management operations.
/// Provides endpoints for resetting and seeding the database with test data.
/// Intended for development and testing environments only.
/// </summary>
[ApiController]
[Route("api/data-management")]
public class DataManagementController : ControllerBase
{
    private readonly IDataService _dataService;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataManagementController"/> class.
    /// </summary>
    /// <param name="dataService">Service for handling database management operations.</param>
    public DataManagementController(IDataService dataService)
    {
        _dataService = dataService;
    }


    /// <summary>
    /// Resets the database by removing all data from tables
    /// </summary>
    [HttpPost("reset")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ResetDatabase()
    {
        // Clear all existing data from the database tables
        await _dataService.ResetDatabaseAsync();
        return Ok("Database has been reset.");
    }

    /// <summary>
    /// Seeds the database with test data
    /// </summary>
    [HttpPost("seed")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SeedDatabase()
    {
        // Populate the database with predefined test data
        await _dataService.SeedDatabaseAsync();
        return Ok("Database has been seeded with test data.");
    }

    /// <summary>
    /// Resets and seeds the database in one operation
    /// </summary>
    [HttpPost("reset-and-seed")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ResetAndSeedDatabase()
    {
        // Clear existing data and repopulate with fresh test data in a single operation
        await _dataService.ResetAndSeedDatabaseAsync();
        return Ok("Database has been reset and seeded with test data.");
    }
}