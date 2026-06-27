namespace FinPilot.Application.Common.Exceptions;

/// <summary>
/// Exception thrown when a requested entity is not found.
/// Maps to HTTP 404.
/// </summary>
public class NotFoundException : AppException
{
    public NotFoundException(string entityName, object key)
        : base($"{entityName} with key '{key}' was not found.", 404)
    {
    }

    public NotFoundException(string message)
        : base(message, 404)
    {
    }
}
