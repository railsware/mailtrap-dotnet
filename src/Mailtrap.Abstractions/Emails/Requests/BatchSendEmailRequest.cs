namespace Mailtrap.Emails.Requests;


/// <summary>
/// Represents request object used to send email batch.
/// </summary>
public sealed record BatchSendEmailRequest : IValidatable
{
    /// <summary>
    /// Gets or sets and object with general properties of all emails in the batch.<br />
    /// Each of them can be overridden in requests for individual emails.
    /// </summary>
    ///
    /// <value>
    /// Contains object with general properties of all emails in the batch.
    /// </value>    
    [JsonPropertyName("base")]
    [JsonPropertyOrder(1)]
    public EmailRequest Base { get; set; } = new();

    /// <summary>
    /// Gets or sets the list of email requests.<br/>
    /// Each of them requires recipients (one of to, cc, or bcc).<br />
    /// Each email inherits properties from base but can override them.
    /// </summary>
    /// 
    /// <value>
    /// Contains sender's or recipient's display name.
    /// </value>
    ///
    /// <remarks>
    /// Please note that requests must not exceed the count of 500 and 50 MB overall payload size,
    /// including attachments.
    /// </remarks>
    [JsonPropertyName("requests")]
    [JsonPropertyOrder(2)]
    public IList<SendEmailRequest> Requests { get; set; } = [];


    /// <inheritdoc />
    public ValidationResult Validate()
    {
        return BatchSendEmailRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
