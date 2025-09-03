namespace Mailtrap.Contacts.Models;

/// <summary>
/// Contact update actions.
/// </summary>
public sealed record ContactAction : StringEnum<ContactAction>
{
    /// <summary>
    /// Gets the value representing "Updated" contact action.
    /// </summary>
    ///
    /// <value>
    /// Represents "Updated" contact action.
    /// </value>
    public static readonly ContactAction Updated = Define("updated");

    /// <summary>
    /// Gets the value representing "Created" contact action.
    /// </summary>
    ///
    /// <value>
    /// Represents "Created" contact action.
    /// </value>
    public static readonly ContactAction Created = Define("created");
}
