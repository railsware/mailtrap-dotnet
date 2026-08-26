namespace Mailtrap.SendingDomains.Models;


/// <summary>
/// Represents whether the sender is a business or an individual.
/// </summary>
public sealed record CompanyInfoLevel : StringEnum<CompanyInfoLevel>
{
    /// <summary>
    /// Gets the value representing "business" info level.
    /// </summary>
    ///
    /// <value>
    /// Represents "business" info level.
    /// </value>
    public static CompanyInfoLevel Business { get; } = Define("business");

    /// <summary>
    /// Gets the value representing "individual" info level.
    /// </summary>
    ///
    /// <value>
    /// Represents "individual" info level.
    /// </value>
    public static CompanyInfoLevel Individual { get; } = Define("individual");
}
