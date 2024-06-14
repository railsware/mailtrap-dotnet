// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequest.cs" company="Railsware Products Studio, LLC">
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
    /// <see cref="EmailParty"/> instance representing email's sender.
    /// </summary>
    /// <remarks>
    /// Required.
    /// </remarks>
    [JsonPropertyName("from")]
    [JsonPropertyOrder(1)]
    public EmailParty? Sender { get; set; }

    /// <summary>
    /// A collection of <see cref="EmailParty"/> who will receive a copy of your email.
    /// </summary>
    /// <remarks>
    /// Must contain at least one recipient, but not more than 1000.<br />
    /// Each object in this collection must contain the recipient's email address.<br />
    /// Each object in this collection may optionally contain the recipient's name.
    /// </remarks>
    [JsonPropertyName("to")]
    [JsonPropertyOrder(2)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<EmailParty> Recipients { get; } = new List<EmailParty>(1); // We should always have at least one recipient

    /// <summary>
    /// A collection of <see cref="EmailParty"/> who will receive a carbon copy of your email.
    /// </summary>
    /// <remarks>
    /// Must contain less or equal to 1000 recipients.<br />
    /// Each object in this collection must contain the recipient's email address.<br />
    /// Each object in this collection may optionally contain the recipient's name.
    /// </remarks>
    [JsonPropertyName("cc")]
    [JsonPropertyOrder(3)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<EmailParty> CarbonCopies { get; } = [];

    /// <summary>
    /// A collection of <see cref="EmailParty"/> who will receive a blind carbon copy of your email.
    /// </summary>
    /// <remarks>
    /// Must contain less or equal to 1000 recipients.<br />
    /// Each object in this collection must contain the recipient's email address.<br />
    /// Each object in this collection may optionally contain the recipient's name.
    /// </remarks>
    [JsonPropertyName("bcc")]
    [JsonPropertyOrder(4)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<EmailParty> BlindCarbonCopies { get; } = [];

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
