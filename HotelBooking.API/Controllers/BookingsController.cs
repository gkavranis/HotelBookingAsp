namespace HotelBooking.API.Controllers;

using AutoMapper;
using HotelBooking.Contracts.Responses;
using HotelBooking.Contracts.Requests;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Services;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// API controller for managing hotel bookings.
/// Provides endpoints for creating and retrieving booking information.
/// </summary>
[ApiController]
[Route("api/bookings")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;
    private readonly IRoomService _roomService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookingsController"/> class.
    /// </summary>
    /// <param name="bookingService">Service for handling booking business logic.</param>
    /// <param name="roomService">Service for handling room-related operations.</param>
    /// <param name="mapper">AutoMapper instance for object-to-object mapping.</param>
    public BookingsController(IBookingService bookingService, IRoomService roomService, IMapper mapper)
    {
        _bookingService = bookingService;
        _roomService = roomService;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new hotel booking for a specific room and date range.
    /// </summary>
    /// <param name="request">The booking request containing room ID, start date, and end date.</param>
    /// <param name="token">Optional cancellation token to cancel the operation.</param>
    [HttpPost]
    [ProducesResponseType(typeof(CreateBookingResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateBookingAsync([FromBody] CreateBookingRequest request, CancellationToken token)
    {
        var booking = _mapper.Map<Booking>(request);

        var result = await _bookingService.AddAsync(booking, token);

        if (result == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create booking.");
        }

        var response = _mapper.Map<CreateBookingResponse>(result);
        return Created($"/api/bookings/{result.Id}", response);
    }

    /// <summary>
    /// Retrieves a specific booking by its unique identifier.
    /// </summary>
    /// <param name="id">The GUID of the booking to retrieve.</param>
    /// <param name="token">Optional cancellation token to cancel the operation.</param>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(GetBookingResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBookingByIdAsync([FromRoute] Guid id, CancellationToken token)
    {
        var booking = await _bookingService.GetByIdAsync(id, token);
        
        if (booking == null)
        {
            return NotFound();
        }

        var response = _mapper.Map<GetBookingResponse>(booking);
        return Ok(response);
    }
}