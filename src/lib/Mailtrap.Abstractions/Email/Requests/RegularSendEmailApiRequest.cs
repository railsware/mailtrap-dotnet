// -----------------------------------------------------------------------
// <copyright file="RegularSendEmailApiRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Requests;


/// <summary>
/// Request for sending email with html and(or) plain text body
/// </summary>
public record RegularSendEmailApiRequest : SendEmailApiRequest
{
    /// <summary>
    /// The global or 'message level' subject of your email.<br />
    /// This may be overridden by subject lines set in personalizations.
    /// </summary>
    /// <remarks>
    /// Required. Should be non-empty string.
    /// </remarks>
    [JsonPropertyName("subject")]
    [JsonPropertyOrder(8)]
    public string? Subject { get; set; }

    /// <summary>
    /// Text version of the body of the email.<br />
    /// Can be used along with HtmlBody to create a fallback for non-html clients.
    /// </summary>
    /// <remarks>
    /// Required in the absence of HtmlBody.
    /// </remarks>
    [JsonPropertyName("text")]
    [JsonPropertyOrder(9)]
    public string? TextBody { get; set; }

    /// <summary>
    /// HTML version of the body of the email.<br />
    /// Can be used along with HtmlBody to create a fallback for non-html clients.
    /// </summary>
    /// <remarks>
    /// Required in the absence of TextBody.
    /// </remarks>
    [JsonPropertyName("html")]
    [JsonPropertyOrder(10)]
    public string? HtmlBody { get; set; }

    [JsonPropertyName("category")]
    [JsonPropertyOrder(11)]
    public string? Category { get; set; }


    /// <inheritdoc />
    public RegularSendEmailApiRequest() { }

    /// <summary>
    /// Primary constructor with required parameters
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="recipient"></param>
    /// <param name="subject"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public RegularSendEmailApiRequest(EmailParty sender, EmailParty recipient, string subject)
        : base(sender, recipient)
    {
        Ensure.NotNullOrEmpty(subject, nameof(subject));

        Subject = subject;
    }
}
