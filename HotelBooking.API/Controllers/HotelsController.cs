namespace HotelBooking.API.Controllers;

using AutoMapper;
using HotelBooking.Contracts.Responses;
using HotelBooking.Domain.Services;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// API controller for managing hotel information.
/// Provides endpoints for retrieving and searching hotel data.
/// </summary>
[ApiController]
[Route("api/hotels")]
public class HotelsController : ControllerBase
{
    private readonly IHotelService _hotelService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="HotelsController"/> class.
    /// </summary>
    /// <param name="hotelService">Service for handling hotel business logic.</param>
    /// <param name="mapper">AutoMapper instance for object-to-object mapping.</param>
    public HotelsController(IHotelService hotelService, IMapper mapper)
    {
        _hotelService = hotelService;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves hotels by name using a case-insensitive search.
    /// Supports wildcard matching to find hotels containing the specified name.
    /// </summary>
    /// <param name="name">The name or wildcard pattern of the hotel to search for.</param>
    [HttpGet("by-name/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByNameAsync(string name)
    {
        
        var hotels = await _hotelService.GetByNameAsync(name);

        return Ok(_mapper.Map<IEnumerable<GetHotelResponse>>(hotels));
    }

}
