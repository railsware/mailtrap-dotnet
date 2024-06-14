// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilder.Regular.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Requests;


public static partial class SendEmailApiRequestBuilder
{
    public static T WithSubject<T>(this T request, string subject) where T : RegularSendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(subject, nameof(subject));

        request.Subject = subject;

        return request;
    }

    public static T WithTextBody<T>(this T request, string? text) where T : RegularSendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));

        request.TextBody = text;

        return request;
    }

    public static T WithHtmlBody<T>(this T request, string? html) where T : RegularSendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));

        request.HtmlBody = html;

        return request;
    }

    public static T WithCategory<T>(this T request, string? category) where T : RegularSendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));

        request.Category = category;

        return request;
    }
}
