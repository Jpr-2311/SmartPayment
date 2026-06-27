using System.Net;
using System.Text.Json;
using FinPilot.Application.Common.Exceptions;
using FinPilot.Shared.Constants;

namespace FinPilot.API.Middleware;

/// <summary>
/// Global exception handling middleware.
/// Catches all unhandled exceptions and returns standardized ProblemDetails responses.
/// Maps custom exceptions to appropriate HTTP status codes.
/// </summary>
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, message, errors) = exception switch
        {
            Application.Common.Exceptions.ValidationException validationEx =>
                (StatusCodes.Status422UnprocessableEntity,
                 AppConstants.Errors.ValidationFailed,
                 validationEx.Errors.SelectMany(e => e.Value).ToList()),

            NotFoundException notFoundEx =>
                (StatusCodes.Status404NotFound,
                 notFoundEx.Message,
                 new List<string>()),

            AppException appEx =>
                (appEx.StatusCode,
                 appEx.Message,
                 new List<string>()),

            _ =>
                (StatusCodes.Status500InternalServerError,
                 AppConstants.Errors.InternalError,
                 new List<string>())
        };

        // Log the exception
        if (statusCode >= 500)
        {
            _logger.LogError(exception, "Unhandled exception: {Message}", exception.Message);
        }
        else
        {
            _logger.LogWarning("Handled exception: {StatusCode} - {Message}", statusCode, message);
        }

        // Build response
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var response = new
        {
            status = statusCode,
            message,
            errors = errors.Count > 0 ? errors : null,
            traceId = context.TraceIdentifier,
            timestamp = DateTime.UtcNow
        };

        var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        });

        await context.Response.WriteAsync(json);
    }
}

/// <summary>
/// Extension method for cleaner middleware registration.
/// </summary>
public static class GlobalExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app)
    {
        return app.UseMiddleware<GlobalExceptionMiddleware>();
    }
}
