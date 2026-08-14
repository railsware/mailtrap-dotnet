namespace Mailtrap.EmailCampaigns.Requests;


/// <summary>
/// Request object for scheduling an email campaign - when to start sending it.
/// </summary>
public sealed record ScheduleEmailCampaignRequest : IValidatable
{
    /// <summary>
    /// Gets the date and time to send the campaign at.<br/>
    /// Must be in the future and no more than 1 month ahead.
    /// </summary>
    ///
    /// <value>
    /// Scheduled send time. Serialized as an ISO 8601 string.
    /// </value>
    [JsonPropertyName("datetime")]
    [JsonPropertyOrder(1)]
    public DateTimeOffset Datetime { get; }


    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    ///
    /// <param name="datetime">
    /// The date and time to send the campaign at.
    /// </param>
    [JsonConstructor]
    public ScheduleEmailCampaignRequest(DateTimeOffset datetime)
    {
        Datetime = datetime;
    }


    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return ScheduleEmailCampaignRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
