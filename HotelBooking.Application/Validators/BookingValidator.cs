namespace HotelBooking.Application.Validators;

using FluentValidation;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Repositories;
using HotelBooking.Domain.Services;

public class BookingValidator : AbstractValidator<Booking>
{
    public BookingValidator(IBookingRepository bookingRepository, IRoomService roomService)
    {
        RuleFor(x => x.StartingDate)
            .NotEmpty()
            .WithMessage("Starting date is required.")
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("Starting date cannot be in the past.");

        RuleFor(x => x.EndingDate)
            .NotEmpty()
            .WithMessage("Ending date is required.")
            .GreaterThan(x => x.StartingDate)
            .WithMessage("Ending date must be after starting date.");

        RuleFor(x => x.Room)
            .NotNull()
            .WithMessage("Room is required.");

        RuleFor(x => x.Room.Id)
            .NotEmpty()
            .WithMessage("Room ID is required.")
            .MustAsync(async (roomId, _) => await roomService.ValidateIdAsync(roomId))
            .WithMessage("Room with the given ID does not exist.")
            .When(x => x.Room != null);

        // Minimum stay requirement
        RuleFor(x => x)
            .Must(x => (x.EndingDate - x.StartingDate).TotalDays >= 1)
            .WithMessage("Minimum stay is 1 night.")
            .When(x => x.EndingDate > x.StartingDate);

        // Check room availability
        RuleFor(booking => booking)
                .MustAsync(async (booking, _) => await bookingRepository.IsRoomAvailableAsync(
                        booking.Room.Id, booking.StartingDate, booking.EndingDate))
                .WithMessage("The room is already booked in the given interval.")
                .WithName("Booking");
    }
}