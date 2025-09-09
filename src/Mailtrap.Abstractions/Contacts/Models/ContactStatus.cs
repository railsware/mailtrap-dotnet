namespace Mailtrap.Contacts.Models;

/// <summary>
/// Contact subscription status.
/// </summary>
public sealed record ContactStatus : StringEnum<ContactStatus>
{
    /// <summary>
    /// Gets the value representing "Subscribed" contact status.
    /// </summary>
    ///
    /// <value>
    /// Represents "Subscribed" contact status.
    /// </value>
    public static readonly ContactStatus Subscribed = Define("subscribed");

    /// <summary>
    /// Gets the value representing "Unsubscribed" contact status.
    /// </summary>
    ///
    /// <value>
    /// Represents "Unsubscribed" contact status.
    /// </value>
    public static readonly ContactStatus Unsubscribed = Define("unsubscribed");
}
