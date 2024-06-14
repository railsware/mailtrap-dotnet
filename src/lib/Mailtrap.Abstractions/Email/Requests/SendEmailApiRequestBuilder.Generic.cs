// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilder.Generic.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Requests;


public static partial class SendEmailApiRequestBuilder
{
    /// <summary>
    /// Sets provided sender to the request.
    /// </summary>
    public static T WithSender<T>(this T request, EmailParty sender) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(sender, nameof(sender));

        request.Sender = sender;

        return request;
    }

    /// <summary>
    /// Sets provided sender to the request.
    /// </summary>
    public static T WithSender<T>(this T request, string emailAddress, string? displayName = default) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(emailAddress, nameof(emailAddress));

        return request.WithSender(new EmailParty(emailAddress, displayName));
    }

    /// <summary>
    /// Adds provided collection of recipients to the request's TO collection.
    /// </summary>
    public static T WithRecipients<T>(this T request, params EmailParty[] recipients) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipients, nameof(recipients));

        request.Recipients.AddRange(recipients);

        return request;
    }

    /// <summary>
    /// Adds provided recipient to the request's TO collection.
    /// </summary>
    public static T WithRecipient<T>(this T request, EmailParty recipient) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipient, nameof(recipient));

        return request.WithRecipients(recipient);
    }

    /// <summary>
    /// Adds provided recipient to the request's TO collection.
    /// </summary>
    public static T WithRecipient<T>(this T request, string emailAddress, string? displayName = default) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(emailAddress, nameof(emailAddress));

        return request.WithRecipient(new EmailParty(emailAddress, displayName));
    }

    /// <summary>
    /// Adds provided collection of recipients to the request's CC collection.
    /// </summary>
    public static T WithCopies<T>(this T request, params EmailParty[] recipients) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipients, nameof(recipients));

        request.CarbonCopies.AddRange(recipients);

        return request;
    }

    /// <summary>
    /// Adds provided recipient to the request's CC collection.
    /// </summary>
    public static T WithCopy<T>(this T request, EmailParty recipient) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipient, nameof(recipient));

        return request.WithCopy(recipient);
    }

    /// <summary>
    /// Adds provided recipient to the request's CC collection.
    /// </summary>
    public static T WithCopy<T>(this T request, string emailAddress, string? displayName = default) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(emailAddress, nameof(emailAddress));

        return request.WithCopy(new EmailParty(emailAddress, displayName));
    }

    /// <summary>
    /// Adds provided collection of recipients to the request's BCC collection.
    /// </summary>
    public static T WithBlindCopies<T>(this T request, params EmailParty[] recipients) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipients, nameof(recipients));

        request.CarbonCopies.AddRange(recipients);

        return request;
    }

    /// <summary>
    /// Adds provided recipient to the request's BCC collection.
    /// </summary>
    public static T WithBlindCopy<T>(this T request, EmailParty recipient) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipient, nameof(recipient));

        return request.WithBlindCopy(recipient);
    }

    /// <summary>
    /// Adds provided recipient to the request's BCC collection.
    /// </summary>
    public static T WithBlindCopy<T>(this T request, string emailAddress, string? displayName = default) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(emailAddress, nameof(emailAddress));

        return request.WithBlindCopy(new EmailParty(emailAddress, displayName));
    }

    /// <summary>
    /// Adds provided collection of attachments to the request's attacments collection.
    /// </summary>
    public static T WithAttachments<T>(this T request, params Attachment[] attachments) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(attachments, nameof(attachments));

        request.Attachments.AddRange(attachments);

        return request;
    }

    /// <summary>
    /// Adds provided attachment to the request's attacments collection.
    /// </summary>
    public static T WithAttachment<T>(this T request, Attachment attachment) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(attachment, nameof(attachment));

        return request.WithAttachments(attachment);
    }

    /// <summary>
    /// Adds provided attachment to the request's attacments collection.
    /// </summary>
    public static T WithAttachment<T>(this T request,
        string content,
        string filename,
        DispositionType? dispositionType = default,
        string? mimeType = default,
        string? contentId = default)
         where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));

        return request.WithAttachment(new Attachment(content, filename, dispositionType, mimeType, contentId));
    }
}
