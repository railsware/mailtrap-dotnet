namespace Mailtrap.EmailTemplates.Requests;


/// <summary>
/// Generic request DTO for email template CRUD operations.
/// </summary>
internal record EmailTemplateRequestDto<T> : IValidatable
    where T : EmailTemplateRequest
{
    /// <summary>
    /// Gets email template request payload.
    /// </summary>
    ///
    /// <value>
    /// Email template request payload.
    /// </value>
    [JsonPropertyName("email_template")]
    [JsonPropertyOrder(1)]
    public T EmailTemplate { get; }


    public EmailTemplateRequestDto(T emailTemplate)
    {
        Ensure.NotNull(emailTemplate, nameof(emailTemplate));

        EmailTemplate = emailTemplate;
    }


    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return EmailTemplateRequestValidator.Instance
            .Validate(EmailTemplate)
            .ToMailtrapValidationResult();
    }
}
