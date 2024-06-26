// -----------------------------------------------------------------------
// <copyright file="SendEmailRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Requests;


/// <summary>
/// Request object for send email API calls.
/// </summary>
public record SendEmailRequest
{
    /// <summary>
    /// <see cref="EmailAddress"/> instance representing email's sender.
    /// </summary>
    /// <remarks>
    /// Required.
    /// </remarks>
    [JsonPropertyName("from")]
    [JsonPropertyOrder(1)]
    public EmailAddress? From { get; set; }

    /// <summary>
    /// A collection of <see cref="EmailAddress"/> who will receive a copy of your email.
    /// </summary>
    /// <remarks>
    /// Must contain at least one recipient, but not more than 1000.<br />
    /// Each object in this collection must contain the recipient's email address.<br />
    /// Each object in this collection may optionally contain the recipient's name.
    /// </remarks>
    [JsonPropertyName("to")]
    [JsonPropertyOrder(2)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<EmailAddress> To { get; } = [];

    /// <summary>
    /// A collection of <see cref="EmailAddress"/> who will receive a carbon copy of your email.
    /// </summary>
    /// <remarks>
    /// Must contain less or equal to 1000 recipients.<br />
    /// Each object in this collection must contain the recipient's email address.<br />
    /// Each object in this collection may optionally contain the recipient's name.
    /// </remarks>
    [JsonPropertyName("cc")]
    [JsonPropertyOrder(3)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<EmailAddress> Cc { get; } = [];

    /// <summary>
    /// A collection of <see cref="EmailAddress"/> who will receive a blind carbon copy of your email.
    /// </summary>
    /// <remarks>
    /// Must contain less or equal to 1000 recipients.<br />
    /// Each object in this collection must contain the recipient's email address.<br />
    /// Each object in this collection may optionally contain the recipient's name.
    /// </remarks>
    [JsonPropertyName("bcc")]
    [JsonPropertyOrder(4)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<EmailAddress> Bcc { get; } = [];

    /// <summary>
    /// A collection of <see cref="Attachment"/> objects where you can specify any attachments you want to include.
    /// </summary>
    [JsonPropertyName("attachments")]
    [JsonPropertyOrder(5)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<Attachment> Attachments { get; } = [];

    /// <summary>
    /// A collection containing key/value pairs of header names and the value to substitute for them.
    /// </summary>
    /// <remarks>
    /// The key/value pairs must be strings.<br/>
    /// You must ensure these are properly encoded if they contain unicode characters.<br />
    /// These headers cannot be one of the reserved headers.<br />
    /// "Content-Transfer-Encoding" header will be ignored and replaced with "quoted-printable".
    /// </remarks>
    [JsonPropertyName("headers")]
    [JsonPropertyOrder(6)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();

    /// <summary>
    /// A collection of values that are specific to the entire send
    /// that will be carried along with the email and its activity data.
    /// </summary>
    /// <remarks>
    /// Total size of custom variables in JSON form must not exceed 1000 bytes.
    /// </remarks>
    [JsonPropertyName("custom_variables")]
    [JsonPropertyOrder(7)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IDictionary<string, string> CustomVariables { get; } = new Dictionary<string, string>();

    /// <summary>
    /// The global or 'message level' subject of your email.<br />
    /// This may be overridden by subject lines set in personalizations.
    /// </summary>
    /// <remarks>
    /// Must be <see langword="null"/> if <see cref="TemplateId"/> is set.<br/>
    /// Required in case <see cref="HtmlBody"/> and(or) <see cref="TextBody"/> is used. Should be non-empty string in this case.
    /// </remarks>
    [JsonPropertyName("subject")]
    [JsonPropertyOrder(8)]
    public string? Subject { get; set; }

    /// <summary>
    /// Text version of the body of the email.<br />
    /// Can be used along with HtmlBody to create a fallback for non-html clients.
    /// </summary>
    /// <remarks>
    /// Must be <see langword="null"/> if <see cref="TemplateId"/> is set.<br/>
    /// Required in the absence of <see cref="HtmlBody"/>.
    /// </remarks>
    [JsonPropertyName("text")]
    [JsonPropertyOrder(9)]
    public string? TextBody { get; set; }

    /// <summary>
    /// HTML version of the body of the email.<br />
    /// Can be used along with HtmlBody to create a fallback for non-html clients.
    /// </summary>
    /// <remarks>
    /// Must be <see langword="null"/> if <see cref="TemplateId"/> is set.<br/>
    /// Required in the absence of <see cref="TextBody"/>.
    /// </remarks>
    [JsonPropertyName("html")]
    [JsonPropertyOrder(10)]
    public string? HtmlBody { get; set; }

    /// <summary>
    /// The category of email.
    /// </summary>
    /// <remarks>
    /// Should be <see langword="null"/> if <see cref="TemplateId"/> is set.<br/>
    /// Otherwise must be less or equal to 255 characters.
    /// </remarks>
    [JsonPropertyName("category")]
    [JsonPropertyOrder(11)]
    public string? Category { get; set; }

    /// <summary>
    /// UUID of email template.
    /// <para>
    /// Subject, text and html will be generated from template using optional template_variables.
    /// </para>
    /// </summary>
    /// <remarks>
    /// If provided, then subject, text, html and category properties are forbidden and must be <see langword="null"/>.
    /// </remarks>
    [JsonPropertyName("template_uuid")]
    [JsonPropertyOrder(12)]
    public string? TemplateId { get; set; }

    /// <summary>
    /// Optional template variables that will be used to generate actual subject, text and html from email template.
    /// </summary>
    /// <remarks>
    /// Optional. Will be used only in case <see cref="TemplateId"/> is set.
    /// </remarks>
    [JsonPropertyName("template_variables")]
    [JsonPropertyOrder(13)]
    public object? TemplateVariables { get; set; }
}
