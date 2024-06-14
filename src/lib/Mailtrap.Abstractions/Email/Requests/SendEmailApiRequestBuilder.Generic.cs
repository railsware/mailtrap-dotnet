// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilder.Generic.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Requests;


public static partial class SendEmailApiRequestBuilder
{
    public static T WithSender<T>(this T request, EmailParty sender) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(sender, nameof(sender));

        request.Sender = sender;

        return request;
    }

    public static T WithSender<T>(this T request, string emailAddress, string? displayName = null) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(emailAddress, nameof(emailAddress));

        return request.WithSender(new EmailParty(emailAddress, displayName));
    }


    public static T WithRecipients<T>(this T request, params EmailParty[] recipients) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipients, nameof(recipients));

        request.Recipients.AddRange(recipients);

        return request;
    }

    public static T WithRecipient<T>(this T request, EmailParty recipient) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipient, nameof(recipient));

        return request.WithRecipients(recipient);
    }

    public static T WithRecipient<T>(this T request, string emailAddress, string? displayName = null) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(emailAddress, nameof(emailAddress));

        return request.WithRecipient(new EmailParty(emailAddress, displayName));
    }

    public static T WithCopies<T>(this T request, params EmailParty[] carbonCopies) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(carbonCopies, nameof(carbonCopies));

        request.CarbonCopies.AddRange(carbonCopies);

        return request;
    }

    public static T WithCopy<T>(this T request, EmailParty carbonCopy) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(carbonCopy, nameof(carbonCopy));

        return request.WithCopy(carbonCopy);
    }

    public static T WithCopy<T>(this T request, string emailAddress, string? displayName = null) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(emailAddress, nameof(emailAddress));

        return request.WithCopy(new EmailParty(emailAddress, displayName));
    }


    public static T WithBlindCopies<T>(this T request, params EmailParty[] blindCarbonCopies) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(blindCarbonCopies, nameof(blindCarbonCopies));

        request.CarbonCopies.AddRange(blindCarbonCopies);

        return request;
    }

    public static T WithBlindCopy<T>(this T request, EmailParty blindCarbonCopy) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(blindCarbonCopy, nameof(blindCarbonCopy));

        return request.WithBlindCopy(blindCarbonCopy);
    }

    public static T WithBlindCopy<T>(this T request, string emailAddress, string? displayName = null) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(emailAddress, nameof(emailAddress));

        return request.WithBlindCopy(new EmailParty(emailAddress, displayName));
    }


    public static T WithAttachments<T>(this T request, params Attachment[] attachments) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(attachments, nameof(attachments));

        request.Attachments.AddRange(attachments);

        return request;
    }

    public static T WithAttachment<T>(this T request, Attachment attachment) where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(attachment, nameof(attachment));

        return request.WithAttachments(attachment);
    }

    public static T WithAttachment<T>(this T request,
        string content,
        string filename,
        DispositionType? dispositionType = null,
        string? mimeType = null)
         where T : SendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));

        return request.WithAttachment(new Attachment(content, filename, dispositionType, mimeType));
    }
}
