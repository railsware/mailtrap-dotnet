// -----------------------------------------------------------------------
// <copyright file="EmailSendApiRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Requests;


/// <summary>
/// Generic request for sending emails
/// </summary>
public abstract record SendEmailApiRequest
{
    /// <summary>
    /// Email's sender
    /// </summary>
    [JsonPropertyName("from")]
    public EmailParty? Sender { get; set; }

    /// <summary>
    /// A collection of <see cref="EmailParty"/> who will receive a copy of your email.
    /// </summary>
    /// <remarks>
    /// Should contain at least one recipient.<br />
    /// Each object in this collection must contain the recipient's email address.<br />
    /// Each object in the collection may optionally contain the recipient's name.
    /// </remarks>
    [JsonPropertyName("to")]
    public IList<EmailParty> Recipients { get; } = new List<EmailParty>(1); // We should always have at least one recipient

    /// <summary>
    /// A collection of <see cref="EmailParty"/> who will receive a carbon copy of your email.
    /// </summary>
    /// <remarks>
    /// Each object in this collection must contain the recipient's email address.<br />
    /// Each object in the collection may optionally contain the recipient's name.
    /// </remarks>
    [JsonPropertyName("cc")]
    public IList<EmailParty> CarbonCopies { get; } = [];

    /// <summary>
    /// A collection of <see cref="EmailParty"/> who will receive a blind carbon copy of your email.
    /// </summary>
    /// <remarks>
    /// Each object in this collection must contain the recipient's email address.<br />
    /// Each object in the collection may optionally contain the recipient's name.
    /// </remarks>
    [JsonPropertyName("bcc")]
    public IList<EmailParty> BlindCarbonCopies { get; } = [];

    /// <summary>
    /// A collection of objects where you can specify any attachments you want to include.
    /// </summary>
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
    public IDictionary<string, string> CustomVariables { get; } = new Dictionary<string, string>();


    /// <summary>
    /// Parameterless constructor to be used in builder helper
    /// </summary>
    protected SendEmailApiRequest() { }

    /// <summary>
    /// Primary constructor with required parameters
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="recipient"></param>
    /// <exception cref="ArgumentNullException"></exception>
    protected SendEmailApiRequest(EmailParty sender, EmailParty recipient)
    {
        Ensure.NotNull(sender, nameof(sender));
        Ensure.NotNull(recipient, nameof(recipient));

        Sender = sender;
        Recipients.Add(recipient);
    }
}
