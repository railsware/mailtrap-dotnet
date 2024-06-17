// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilder.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Requests;


/// <summary>
/// A set of helper methods to streamline <see cref="SendEmailApiRequest"/> instance construction in a fluent style.
/// </summary>
public static partial class SendEmailApiRequestBuilder
{
    #region Create

    /// <summary>
    /// Creates a new instance of request of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Api request type, derived from <see cref="SendEmailApiRequest"/></typeparam>
    /// <returns></returns>
    public static T Create<T>() where T : SendEmailApiRequest, new() => new();

    #endregion



    #region Sender

    /// <summary>
    /// Sets provided sender to the request.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
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
    /// <exception cref="ArgumentNullException"></exception>
    public static T WithSender<T>(this T request, string emailAddress, string? displayName = default) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));

        return request.WithSender(new EmailParty(emailAddress, displayName));
    }

    #endregion



    #region TO

    /// <summary>
    /// Adds provided collection of recipients to the request's TO collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
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
    /// <exception cref="ArgumentNullException"></exception>
    public static T WithRecipient<T>(this T request, EmailParty recipient) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipient, nameof(recipient));

        return request.WithRecipients(recipient);
    }

    /// <summary>
    /// Adds provided recipient to the request's TO collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public static T WithRecipient<T>(this T request, string emailAddress, string? displayName = default) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));

        return request.WithRecipient(new EmailParty(emailAddress, displayName));
    }

    #endregion



    #region CC

    /// <summary>
    /// Adds provided collection of recipients to the request's CC collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
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
    /// <exception cref="ArgumentNullException"></exception>
    public static T WithCopy<T>(this T request, EmailParty recipient) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipient, nameof(recipient));

        return request.WithCopies(recipient);
    }

    /// <summary>
    /// Adds provided recipient to the request's CC collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public static T WithCopy<T>(this T request, string emailAddress, string? displayName = default) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));

        return request.WithCopy(new EmailParty(emailAddress, displayName));
    }

    #endregion



    #region BCC

    /// <summary>
    /// Adds provided collection of recipients to the request's BCC collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public static T WithBlindCopies<T>(this T request, params EmailParty[] recipients) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipients, nameof(recipients));

        request.BlindCarbonCopies.AddRange(recipients);

        return request;
    }

    /// <summary>
    /// Adds provided recipient to the request's BCC collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public static T WithBlindCopy<T>(this T request, EmailParty recipient) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipient, nameof(recipient));

        return request.WithBlindCopies(recipient);
    }

    /// <summary>
    /// Adds provided recipient to the request's BCC collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public static T WithBlindCopy<T>(this T request, string emailAddress, string? displayName = default) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));

        return request.WithBlindCopy(new EmailParty(emailAddress, displayName));
    }

    #endregion



    #region Attachments

    /// <summary>
    /// Adds provided collection of attachments to the request's attacments collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
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
    /// <exception cref="ArgumentNullException"></exception>
    public static T WithAttachment<T>(this T request, Attachment attachment) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(attachment, nameof(attachment));

        return request.WithAttachments(attachment);
    }

    /// <summary>
    /// Adds provided attachment to the request's attacments collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
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

    #endregion
}
