namespace Mailtrap.Core.Constants;


/// <summary>
/// HTTP header values used in Mailtrap API.
/// </summary>
internal static class HeaderValues
{
    internal static string UserAgentName { get; } = "mailtrap-dotnet";
    internal static string UserAgentVersion { get; } = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
    internal static ProductInfoHeaderValue UserAgent { get; } = new(UserAgentName, UserAgentVersion);
}
