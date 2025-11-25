namespace HotelBooking.Application.Services;

using FluentValidation;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Repositories;
using HotelBooking.Domain.Services;
using System;
using System.Threading.Tasks;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IRoomService _roomService;
    private readonly IValidator<Booking> _validator;

    public BookingService(IBookingRepository bookingRepository, IRoomService roomService, IValidator<Booking> validator)
    {
        _bookingRepository = bookingRepository;
        _roomService = roomService;
        _validator = validator;
    }

    /// <inheritdoc/>
    public async Task<Booking?> AddAsync(Booking booking, CancellationToken token = default)
    {
        await _validator.ValidateAndThrowAsync(booking, token);

        return await _bookingRepository.AddAsync(booking, token);
    }

    /// <inheritdoc/>
    public async Task<Booking?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _bookingRepository.GetByIdAsync(id, token);
    }

    /// <inheritdoc/>
    public async Task<bool> IsRoomAvailableAsync(Guid roomId, DateTime fromDate, DateTime toDate, CancellationToken token = default)
    {
        await _roomService.ValidateIdAsync(roomId, token);
        return await _bookingRepository.IsRoomAvailableAsync(roomId, fromDate, toDate, token);
    }
}