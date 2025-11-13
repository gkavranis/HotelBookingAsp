namespace HotelBooking.Contracts.Attributes;

using System.ComponentModel.DataAnnotations;
using System.Globalization;

/// <summary>
/// Validates that a string is a valid ISO 8601 date (yyyy-MM-dd format).
/// </summary>
public class Iso8601DateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return ValidationResult.Success; 
        }

        string? dateString = value.ToString();

        // Validate format and actual date
        if (DateTime.TryParseExact(
            dateString,
            "yyyy-MM-dd",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out _))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(
            ErrorMessage ?? $"The field {validationContext.DisplayName} must be a valid date in ISO 8601 format (yyyy-MM-dd).");
    }
}