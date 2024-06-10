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
    public Recipient? Sender { get; set; }

    [JsonPropertyName("to")]
    public IList<Recipient> Recipients { get; } = new List<Recipient>(1); // We should always have at least one recipient

    public string? Subject { get; set; }

    [JsonPropertyName("text")]
    public string? TextBody { get; set; }

    [JsonPropertyName("html")]
    public string? HtmlBody { get; set; }

    public IList<Attachment> Attachments { get; } = [];


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
    /// <exception cref="ArgumentException"></exception>
    public EmailSendApiRequest(Recipient sender, Recipient recipient, string subject)
    {
        Ensure.NotNull(sender, nameof(sender));
        Ensure.NotNull(recipient, nameof(recipient));
        Ensure.NotNullOrEmpty(subject, nameof(subject));

        Sender = sender;
        Subject = subject;

        Recipients.Add(recipient);
    }


    public void AddRecipients(params Recipient[] recipients)
    {
        Ensure.NotNull(recipients, nameof(recipients));

        Recipients.AddRange(recipients);
    }

    public void AddAttachments(params Attachment[] attachments)
    {
        Ensure.NotNull(attachments, nameof(attachments));

        Attachments.AddRange(attachments);
    }
}
