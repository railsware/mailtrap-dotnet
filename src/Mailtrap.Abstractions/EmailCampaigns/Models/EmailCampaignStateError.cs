namespace Mailtrap.EmailCampaigns.Models;


/// <summary>
/// Represents a per-recipient error recorded when sending an email campaign failed.
/// </summary>
public sealed record EmailCampaignStateError
{
    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    ///
    /// <value>
    /// Error message.
    /// </value>
    [JsonPropertyName("message")]
    [JsonPropertyOrder(1)]
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the index of the recipient the error relates to.
    /// </summary>
    ///
    /// <value>
    /// Zero-based recipient index.
    /// </value>
    [JsonPropertyName("rcpt_index")]
    [JsonPropertyOrder(2)]
    public int RcptIndex { get; set; }
}
