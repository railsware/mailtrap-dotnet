// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestBuilder.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Requests;


/// <summary>
/// A set of helper methods to streamline <see cref="SendEmailRequest"/> instance construction in a fluent style.
/// </summary>
public static class SendEmailRequestBuilder
{
    #region From

    /// <summary>
    /// Sets provided sender to the request.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> or <paramref name="sender"/> is <see langword="null"/>.
    /// </exception>
    public static SendEmailRequest From(this SendEmailRequest request, EmailAddress sender)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(sender, nameof(sender));

        request.From = sender;

        return request;
    }

    /// <summary>
    /// Sets provided sender to the request.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> is <see langword="null"/>
    /// or <paramref name="emailAddress"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public static SendEmailRequest From(this SendEmailRequest request, string emailAddress, string? displayName = default)
    {
        Ensure.NotNull(request, nameof(request));

        return request.From(new EmailAddress(emailAddress, displayName));
    }

    #endregion



    #region To

    /// <summary>
    /// Adds provided collection of recipients to the request's TO collection.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> or <paramref name="recipients"/> is <see langword="null"/>.
    /// </exception>
    public static SendEmailRequest To(this SendEmailRequest request, params EmailAddress[] recipients)
    {
        Ensure.NotNull(request, nameof(request));

        request.To.AddRange(recipients);

        return request;
    }

    /// <summary>
    /// Adds provided recipient to the request's TO collection.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> is <see langword="null"/>
    /// or <paramref name="emailAddress"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public static SendEmailRequest To(this SendEmailRequest request, string emailAddress, string? displayName = default)
    {
        Ensure.NotNull(request, nameof(request));

        return request.To(new EmailAddress(emailAddress, displayName));
    }

    #endregion



    #region Cc

    /// <summary>
    /// Adds provided collection of recipients to the request's CC collection.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> or <paramref name="recipients"/> is <see langword="null"/>.
    /// </exception>
    public static SendEmailRequest Cc(this SendEmailRequest request, params EmailAddress[] recipients)
    {
        Ensure.NotNull(request, nameof(request));

        request.Cc.AddRange(recipients);

        return request;
    }

    /// <summary>
    /// Adds provided recipient to the request's CC collection.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> is <see langword="null"/>
    /// or <paramref name="emailAddress"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public static SendEmailRequest Cc(this SendEmailRequest request, string emailAddress, string? displayName = default)
    {
        Ensure.NotNull(request, nameof(request));

        return request.Cc(new EmailAddress(emailAddress, displayName));
    }

    #endregion



    #region Bcc

    /// <summary>
    /// Adds provided collection of recipients to the request's BCC collection.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> or <paramref name="recipients"/> is <see langword="null"/>.
    /// </exception>
    public static SendEmailRequest Bcc(this SendEmailRequest request, params EmailAddress[] recipients)
    {
        Ensure.NotNull(request, nameof(request));

        request.Bcc.AddRange(recipients);

        return request;
    }

    /// <summary>
    /// Adds provided recipient to the request's BCC collection.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> is <see langword="null"/>
    /// or <paramref name="emailAddress"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public static SendEmailRequest Bcc(this SendEmailRequest request, string emailAddress, string? displayName = default)
    {
        Ensure.NotNull(request, nameof(request));

        return request.Bcc(new EmailAddress(emailAddress, displayName));
    }

    #endregion



    #region Attachments

    /// <summary>
    /// Adds provided collection of attachments to the request's attachments collection.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> or <paramref name="attachments"/> is <see langword="null"/>.
    /// </exception>
    public static SendEmailRequest Attach(this SendEmailRequest request, params Attachment[] attachments)
    {
        Ensure.NotNull(request, nameof(request));

        request.Attachments.AddRange(attachments);

        return request;
    }

    /// <summary>
    /// Adds provided attachment to the request's attachments collection.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> is <see langword="null"/>
    /// or <paramref name="content"/> is <see langword="null"/> or <see cref="string.Empty"/>
    /// or <paramref name="filename"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public static SendEmailRequest Attach(this SendEmailRequest request,
        string content,
        string filename,
        DispositionType? dispositionType = default,
        string? mimeType = default,
        string? contentId = default)
    {
        Ensure.NotNull(request, nameof(request));

        return request.Attach(new Attachment(content, filename, dispositionType, mimeType, contentId));
    }

    #endregion



    #region Headers

    /// <summary>
    /// Adds provided collection of headers to the request.
    /// </summary>
    /// <remarks>
    /// Any existing headers with the same keys will be overridden.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> or <paramref name="headers"/> is <see langword="null"/>.
    /// </exception>
    public static SendEmailRequest Header(this SendEmailRequest request, params RequestHeader[] headers)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(headers, nameof(headers));

        foreach (var header in headers)
        {
            request.Header(header.Key, header.Value);
        }

        return request;
    }

    /// <summary>
    /// Adds provided header to the request.
    /// </summary>
    /// <remarks>
    /// Any existing header with the same key will be overridden.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> is <see langword="null"/>
    /// or <paramref name="key"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public static SendEmailRequest Header(this SendEmailRequest request, string key, string value)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(key, nameof(key));

        request.Headers[key] = value;

        return request;
    }

    #endregion



    #region Custom Variables

    /// <summary>
    /// Adds provided collection of custom variables to the request.
    /// </summary>
    /// <remarks>
    /// Any existing variables with the same keys will be overridden.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> or <paramref name="variables"/> is <see langword="null"/>.
    /// </exception>
    public static SendEmailRequest CustomVariable(this SendEmailRequest request, params RequestVariable[] variables)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(variables, nameof(variables));

        foreach (var variable in variables)
        {
            request.CustomVariable(variable.Key, variable.Value);
        }

        return request;
    }

    /// <summary>
    /// Adds provided variable to the request.
    /// </summary>
    /// <remarks>
    /// Any existing variable with the same key will be overridden.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> is <see langword="null"/>
    /// or <paramref name="key"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public static SendEmailRequest CustomVariable(this SendEmailRequest request, string key, string value)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(key, nameof(key));

        request.CustomVariables[key] = value;

        return request;
    }

    #endregion



    /// <summary>
    /// Sets provided subject to the request.
    /// </summary>
    /// <remarks>
    /// Subject must remain <see langword="null"/> if <see cref="Template(SendEmailRequest, string)"/> is used to create email from template.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> is <see langword="null"/>
    /// or <paramref name="subject"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public static SendEmailRequest Subject(this SendEmailRequest request, string subject)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(subject, nameof(subject));

        request.Subject = subject;

        return request;
    }

    /// <summary>
    /// Sets provided text to the request's text body.
    /// </summary>
    /// <remarks>
    /// TextBody must remain <see langword="null"/> if <see cref="Template(SendEmailRequest, string)"/> is used to create email from template.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    public static SendEmailRequest Text(this SendEmailRequest request, string? text)
    {
        Ensure.NotNull(request, nameof(request));

        request.TextBody = text;

        return request;
    }

    /// <summary>
    /// Sets provided HTML text to the request's HTML body.
    /// </summary>
    /// <remarks>
    /// HtmlBody must remain <see langword="null"/> if <see cref="Template(SendEmailRequest, string)"/> is used to create email from template.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    public static SendEmailRequest Html(this SendEmailRequest request, string? html)
    {
        Ensure.NotNull(request, nameof(request));

        request.HtmlBody = html;

        return request;
    }

    /// <summary>
    /// Sets provided category to the request.
    /// </summary>
    /// <remarks>
    /// Category must remain <see langword="null"/> if <see cref="Template(SendEmailRequest, string)"/> is used to create email from template.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    public static SendEmailRequest Category(this SendEmailRequest request, string? category)
    {
        Ensure.NotNull(request, nameof(request));

        request.Category = category;

        return request;
    }



    /// <summary>
    /// Sets provided template ID to the request.
    /// </summary>
    /// <remarks>
    /// If TemplateId is set, then Subject, TextBody, HtmlBody and Category properties are forbidden and must be set to <see langword="null"/>.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> is <see langword="null"/>
    /// or <paramref name="templateId"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public static SendEmailRequest Template(this SendEmailRequest request, string templateId)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(templateId, nameof(templateId));

        request.TemplateId = templateId;

        return request;
    }

    /// <summary>
    /// Sets provided template variables object to the request.
    /// </summary>
    /// <remarks>
    /// Will be used only in case template is set.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    public static SendEmailRequest TemplateVariables(this SendEmailRequest request, object? variables)
    {
        Ensure.NotNull(request, nameof(request));

        request.TemplateVariables = variables;

        return request;
    }
}
