namespace HotelBooking.Contracts.Responses;

/// <summary>
/// Response model returned when request validation fails.
/// </summary>
public class ValidationFailureResponse
{
    /// <summary>
    /// Collection of validation errors that occurred during request processing.
    /// </summary>
    public required IEnumerable<ValidationResponse> Errors { get; init; }
}

/// <summary>
/// Represents a single validation error for a specific property.
/// </summary>
public class ValidationResponse
{
    /// <summary>
    /// The name of the property that failed validation.
    /// </summary>
    public required string PropertyName { get; init; }

    /// <summary>
    /// The validation error message describing why the validation failed.
    /// </summary>
    public required string Message { get; init; }
}
