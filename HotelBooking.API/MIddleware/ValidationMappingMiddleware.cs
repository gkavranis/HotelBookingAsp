namespace HotelBooking.API.MIddleware;

using FluentValidation;
using HotelBooking.Contracts.Responses;
using Microsoft.Extensions.Logging;

/// <summary>
/// Middleware for intercepting and handling FluentValidation exceptions.
/// Converts validation errors into standardized 400 Bad Request responses.
/// </summary>
public class ValidationMappingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ValidationMappingMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationMappingMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the request pipeline.</param>
    /// <param name="logger">The logger instance for logging validation errors.</param>
    public ValidationMappingMiddleware(RequestDelegate next, ILogger<ValidationMappingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Invokes the middleware to handle the HTTP request.
    /// Catches FluentValidation exceptions and returns a formatted validation error response.
    /// </summary>
    /// <param name="context">The HTTP context for the current request.</param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            _logger.LogWarning(ex, "Validation failed for request: {Method} {Path}. Errors: {Errors}",
                context.Request.Method,
                context.Request.Path,
                string.Join(", ", ex.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}")));

            context.Response.StatusCode = 400;
            var validationFailureResponse = new ValidationFailureResponse
            {
                Errors = ex.Errors.Select(x => new ValidationResponse
                {
                    PropertyName = x.PropertyName,
                    Message = x.ErrorMessage
                })
            };

            await context.Response.WriteAsJsonAsync(validationFailureResponse);
        }
    }
}
