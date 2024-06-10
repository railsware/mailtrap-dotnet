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

    public static EmailSendApiRequest WithSender(this EmailSendApiRequest request, Recipient sender)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(sender, nameof(sender));

        request.Sender = sender;

        return request;
    }

    public static EmailSendApiRequest WithSender(this EmailSendApiRequest request, string emailAddress, string? displayName = null)
    {
        Ensure.NotNull(request, nameof(request));

        request.Sender = new Recipient(emailAddress, displayName);

        return request;
    }

    public static EmailSendApiRequest WithSubject(this EmailSendApiRequest request, string subject)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(subject, nameof(subject));

        request.Subject = subject;

        return request;
    }

    public static EmailSendApiRequest WithRecipient(this EmailSendApiRequest request, string emailAddress, string? displayName = null)
    {
        Ensure.NotNull(request, nameof(request));

        request.Recipients.Add(new Recipient(emailAddress, displayName));

        return request;
    }

    public static EmailSendApiRequest WithRecipients(this EmailSendApiRequest request, params Recipient[] recipients)
    {
        Ensure.NotNull(request, nameof(request));

        request.AddRecipients(recipients);

        return request;
    }

    public static EmailSendApiRequest WithAttachment(this EmailSendApiRequest request,
        string content,
        string filename,
        DispositionType? dispositionType = null,
        string? mimeType = null)
    {
        Ensure.NotNull(request, nameof(request));

        request.Attachments.Add(new Attachment(content, filename, dispositionType, mimeType));

        return request;
    }

    public static EmailSendApiRequest WithAttachments(this EmailSendApiRequest request, params Attachment[] attachments)
    {
        Ensure.NotNull(request, nameof(request));

        request.AddAttachments(attachments);

        return request;
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
