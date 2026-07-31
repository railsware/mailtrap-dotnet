namespace Mailtrap.Inbound.Requests;


/// <summary>
/// Request object for creating an inbound inbox.<br/>
/// Omit <see cref="DomainId"/> for a Mailtrap-hosted inbox; set it to create a
/// custom-domain (catch-all) inbox.
/// </summary>
public sealed record CreateInboundInboxRequest
{
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
    /// Gets or sets the sending domain identifier for a custom-domain (catch-all) inbox.
    /// </summary>
    ///
    /// <value>
    /// Sending domain identifier, or <see langword="null"/> for a Mailtrap-hosted inbox.
    /// </value>
    [JsonPropertyName("domain_id")]
    public long? DomainId { get; set; }
}
