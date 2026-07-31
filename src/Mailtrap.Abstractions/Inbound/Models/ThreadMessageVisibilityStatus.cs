namespace Mailtrap.Inbound.Models;


/// <summary>
/// Visibility of a message within a thread.
/// </summary>
public sealed record ThreadMessageVisibilityStatus : StringEnum<ThreadMessageVisibilityStatus>
{
    /// <summary>
    /// The message is available; all of its fields are populated.
    /// </summary>
    public static readonly ThreadMessageVisibilityStatus Available = Define("available");

    /// <summary>
    /// The message is a placeholder (e.g. outside the retention window); only
    /// <c>visibility_status</c> and <c>direction</c> are populated.
    /// </summary>
    public static readonly ThreadMessageVisibilityStatus Placeholder = Define("placeholder");
}
