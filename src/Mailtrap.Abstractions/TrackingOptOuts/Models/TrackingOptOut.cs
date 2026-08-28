namespace Mailtrap.TrackingOptOuts.Models;


/// <summary>
/// Represents an email address that has opted out of open and click tracking.
/// </summary>
public sealed record TrackingOptOut
{
    /// <summary>
    /// Gets or sets the tracking opt-out identifier.
    /// </summary>
    ///
    /// <value>
    /// Tracking opt-out identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    [JsonRequired]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address opted out of tracking.
    /// </summary>
    ///
    /// <value>
    /// Email address.
    /// </value>
    [JsonPropertyName("email")]
    [JsonPropertyOrder(2)]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the timestamp when the tracking opt-out was created.
    /// </summary>
    ///
    /// <value>
    /// Creation timestamp.
    /// </value>
    [JsonPropertyName("created_at")]
    [JsonPropertyOrder(3)]
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the sending domain the tracking opt-out applies to.
    /// </summary>
    ///
    /// <value>
    /// Sending domain name.
    /// </value>
    [JsonPropertyName("domain_name")]
    [JsonPropertyOrder(4)]
    public string? DomainName { get; set; }
}
