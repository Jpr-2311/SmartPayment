namespace FinPilot.Application.Common.Exceptions;

/// <summary>
/// Base application exception.
/// All custom exceptions in the Application layer derive from this.
/// </summary>
public class AppException : Exception
{
    public int StatusCode { get; }

    public AppException(string message, int statusCode = 400)
        : base(message)
    {
        StatusCode = statusCode;
    }

    public AppException(string message, Exception innerException, int statusCode = 400)
        : base(message, innerException)
    {
        StatusCode = statusCode;
    }
}
