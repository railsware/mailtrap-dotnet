// -----------------------------------------------------------------------
// <copyright file="EmailSendApiRequestBuilder.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap;


/// <summary>
/// A set of helper methods to streamline <see cref="EmailSendApiRequest"/> instance construction in a fluent style.
/// </summary>
public static class EmailSendApiRequestBuilder
{
    public static EmailSendApiRequest Create() => new();

    public static EmailSendApiRequest WithSender(this EmailSendApiRequest request, EmailParty sender)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(sender, nameof(sender));

        request.Sender = sender;

        return request;
    }

    public static EmailSendApiRequest WithSender(this EmailSendApiRequest request, string emailAddress, string? displayName = null)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(emailAddress, nameof(emailAddress));

        return request.WithSender(new EmailParty(emailAddress, displayName));
    }

    public static EmailSendApiRequest WithSubject(this EmailSendApiRequest request, string subject)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(subject, nameof(subject));

        request.Subject = subject;

        return request;
    }

    public static EmailSendApiRequest WithRecipients(this EmailSendApiRequest request, params EmailParty[] recipients)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipients, nameof(recipients));

        request.Recipients.AddRange(recipients);

        return request;
    }

    public static EmailSendApiRequest WithRecipient(this EmailSendApiRequest request, EmailParty recipient)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipient, nameof(recipient));

        return request.WithRecipients(recipient);
    }

    public static EmailSendApiRequest WithRecipient(this EmailSendApiRequest request, string emailAddress, string? displayName = null)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(emailAddress, nameof(emailAddress));

        return request.WithRecipient(new EmailParty(emailAddress, displayName));
    }

    public static EmailSendApiRequest WithAttachments(this EmailSendApiRequest request, params Attachment[] attachments)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(attachments, nameof(attachments));

        request.Attachments.AddRange(attachments);

        return request;
    }

    public static EmailSendApiRequest WithAttachment(this EmailSendApiRequest request, Attachment attachment)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(attachment, nameof(attachment));

        return request.WithAttachments(attachment);
    }

    public static EmailSendApiRequest WithAttachment(this EmailSendApiRequest request,
        string content,
        string filename,
        DispositionType? dispositionType = null,
        string? mimeType = null)
    {
        Ensure.NotNull(request, nameof(request));

        return request.WithAttachment(new Attachment(content, filename, dispositionType, mimeType));
    }

    public static EmailSendApiRequest WithTextBody(this EmailSendApiRequest request, string? text)
    {
        Ensure.NotNull(request, nameof(request));

        request.TextBody = text;

        return request;
    }

    public static EmailSendApiRequest WithHtmlBody(this EmailSendApiRequest request, string? html)
    {
        Ensure.NotNull(request, nameof(request));

        request.HtmlBody = html;

        return request;
    }
}
