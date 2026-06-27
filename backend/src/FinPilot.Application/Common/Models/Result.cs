namespace FinPilot.Application.Common.Models;

/// <summary>
/// Result pattern wrapper for explicit success/failure returns.
/// Eliminates throwing exceptions for expected business failures.
/// </summary>
public class Result
{
    protected Result(bool isSuccess, string? message = null, IEnumerable<string>? errors = null)
    {
        IsSuccess = isSuccess;
        Message = message ?? string.Empty;
        Errors = errors?.ToList() ?? [];
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public string Message { get; }
    public List<string> Errors { get; }

    public static Result Success(string? message = null)
        => new(true, message);

    public static Result Failure(string message, IEnumerable<string>? errors = null)
        => new(false, message, errors);

    public static Result<T> Success<T>(T data, string? message = null)
        => Result<T>.Success(data, message);

    public static Result<T> Failure<T>(string message, IEnumerable<string>? errors = null)
        => Result<T>.Failure(message, errors);
}

/// <summary>
/// Generic Result wrapper carrying a typed data payload.
/// </summary>
/// <typeparam name="T">Type of the result data</typeparam>
public class Result<T> : Result
{
    private Result(bool isSuccess, T? data, string? message, IEnumerable<string>? errors = null)
        : base(isSuccess, message, errors)
    {
        Data = data;
    }

    public T? Data { get; }

    public static Result<T> Success(T data, string? message = null)
        => new(true, data, message);

    public new static Result<T> Failure(string message, IEnumerable<string>? errors = null)
        => new(false, default, message, errors);
}
