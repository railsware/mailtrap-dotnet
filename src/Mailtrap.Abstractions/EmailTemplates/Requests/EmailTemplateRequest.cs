namespace Mailtrap.EmailTemplates.Requests;

/// <summary>
/// Generic request object for email template CRUD operations.
/// </summary>
public record EmailTemplateRequest : IValidatable
{
    /// <summary>
    /// Gets or sets email template name.
    /// </summary>
    /// <remarks>
    /// Email template name must be no longer than 255 characters.
    /// </remarks>
    /// <value>
    /// Email template name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonRequired]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the email template category.
    /// </summary>
    /// <remarks>
    /// Email template category must be no longer than 255 characters.
    /// </remarks>
    /// <value>
    /// Email template category.
    /// </value>
    [JsonPropertyName("category")]
    [JsonRequired]
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the email template subject.
    /// </summary>
    /// <remarks>
    /// Email template subject must be no longer than 255 characters.
    /// </remarks>
    /// <value>
    /// Email template subject.
    /// </value>
    [JsonPropertyName("subject")]
    [JsonRequired]
    public string Subject { get; set; }

    /// <summary>
    /// Gets or sets the email template body text.
    /// </summary>
    /// <remarks>
    /// Email template body text must be no longer than 10_000_000 characters.
    /// </remarks>
    /// <value>
    /// Email template body text.
    /// </value>
    [JsonPropertyName("body_text")]
    public string BodyText { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email template body html.
    /// </summary>
    /// <remarks>
    /// Email template body html must be no longer than 10_000_000 characters.
    /// </remarks>
    /// <value>
    /// Email template body html.
    /// </value>
    [JsonPropertyName("body_html")]
    [JsonPropertyOrder(7)]
    public string BodyHtml { get; set; } = string.Empty;


    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    ///
    /// <param name="name">
    /// <see cref="Name"/> of the email template.
    /// </param>
    /// <param name="category">
    /// <see cref="Category"/> of the email template.
    /// </param>
    /// <param name="subject">
    /// <see cref="Subject"/> of the email template.
    /// </param>
    ///
    /// <remarks>
    /// The <paramref name="name"/> must be between 1 and 255 characters.
    /// The <paramref name="category"/> must be between 1 and 255 characters.
    /// The <paramref name="subject"/> must be between 1 and 255 characters.
    /// </remarks>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="name"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// When <paramref name="category"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// When <paramref name="subject"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    [JsonConstructor]
    public EmailTemplateRequest(string name, string category, string subject)
    {
        Ensure.NotNullOrEmpty(name, nameof(name));
        Ensure.NotNullOrEmpty(category, nameof(category));
        Ensure.NotNullOrEmpty(subject, nameof(subject));

        Name = name;
        Category = category;
        Subject = subject;
    }

    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return EmailTemplateRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
