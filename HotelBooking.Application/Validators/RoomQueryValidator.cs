namespace HotelBooking.Application.Validators;

using FluentValidation;
using HotelBooking.Domain.Entities;

public class RoomQueryValidator : AbstractValidator<RoomQuery>
{
    public RoomQueryValidator()
    {
        RuleFor(x => x.HotelId)
            .NotEmpty()
            .WithMessage("Hotel ID is required.");

        RuleFor(x => x.FromDate)
            .NotEmpty()
            .WithMessage("Check-in date is required and in ISO 8601 format.")
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("Check-in date cannot be in the past.");

        RuleFor(x => x.ToDate)
            .NotEmpty()
            .WithMessage("Check-out date is required and in ISO 8601 format.")
            .GreaterThan(x => x.FromDate)
            .WithMessage("Check-out date must be after check-in date.");

        RuleFor(x => x.Guests)
            .GreaterThan(0)
            .WithMessage("Number of guests must be at least 1.")
            .LessThanOrEqualTo(10)
            .WithMessage("Number of guests cannot exceed 10.");

        // Minimum stay requirement
        RuleFor(x => x)
            .Must(x => (x.ToDate - x.FromDate)!.Value.TotalDays >= 1)
            .When(x => x.ToDate.HasValue && x.FromDate.HasValue)
            .WithMessage("Minimum stay is 1 night.")
            .When(x => x.ToDate > x.FromDate);

     
    }
}