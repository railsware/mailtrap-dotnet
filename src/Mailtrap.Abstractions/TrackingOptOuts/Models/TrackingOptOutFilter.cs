namespace Mailtrap.TrackingOptOuts.Models;


/// <summary>
/// Represents a set of filtering parameters for tracking opt-out fetching.
/// </summary>
public sealed record TrackingOptOutFilter
{
    /// <summary>
    /// Gets or sets the email address to filter by.
    /// </summary>
    ///
    /// <value>
    /// Email address, matched case-insensitively.
    /// </value>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the lower bound of the creation timestamp.
    /// </summary>
    ///
    /// <value>
    /// Only opt-outs created at or after this moment are returned.
    /// </value>
    public DateTimeOffset? StartTime { get; set; }

    /// <summary>
    /// Gets or sets the upper bound of the creation timestamp.
    /// </summary>
    ///
    /// <value>
    /// Only opt-outs created at or before this moment are returned.
    /// </value>
    public DateTimeOffset? EndTime { get; set; }

    /// <summary>
    /// Gets or sets the pagination cursor.
    /// </summary>
    ///
    /// <value>
    /// Identifier from the previous response, to fetch records after it.
    /// </value>
    public string? LastId { get; set; }
}
