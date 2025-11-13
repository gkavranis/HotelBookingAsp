namespace HotelBooking.API.Controllers;

using AutoMapper;
using HotelBooking.Contracts.Requests;
using HotelBooking.Contracts.Responses;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Services;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// API controller for managing hotel room operations.
/// Provides endpoints for querying room availability and information.
/// </summary>
[ApiController]
[Route("api/rooms")]
public class RoomsController : ControllerBase
{
    private readonly IRoomService _roomService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="RoomsController"/> class.
    /// </summary>
    /// <param name="roomService">Service for handling room business logic and availability checks.</param>
    /// <param name="mapper">AutoMapper instance for object-to-object mapping.</param>
    public RoomsController(IRoomService roomService, IMapper mapper)
    {   
        _roomService = roomService;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves available rooms based on hotel, date range, and guest capacity.
    /// Searches for rooms that are not booked during the specified period and can accommodate the requested number of guests.
    /// </summary>
    /// <param name="request">The query parameters containing hotel ID, date range (ISO 8601 format), and number of guests.</param>
    [HttpGet("available")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAvailableRoomsAsync([FromQuery] GetAvailableRoomsRequest request)
    {
        var roomQuery = _mapper.Map<RoomQuery>(request);

        var availableRooms = await _roomService.GetAvailableRooms(roomQuery);
        return Ok(_mapper.Map<IEnumerable<GetAvailableRoomsResponse>>(availableRooms));
    }
}