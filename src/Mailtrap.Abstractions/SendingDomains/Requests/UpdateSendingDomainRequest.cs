namespace Mailtrap.SendingDomains.Requests;


/// <summary>
/// Request object for updating sending domain configuration. Only properties set on the request are sent.
/// </summary>
public sealed record UpdateSendingDomainRequest
{
    /// <summary>
    /// Gets or sets a value indicating whether open tracking is enabled.
    /// </summary>
    ///
    /// <value>
    /// Open tracking flag or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("open_tracking_enabled")]
    [JsonPropertyOrder(1)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? OpenTrackingEnabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether click tracking is enabled.
    /// </summary>
    ///
    /// <value>
    /// Click tracking flag or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("click_tracking_enabled")]
    [JsonPropertyOrder(2)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ClickTrackingEnabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the tracking opt-out link is enabled.<br/>
    /// Requires open or click tracking to be enabled.
    /// </summary>
    ///
    /// <value>
    /// Tracking opt-out flag or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("tracking_opt_out_enabled")]
    [JsonPropertyOrder(3)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? TrackingOptOutEnabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether an unsubscribe link is added to emails automatically.
    /// </summary>
    ///
    /// <value>
    /// Automatic unsubscribe link flag or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("auto_unsubscribe_link_enabled")]
    [JsonPropertyOrder(4)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AutoUnsubscribeLinkEnabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether inbound email is enabled for the domain,
    /// so it can be attached to an inbound inbox as a catch-all.
    /// </summary>
    ///
    /// <value>
    /// Inbound flag or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("inbound_enabled")]
    [JsonPropertyOrder(5)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? InboundEnabled { get; set; }
}
