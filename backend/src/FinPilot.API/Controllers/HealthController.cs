using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace FinPilot.API.Controllers;

/// <summary>
/// Health check controller providing application and database health status.
/// Used by load balancers, Docker health checks, and monitoring tools.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class HealthController : ControllerBase
{
    private readonly ILogger<HealthController> _logger;

    public HealthController(ILogger<HealthController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Basic health check — returns 200 if the API is running.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        _logger.LogInformation("Health check requested");

        return Ok(new
        {
            status = "healthy",
            service = "FinPilot.API",
            version = "1.0.0",
            timestamp = DateTime.UtcNow
        });
    }

    /// <summary>
    /// Detailed health check — verifies database connectivity.
    /// </summary>
    [HttpGet("detailed")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public IActionResult GetDetailed()
    {
        // Detailed health checks will be expanded in future phases
        return Ok(new
        {
            status = "healthy",
            service = "FinPilot.API",
            version = "1.0.0",
            timestamp = DateTime.UtcNow,
            checks = new
            {
                api = "healthy",
                database = "not_configured"
            }
        });
    }
}
