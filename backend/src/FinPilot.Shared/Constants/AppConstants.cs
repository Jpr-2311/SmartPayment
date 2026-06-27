namespace FinPilot.Shared.Constants;

/// <summary>
/// Application-wide constants.
/// Centralized here to avoid magic strings across the codebase.
/// </summary>
public static class AppConstants
{
    public const string AppName = "FinPilot AI";
    public const string AppVersion = "0.1.0";

    /// <summary>
    /// API versioning constants.
    /// </summary>
    public static class Api
    {
        public const string VersionPrefix = "api/v";
        public const string V1 = "1.0";
    }

    /// <summary>
    /// CORS policy names.
    /// </summary>
    public static class Cors
    {
        public const string AllowFrontend = "AllowFrontend";
    }

    /// <summary>
    /// Configuration section names matching appsettings.json keys.
    /// </summary>
    public static class Configuration
    {
        public const string DatabaseConnection = "ConnectionStrings:DefaultConnection";
        public const string FrontendUrl = "FrontendUrl";
    }

    /// <summary>
    /// Common error messages.
    /// </summary>
    public static class Errors
    {
        public const string NotFound = "The requested resource was not found.";
        public const string Unauthorized = "You are not authorized to perform this action.";
        public const string ValidationFailed = "One or more validation errors occurred.";
        public const string InternalError = "An unexpected error occurred. Please try again later.";
    }
}
