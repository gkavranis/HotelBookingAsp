namespace HotelBooking.Api.Middleware
{
    using System;

    /// <summary>
    /// Middleware for handling unhandled exceptions globally across the application.
    /// Logs exceptions and returns a standardized 500 Internal Server Error response.
    /// </summary>
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionHandlingMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the request pipeline.</param>
        /// <param name="logger">The logger instance for logging exceptions.</param>
        public GlobalExceptionHandlingMiddleware(
            RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Invokes the middleware to handle the HTTP request.
        /// Catches and logs any unhandled exceptions that occur during request processing.
        /// </summary>
        /// <param name="context">The HTTP context for the current request.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(OperationCanceledException cancellationException)
            {
                _logger.LogWarning(cancellationException, "Request was cancelled: {Message}", cancellationException.Message);
                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = StatusCodes.Status499ClientClosedRequest;
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unhandled exception: {Message}", exception.Message);

                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";

                    var errorResponse = new
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Message = "An internal server error occurred."
                    };

                    await context.Response.WriteAsJsonAsync(errorResponse);
                }
            }
        }
    }
}
