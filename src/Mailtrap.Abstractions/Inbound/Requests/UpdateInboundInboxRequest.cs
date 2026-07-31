namespace Mailtrap.Inbound.Requests;


/// <summary>
/// Request object for updating an inbound inbox.
/// </summary>
public sealed record UpdateInboundInboxRequest
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
}
