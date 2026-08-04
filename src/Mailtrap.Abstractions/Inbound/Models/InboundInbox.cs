namespace Mailtrap.Inbound.Models;


/// <summary>
/// Represents an inbound inbox.
/// </summary>
public sealed record InboundInbox
{
    /// <summary>
    /// Gets or sets the inbox identifier.
    /// </summary>
    ///
    /// <value>
    /// Inbox identifier.
    /// </value>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the inbox name.
    /// </summary>
    ///
    /// <value>
    /// Inbox name.
    /// </value>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the inbound email address that delivers to this inbox.
    /// </summary>
    ///
    /// <value>
    /// Inbound email address.
    /// </value>
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the sending domain identifier for a custom-domain (catch-all) inbox.<br/>
    /// <see langword="null"/> for a Mailtrap-hosted inbox.
    /// </summary>
    ///
    /// <value>
    /// Sending domain identifier, or <see langword="null"/> for a Mailtrap-hosted inbox.
    /// </value>
    [JsonPropertyName("domain_id")]
    public long? DomainId { get; set; }
}
