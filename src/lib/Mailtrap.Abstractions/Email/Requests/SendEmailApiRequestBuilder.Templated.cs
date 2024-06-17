// -----------------------------------------------------------------------
// <copyright file="SendEmailApiRequestBuilder.Templated.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Requests;


public static partial class SendEmailApiRequestBuilder
{
    /// <summary>
    /// Sets provided template ID to the request.
    /// </summary>
    public static T WithTemplate<T>(this T request, string templateId) where T : TemplatedSendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(templateId, nameof(templateId));

        request.TemplateId = templateId;

        return request;
    }

    /// <summary>
    /// Sets provided template variables object to the request.
    /// </summary>
    public static T WithTemplateVariables<T>(this T request, object? variables) where T : TemplatedSendEmailApiRequest
    {
        Ensure.NotNull(request, nameof(request));

        request.TemplateVariables = variables;

        return request;
    }
}
