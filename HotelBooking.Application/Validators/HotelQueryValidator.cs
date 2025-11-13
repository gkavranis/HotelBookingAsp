namespace HotelBooking.Application.Validators;

using FluentValidation;
using HotelBooking.Domain.Entities;

public class HotelQueryValidator : AbstractValidator<HotelQuery>
{
    public HotelQueryValidator()
    {
        RuleFor(item => item.QueryName)
            .NotEmpty()
            .WithMessage("Hotel name cannot be empty.")
            .MaximumLength(100)
            .WithMessage("Hotel name cannot exceed 100 characters.")
            .Matches(@"^[a-zA-Z0-9\s\-'&.*]+$")
            .WithMessage("Hotel name contains invalid characters.");
    }
}
