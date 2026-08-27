namespace Mailtrap.TrackingOptOuts.Models;


/// <summary>
/// Represents a page of tracking opt-outs together with the cursor for the next page.
/// </summary>
public sealed record TrackingOptOutList
{
    /// <summary>
    /// Gets the tracking opt-outs on this page.
    /// </summary>
    ///
    /// <value>
    /// Tracking opt-outs on this page.
    /// </value>
    [JsonPropertyName("data")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<TrackingOptOut> Items { get; } = [];

    /// <summary>
    /// Gets or sets the cursor for the next page.
    /// </summary>
    ///
    /// <value>
    /// Identifier to pass as the filter cursor, or <see langword="null"/> when there are
    /// no more pages.
    /// </value>
    [JsonPropertyName("last_id")]
    [JsonPropertyOrder(2)]
    public string? LastId { get; set; }
}
