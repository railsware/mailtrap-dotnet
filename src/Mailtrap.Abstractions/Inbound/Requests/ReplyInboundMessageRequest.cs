namespace Mailtrap.Inbound.Requests;


/// <summary>
/// Request body for replying to (or reply-all-ing) an inbound message.<br/>
/// <see cref="From"/> is rejected for Mailtrap-hosted inboxes and required for
/// custom-domain inboxes. A body (<see cref="Text"/> and/or <see cref="Html"/>)
/// is required by the API for <c>reply</c> and <c>reply_all</c>.
/// </summary>
public sealed record ReplyInboundMessageRequest
{
    /// <summary>
    /// Gets or sets the sender address.
    /// </summary>
    ///
    /// <value>
    /// Sender address.
    /// </value>
    [JsonPropertyName("from")]
    public EmailAddress? From { get; set; }

    /// <summary>
    /// Gets or sets the recipient addresses. Overrides the default recipient when set.
    /// </summary>
    ///
    /// <value>
    /// Recipient addresses.
    /// </value>
    [JsonPropertyName("to")]
    public IList<EmailAddress>? To { get; set; }

    /// <summary>
    /// Gets or sets the carbon-copy addresses.
    /// </summary>
    ///
    /// <value>
    /// Carbon-copy addresses.
    /// </value>
    [JsonPropertyName("cc")]
    public IList<EmailAddress>? Cc { get; set; }

    /// <summary>
    /// Gets or sets the blind carbon-copy addresses.
    /// </summary>
    ///
    /// <value>
    /// Blind carbon-copy addresses.
    /// </value>
    [JsonPropertyName("bcc")]
    public IList<EmailAddress>? Bcc { get; set; }

    /// <summary>
    /// Gets or sets the reply-to address.
    /// </summary>
    ///
    /// <value>
    /// Reply-to address.
    /// </value>
    [JsonPropertyName("reply_to")]
    public EmailAddress? ReplyTo { get; set; }

    /// <summary>
    /// Gets or sets the subject line.
    /// </summary>
    ///
    /// <value>
    /// Subject line.
    /// </value>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// Gets or sets the plain-text body.
    /// </summary>
    ///
    /// <value>
    /// Plain-text body.
    /// </value>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// Gets or sets the HTML body.
    /// </summary>
    ///
    /// <value>
    /// HTML body.
    /// </value>
    [JsonPropertyName("html")]
    public string? Html { get; set; }

    /// <summary>
    /// Gets or sets the Email API category for the sent message.
    /// </summary>
    ///
    /// <value>
    /// Email API category for the sent message.
    /// </value>
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    /// <summary>
    /// Gets or sets the attachments for the sent message.
    /// </summary>
    ///
    /// <value>
    /// Attachments for the sent message.
    /// </value>
    [JsonPropertyName("attachments")]
    public IList<Attachment>? Attachments { get; set; }

    /// <summary>
    /// Gets or sets custom headers to add to the sent message.
    /// </summary>
    ///
    /// <value>
    /// Custom headers to add to the sent message.
    /// </value>
    [JsonPropertyName("headers")]
    public IDictionary<string, string>? Headers { get; set; }

    /// <summary>
    /// Gets or sets Email API custom variables for the sent message.
    /// </summary>
    ///
    /// <value>
    /// Email API custom variables for the sent message.
    /// </value>
    [JsonPropertyName("custom_variables")]
    public IDictionary<string, string>? CustomVariables { get; set; }
}
