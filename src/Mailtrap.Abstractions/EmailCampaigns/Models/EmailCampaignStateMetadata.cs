namespace Mailtrap.EmailCampaigns.Models;


/// <summary>
/// Represents metadata about the most recent state transition of an email campaign.
/// </summary>
public sealed record EmailCampaignStateMetadata
{
    /// <summary>
    /// Gets or sets the reason for the most recent state transition.
    /// </summary>
    ///
    /// <value>
    /// State transition reason.
    /// </value>
    [JsonPropertyName("reason")]
    [JsonPropertyOrder(1)]
    public string? Reason { get; set; }

    /// <summary>
    /// Gets or sets the last error message recorded for a failed campaign.
    /// </summary>
    ///
    /// <value>
    /// Last error message.
    /// </value>
    [JsonPropertyName("error")]
    [JsonPropertyOrder(2)]
    public string? Error { get; set; }

    /// <summary>
    /// Gets the per-recipient errors recorded when sending failed.
    /// </summary>
    ///
    /// <value>
    /// Collection of per-recipient errors.
    /// </value>
    [JsonPropertyName("errors")]
    [JsonPropertyOrder(3)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<EmailCampaignStateError> Errors { get; } = [];

    /// <summary>
    /// Gets or sets the time the campaign is scheduled to send at.<br/>
    /// Present in the <see cref="CampaignState.Scheduled"/> state.
    /// </summary>
    ///
    /// <value>
    /// Scheduled time, or <see langword="null"/> when not scheduled.
    /// </value>
    [JsonPropertyName("scheduled_at")]
    [JsonPropertyOrder(4)]
    public DateTimeOffset? ScheduledAt { get; set; }
}
