namespace Mailtrap.TrackingOptOuts.Requests;


/// <summary>
/// Request object for adding an email address to the tracking opt-out list.
/// </summary>
public sealed record CreateTrackingOptOutRequest : IValidatable
{
    /// <summary>
    /// Gets or sets the email address to opt out of tracking.
    /// </summary>
    ///
    /// <value>
    /// Email address.
    /// </value>
    [JsonPropertyName("email")]
    [JsonPropertyOrder(1)]
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the sending domain the opt-out applies to.
    /// </summary>
    ///
    /// <value>
    /// Sending domain identifier.
    /// </value>
    [JsonPropertyName("domain_id")]
    [JsonPropertyOrder(2)]
    public long DomainId { get; set; }


    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return CreateTrackingOptOutRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
