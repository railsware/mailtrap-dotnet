// -----------------------------------------------------------------------
// <copyright file="EmailSendApiRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Models;


/// <summary>
/// Request for sending email
/// </summary>
public record EmailSendApiRequest
{
    [JsonPropertyName("from")]
    public EmailParty? Sender { get; set; }

    /// <summary>
    /// An collection of <see cref="EmailParty"/> who will receive a copy of your email.
    /// </summary>
    /// <remarks>
    /// Should contain at least one recipient.<br />
    /// Each object in this collection must contain the recipient's email address.<br />
    /// Each object in the collection may optionally contain the recipient's name.
    /// </remarks>
    [JsonPropertyName("to")]
    public IList<EmailParty> Recipients { get; } = new List<EmailParty>(1); // We should always have at least one recipient

    /// <summary>
    /// An collection of <see cref="EmailParty"/> who will receive a carbon copy of your email.
    /// </summary>
    /// <remarks>
    /// Each object in this collection must contain the recipient's email address.<br />
    /// Each object in the collection may optionally contain the recipient's name.
    /// </remarks>
    [JsonPropertyName("cc")]
    public IList<EmailParty> CarbonCopies { get; } = [];

    /// <summary>
    /// An collection of <see cref="EmailParty"/> who will receive a blind carbon copy of your email.
    /// </summary>
    /// <remarks>
    /// Each object in this collection must contain the recipient's email address.<br />
    /// Each object in the collection may optionally contain the recipient's name.
    /// </remarks>
    [JsonPropertyName("bcc")]
    public IList<EmailParty> BlindCarbonCopies { get; } = [];

    /// <summary>
    /// The global or 'message level' subject of your email.<br />
    /// This may be overridden by subject lines set in personalizations.
    /// </summary>
    /// <remarks>
    /// Should be non-empty string
    /// </remarks>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// Text version of the body of the email.<br />
    /// Can be used along with HtmlBody to create a fallback for non-html clients.
    /// </summary>
    /// <remarks>
    /// Required in the absence of HtmlBody.
    /// </remarks>
    [JsonPropertyName("text")]
    public string? TextBody { get; set; }

    /// <summary>
    /// HTML version of the body of the email.<br />
    /// Can be used along with HtmlBody to create a fallback for non-html clients.
    /// </summary>
    /// <remarks>
    /// Required in the absence of TextBody.
    /// </remarks>
    [JsonPropertyName("html")]
    public string? HtmlBody { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("attachments")]
    public IList<Attachment> Attachments { get; } = [];

    /// <summary>
    /// An object containing key/value pairs of header names and the value to substitute for them.
    /// <para>
    /// The key/value pairs must be strings.<br/>
    /// You must ensure these are properly encoded if they contain unicode characters.<br />
    /// These headers cannot be one of the reserved headers.<br />
    /// "Content-Transfer-Encoding" header will be ignored and replaced with "quoted-printable".
    /// </para>
    /// </summary>
    [JsonPropertyName("headers")]
    public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();

    /// <summary>
    /// Values that are specific to the entire send that will be carried along with the email and its activity data.
    /// <para>
    /// Total size of custom variables in JSON form must not exceed 1000 bytes.
    /// </para>
    /// </summary>
    [JsonPropertyName("custom_variables")]
    public IDictionary<string, string> Variables { get; } = new Dictionary<string, string>();


    /// <summary>
    /// Internal parameterless constructor to be used in builder helper
    /// </summary>
    internal EmailSendApiRequest() { }

    /// <summary>
    /// Primary constructor with required parameters
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="recipient"></param>
    /// <param name="subject"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public EmailSendApiRequest(EmailParty sender, EmailParty recipient, string subject)
    {
        Ensure.NotNull(sender, nameof(sender));
        Ensure.NotNull(recipient, nameof(recipient));
        Ensure.NotNullOrEmpty(subject, nameof(subject));

        Sender = sender;
        Subject = subject;

        Recipients.Add(recipient);
    }
}
