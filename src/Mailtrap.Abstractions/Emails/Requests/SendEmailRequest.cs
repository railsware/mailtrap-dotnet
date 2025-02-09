// -----------------------------------------------------------------------
// <copyright file="SendEmailRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Requests;


/// <summary>
/// Represents request object used to send email.
/// </summary>
public sealed record SendEmailRequest : IValidatable
{
    /// <summary>
    /// <para>
    /// Gets or sets <see cref="EmailAddress"/> instance representing email's sender.
    /// </para>
    /// <para>
    /// Required.
    /// </para>
    /// </summary>
    /// 
    /// <value>
    /// Instance, representing email's sender address and name.
    /// </value>
    [JsonPropertyName("from")]
    [JsonPropertyOrder(10)]
    public EmailAddress? From { get; set; }

    /// <summary>
    /// Gets or sets <see cref="EmailAddress"/> representing 'Reply To' email field.
    /// </summary>
    /// 
    /// <value>
    /// Representing 'Reply To' address and name.
    /// </value>
    [JsonPropertyName("reply_to")]
    [JsonPropertyOrder(15)]
    public EmailAddress? ReplyTo { get; set; }

    /// <summary>
    /// Gets a collection of <see cref="EmailAddress"/> objects, defining who will receive a copy of email.
    /// </summary>
    ///
    /// <value>
    /// A collection of <see cref="EmailAddress"/> objects.
    /// </value>
    /// 
    /// <remarks>
    /// Must not contain more than 1000 recipients.<br />
    /// Each object in this collection must contain the recipient's email address.<br />
    /// Each object in this collection may optionally contain the recipient's name.<br />
    /// At least one recipient must be specified in one of the collections: <see cref="To"/>, <see cref="Cc"/> or <see cref="Bcc"/>.
    /// </remarks>
    [JsonPropertyName("to")]
    [JsonPropertyOrder(20)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<EmailAddress> To { get; } = [];

    /// <summary>
    /// Gets a collection of <see cref="EmailAddress"/> objects, defining who will receive a carbon copy of email.
    /// </summary>
    ///
    /// <value>
    /// A collection of <see cref="EmailAddress"/> objects.
    /// </value>
    /// 
    /// <remarks>
    /// Must not contain more than 1000 recipients.<br />
    /// Each object in this collection must contain the recipient's email address.<br />
    /// Each object in this collection may optionally contain the recipient's name.<br />
    /// At least one recipient must be specified in one of the collections: <see cref="To"/>, <see cref="Cc"/> or <see cref="Bcc"/>.
    /// </remarks>
    [JsonPropertyName("cc")]
    [JsonPropertyOrder(30)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<EmailAddress> Cc { get; } = [];

    /// <summary>
    /// Gets a collection of <see cref="EmailAddress"/> objects, defining who will receive a blind carbon copy of email.
    /// </summary>
    ///
    /// <value>
    /// A collection of <see cref="EmailAddress"/> objects.
    /// </value>
    /// 
    /// <remarks>
    /// Must not contain more than 1000 recipients.<br />
    /// Each object in this collection must contain the recipient's email address.<br />
    /// Each object in this collection may optionally contain the recipient's name.<br />
    /// At least one recipient must be specified in one of the collections: <see cref="To"/>, <see cref="Cc"/> or <see cref="Bcc"/>.
    /// </remarks>
    [JsonPropertyName("bcc")]
    [JsonPropertyOrder(40)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<EmailAddress> Bcc { get; } = [];

    /// <summary>
    /// Gets a collection of <see cref="Attachment"/> objects, where you can specify any attachments you want to include.
    /// </summary>
    ///
    /// <value>
    /// A collection of <see cref="Attachment"/> objects.
    /// </value>
    [JsonPropertyName("attachments")]
    [JsonPropertyOrder(50)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<Attachment> Attachments { get; } = [];

    /// <summary>
    /// Gets a dictionary of header names and values to substitute for them.
    /// </summary>
    ///
    /// <value>
    /// A dictionary of header names and values.
    /// </value>
    /// 
    /// <remarks>
    /// The key/value pairs must be strings.<br/>
    /// You must ensure these are properly encoded if they contain unicode characters.<br />
    /// These headers cannot be one of the reserved headers.<br />
    /// "Content-Transfer-Encoding" header will be ignored and replaced with "quoted-printable".
    /// </remarks>
    [JsonPropertyName("headers")]
    [JsonPropertyOrder(60)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();

    /// <summary>
    /// Gets a dictionary of values that are specific to the entire send
    /// that will be carried along with the email and its activity data.
    /// </summary>
    ///
    /// <value>
    /// A dictionary of variable keys and values.
    /// </value>
    /// 
    /// <remarks>
    /// The key/value pairs must be strings.<br/>
    /// Total size of custom variables in JSON form must not exceed 1000 bytes.
    /// </remarks>
    [JsonPropertyName("custom_variables")]
    [JsonPropertyOrder(70)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IDictionary<string, string> CustomVariables { get; } = new Dictionary<string, string>();

    /// <summary>
    /// Gets or sets the global or 'message level' subject of email.<br />
    /// This may be overridden by subject lines set in personalizations.
    /// </summary>
    ///
    /// <value>
    /// Contains the subject of the email.
    /// </value>
    /// 
    /// <remarks>
    /// Must be <see langword="null"/> if <see cref="TemplateId"/> is set.
    /// <para>
    /// Required in case <see cref="HtmlBody"/> and(or) <see cref="TextBody"/> is used.<br/>
    /// Should be non-empty string in this case.
    /// </para>
    /// </remarks>
    [JsonPropertyName("subject")]
    [JsonPropertyOrder(80)]
    public string? Subject { get; set; }

    /// <summary>
    /// Gets or sets the text version of the body of the email.
    /// </summary>
    ///
    /// <value>
    /// Contains the text body of the email.
    /// </value>
    /// 
    /// <remarks>
    /// Must be <see langword="null"/> if <see cref="TemplateId"/> is set.<br />
    /// Otherwise, can be used along with <see cref="HtmlBody"/> to create a fall-back for non-html clients.<br />
    /// Required in the absence of <see cref="TemplateId"/> and <see cref="HtmlBody"/>.
    /// </remarks>
    [JsonPropertyName("text")]
    [JsonPropertyOrder(90)]
    public string? TextBody { get; set; }

    /// <summary>
    /// Gets or sets HTML version of the body of the email.
    /// </summary>
    ///
    /// <value>
    /// Contains the HTML body of the email.
    /// </value>
    /// 
    /// <remarks>
    /// Must be <see langword="null"/> if <see cref="TemplateId"/> is set.<br />
    /// Required in the absence of <see cref="TemplateId"/> and <see cref="TextBody"/>.
    /// </remarks>
    [JsonPropertyName("html")]
    [JsonPropertyOrder(100)]
    public string? HtmlBody { get; set; }

    /// <summary>
    /// Gets or sets the category of email.
    /// </summary>
    ///
    /// <value>
    /// Contains the category of the email.
    /// </value>
    /// 
    /// <remarks>
    /// Should be <see langword="null"/> if <see cref="TemplateId"/> is set.<br/>
    /// Otherwise must be less or equal to 255 characters.
    /// </remarks>
    [JsonPropertyName("category")]
    [JsonPropertyOrder(110)]
    public string? Category { get; set; }

    /// <summary>
    /// Gets or sets UUID of email template.
    /// </summary>
    ///
    /// <value>
    /// Contains the UUID of email template.
    /// </value>
    /// 
    /// <remarks>
    /// If provided, then <see cref="Subject"/>, <see cref="Category"/>, <see cref="TextBody"/>  and <see cref="HtmlBody"/>
    /// properties are forbidden and must be <see langword="null"/>.<br />
    /// Email subject, text and html will be generated from template using optional <see cref="TemplateVariables"/>.
    /// </remarks>
    [JsonPropertyName("template_uuid")]
    [JsonPropertyOrder(120)]
    public string? TemplateId { get; set; }

    /// <summary>
    /// Gets or sets optional template variables that will be used to generate actual subject, text and html
    /// from email template.
    /// </summary>
    ///
    /// <value>
    /// Contains template variables object.
    /// </value>
    /// 
    /// <remarks>
    /// Will be used only in case <see cref="TemplateId"/> is set.
    /// </remarks>
    [JsonPropertyName("template_variables")]
    [JsonPropertyOrder(130)]
    public object? TemplateVariables { get; set; }


    /// <summary>
    /// Factory method that creates a new instance of <see cref="SendEmailRequest" /> request.
    /// </summary>
    /// 
    /// <returns>
    /// New <see cref="SendEmailRequest"/> instance.
    /// </returns>
    public static SendEmailRequest Create() => new();


    /// <inheritdoc />
    public ValidationResult Validate()
    {
        return SendEmailRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
