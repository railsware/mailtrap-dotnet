namespace Mailtrap.Suppressions.Requests;


/// <summary>
/// Request object for adding an email address to the account's suppression list.
/// </summary>
public sealed record CreateSuppressionRequest : IValidatable
{
    /// <summary>
    /// Gets or sets the email address to suppress.
    /// </summary>
    ///
    /// <value>
    /// Email address to suppress.
    /// </value>
    [JsonPropertyName("email")]
    [JsonPropertyOrder(1)]
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the domain to suppress this email for.
    /// </summary>
    ///
    /// <value>
    /// Domain identifier.
    /// </value>
    [JsonPropertyName("domain_id")]
    [JsonPropertyOrder(2)]
    public long DomainId { get; set; }

    /// <summary>
    /// Gets or sets the sending stream to suppress this email for.
    /// </summary>
    ///
    /// <value>
    /// Sending stream.
    /// </value>
    [JsonPropertyName("sending_stream")]
    [JsonPropertyOrder(3)]
    public SendingStream SendingStream { get; set; } = SendingStream.Unknown;

    /// <summary>
    /// Gets or sets the reason for the suppression.
    /// </summary>
    ///
    /// <value>
    /// Suppression reason, or <see langword="null"/> to let the API default it to
    /// <c>manual import</c>.
    /// </value>
    [JsonPropertyName("type")]
    [JsonPropertyOrder(4)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SuppressionType? Type { get; set; }


    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return CreateSuppressionRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
