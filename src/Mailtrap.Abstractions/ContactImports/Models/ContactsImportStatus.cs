namespace Mailtrap.ContactImports.Models;


/// <summary>
/// Represents status of the contact imports.
/// </summary>
public sealed record ContactsImportStatus : StringEnum<ContactsImportStatus>
{
    /// <summary>
    /// Gets the value representing "created" status.
    /// </summary>
    ///
    /// <value>
    /// Represents "created" status.
    /// </value>
    public static ContactsImportStatus Created { get; } = Define("created");

    /// <summary>
    /// Gets the value representing "started" status.
    /// </summary>
    ///
    /// <value>
    /// Represents "started" status.
    /// </value>
    public static ContactsImportStatus Started { get; } = Define("started");

    /// <summary>
    /// Gets the value representing "finished" status.
    /// </summary>
    ///
    /// <value>
    /// Represents "finished" status.
    /// </value>
    public static ContactsImportStatus Finished { get; } = Define("finished");

    /// <summary>
    /// Gets the value representing "failed" status.
    /// </summary>
    ///
    /// <value>
    /// Represents "failed" status.
    /// </value>
    public static ContactsImportStatus Failed { get; } = Define("failed");
}
