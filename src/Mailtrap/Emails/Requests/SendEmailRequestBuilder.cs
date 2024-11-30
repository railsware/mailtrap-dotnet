// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestBuilder.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Requests;


/// <summary>
/// A set of helper methods to streamline <see cref="SendEmailRequest"/> instance construction using fluent style.
/// </summary>
public static class SendEmailRequestBuilder
{
    #region From

    /// <summary>
    /// Sets provided <paramref name="sender"/> to the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <see cref="SendEmailRequest"/> instance to update.
    /// </param>
    ///
    /// <param name="sender">
    /// <see cref="EmailAddress"/> object to initialize request's <see cref="SendEmailRequest.From"/> property.
    /// </param>
    ///
    /// <returns>
    /// Updated <see cref="SendEmailRequest"/> instance so subsequent calls can be chained.
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> or <paramref name="sender"/> is <see langword="null"/>.
    /// </exception>
    ///
    /// <remarks>
    /// Subsequent calls will override value that was set before (last wins).
    /// </remarks>
    public static SendEmailRequest From(this SendEmailRequest request, EmailAddress sender)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(sender, nameof(sender));

        request.From = sender;

        return request;
    }

    /// <summary>
    /// Sets provided <paramref name="email"/> and <paramref name="displayName"/> as sender
    /// for the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/param[@name='request']"/>
    /// </param>
    ///
    /// <param name="email">
    /// <para>
    /// Sender's email address.
    /// </para>
    /// <para>
    /// Required. Must be valid email address.
    /// </para>
    /// </param>
    /// 
    /// <param name="displayName">
    /// Optional sender's display name.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> is <see langword="null"/>.<br />
    /// When <paramref name="email"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    ///
    /// <remarks>
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/remarks"/>
    /// </remarks>
    public static SendEmailRequest From(this SendEmailRequest request, string email, string? displayName = default)
    {
        Ensure.NotNull(request, nameof(request));

        return request.From(new EmailAddress(email, displayName));
    }

    #endregion



    #region To

    /// <summary>
    /// Adds provided <paramref name="recipients"/> to the <see cref="SendEmailRequest.To"/>
    /// recipient collection of the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="recipients">
    /// One or more <see cref="EmailAddress"/> objects to add to the request's recipient collection.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException" id="ArgumentNullException">
    /// When <paramref name="request"/> or <paramref name="recipients"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <remarks>
    /// Duplicates can be added by calling this method multiple times with the same recipients.
    /// </remarks>
    public static SendEmailRequest To(this SendEmailRequest request, params EmailAddress[] recipients)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipients, nameof(recipients));

        request.To.AddRange(recipients);

        return request;
    }

    /// <summary>
    /// Adds provided <paramref name="email"/> and <paramref name="displayName"/> tuple as recipient
    /// to the <see cref="SendEmailRequest.To"/> recipient collection of the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="To(SendEmailRequest, EmailAddress[])" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="email">
    /// <para>
    /// Recipient's email address.
    /// </para>
    /// <para>
    /// Required. Must be valid email address.
    /// </para>
    /// </param>
    /// 
    /// <param name="displayName">
    /// Optional recipient's display name.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="To(SendEmailRequest, EmailAddress[])" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> is <see langword="null"/>.<br />
    /// When <paramref name="email"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    /// 
    /// <remarks>
    /// <inheritdoc cref="To(SendEmailRequest, EmailAddress[])" path="/remarks"/>
    /// </remarks>
    public static SendEmailRequest To(this SendEmailRequest request, string email, string? displayName = default)
    {
        Ensure.NotNull(request, nameof(request));

        return request.To(new EmailAddress(email, displayName));
    }

    #endregion



    #region Cc

    /// <summary>
    /// Adds provided <paramref name="recipients"/> to the <see cref="SendEmailRequest.Cc"/>
    /// recipient collection of the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="To(SendEmailRequest, EmailAddress[])" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="recipients">
    /// <inheritdoc cref="To(SendEmailRequest, EmailAddress[])" path="/param[@name='recipients']"/>
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="To(SendEmailRequest, EmailAddress[])" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException" id="ArgumentNullException">
    /// When <paramref name="request"/> or <paramref name="recipients"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <remarks>
    /// <inheritdoc cref="To(SendEmailRequest, EmailAddress[])" path="/remarks"/>
    /// </remarks>
    public static SendEmailRequest Cc(this SendEmailRequest request, params EmailAddress[] recipients)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipients, nameof(recipients));

        request.Cc.AddRange(recipients);

        return request;
    }

    /// <summary>
    /// Adds provided <paramref name="email"/> and <paramref name="displayName"/> tuple as recipient
    /// to the <see cref="SendEmailRequest.Cc"/> recipient collection of the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="To(SendEmailRequest, string, string?)" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="email">
    /// <inheritdoc cref="To(SendEmailRequest, string, string?)" path="/param[@name='email']/*"/>
    /// </param>
    ///
    /// <param name="displayName">
    /// <inheritdoc cref="To(SendEmailRequest, string, string?)" path="/param[@name='displayName']"/>
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="To(SendEmailRequest, string, string?)" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> is <see langword="null"/>.<br />
    /// When <paramref name="email"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    ///
    /// <remarks>
    /// <inheritdoc cref="To(SendEmailRequest, string, string?)" path="/remarks"/>
    /// </remarks>
    public static SendEmailRequest Cc(this SendEmailRequest request, string email, string? displayName = default)
    {
        Ensure.NotNull(request, nameof(request));

        return request.Cc(new EmailAddress(email, displayName));
    }

    #endregion



    #region Bcc

    /// <summary>
    /// Adds provided <paramref name="recipients"/> to the <see cref="SendEmailRequest.Bcc"/>
    /// recipient collection of the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="To(SendEmailRequest, EmailAddress[])" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="recipients">
    /// <inheritdoc cref="To(SendEmailRequest, EmailAddress[])" path="/param[@name='recipients']"/>
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="To(SendEmailRequest, EmailAddress[])" path="/returns"/>
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException" id="ArgumentNullException">
    /// When <paramref name="request"/> or <paramref name="recipients"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <remarks>
    /// <inheritdoc cref="To(SendEmailRequest, EmailAddress[])" path="/remarks"/>
    /// </remarks>
    public static SendEmailRequest Bcc(this SendEmailRequest request, params EmailAddress[] recipients)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(recipients, nameof(recipients));

        request.Bcc.AddRange(recipients);

        return request;
    }

    /// <summary>
    /// Adds provided <paramref name="email"/> and <paramref name="displayName"/> tuple as recipient
    /// to the <see cref="SendEmailRequest.Bcc"/> recipient collection of the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="To(SendEmailRequest, string, string?)" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="email">
    /// <inheritdoc cref="To(SendEmailRequest, string, string?)" path="/param[@name='email']/*"/>
    /// </param>
    ///
    /// <param name="displayName">
    /// <inheritdoc cref="To(SendEmailRequest, string, string?)" path="/param[@name='displayName']"/>
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="To(SendEmailRequest, string, string?)" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> is <see langword="null"/>.<br />
    /// When <paramref name="email"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    ///
    /// <remarks>
    /// <inheritdoc cref="To(SendEmailRequest, string, string?)" path="/remarks"/>
    /// </remarks>
    public static SendEmailRequest Bcc(this SendEmailRequest request, string email, string? displayName = default)
    {
        Ensure.NotNull(request, nameof(request));

        return request.Bcc(new EmailAddress(email, displayName));
    }

    #endregion



    #region Attachments

    /// <summary>
    /// Adds provided <paramref name="attachments"/> to the <see cref="SendEmailRequest.Attachments"/>
    /// collection of the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="attachments">
    /// One or more <see cref="Attachment"/> objects to add to the request's
    /// <see cref="SendEmailRequest.Attachments"/> collection.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> or <paramref name="attachments"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <remarks>
    /// Duplicates can be added by calling this method multiple times with the same <see cref="Attachment"/> object.
    /// </remarks>
    public static SendEmailRequest Attach(this SendEmailRequest request, params Attachment[] attachments)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNull(attachments, nameof(attachments));

        request.Attachments.AddRange(attachments);

        return request;
    }

    /// <summary>
    /// Adds provided attachment to the <see cref="SendEmailRequest.Attachments"/>
    /// collection of the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="Attach(SendEmailRequest, Attachment[])" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="content">
    /// <inheritdoc cref="Attachment(string, string, DispositionType?, string?, string?)" path="/param[@name='content']/*"/>
    /// </param>
    /// 
    /// <param name="fileName">
    /// <inheritdoc cref="Attachment(string, string, DispositionType?, string?, string?)" path="/param[@name='fileName']/*"/>
    /// </param>
    /// 
    /// <param name="disposition">
    /// <inheritdoc cref="Attachment(string, string, DispositionType?, string?, string?)" path="/param[@name='disposition']/*"/>
    /// </param>
    /// 
    /// <param name="mimeType">
    /// <inheritdoc cref="Attachment(string, string, DispositionType?, string?, string?)" path="/param[@name='mimeType']/*"/>
    /// </param>
    /// 
    /// <param name="contentId">
    /// <inheritdoc cref="Attachment(string, string, DispositionType?, string?, string?)" path="/param[@name='contentId']/*"/>
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="Attach(SendEmailRequest, Attachment[])" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> is <see langword="null"/>.<br />
    /// When <paramref name="content"/> is <see langword="null"/> or <see cref="string.Empty"/>.<br />
    /// When <paramref name="fileName"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    ///
    /// <remarks>
    /// Duplicates can be added by calling this method multiple times with the same parameters.
    /// </remarks>
    public static SendEmailRequest Attach(this SendEmailRequest request,
        string content,
        string fileName,
        DispositionType? disposition = default,
        string? mimeType = default,
        string? contentId = default)
    {
        Ensure.NotNull(request, nameof(request));

        return request.Attach(new Attachment(content, fileName, disposition, mimeType, contentId));
    }

    #endregion



    #region Headers

    /// <summary>
    /// Adds provided <paramref name="headers"/> to the <see cref="SendEmailRequest.Headers"/>
    /// collection of the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="headers">
    /// One or more key/value pairs to add to the request's <see cref="SendEmailRequest.Headers"/> collection.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> or <paramref name="headers"/> is <see langword="null"/>.
    /// </exception>
    ///
    /// <remarks>
    /// Any existing headers with the same keys will be overridden.
    /// </remarks>
    public static SendEmailRequest Header(this SendEmailRequest request, params KeyValuePair<string, string>[] headers)
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
    /// Adds provided header to the <see cref="SendEmailRequest.Headers"/>
    /// collection of the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="key">
    /// Header key to add.
    /// </param>
    /// 
    /// <param name="value">
    /// Header value to add.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> is <see langword="null"/>.<br />
    /// When <paramref name="key"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    ///
    /// <remarks>
    /// Any existing header with the same key will be overridden.
    /// </remarks>
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
    /// Adds provided <paramref name="variables"/> to the <see cref="SendEmailRequest.CustomVariables"/>
    /// collection of the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="variables">
    /// One or more key/value pairs to add to the request's <see cref="SendEmailRequest.CustomVariables"/> collection.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> or <paramref name="variables"/> is <see langword="null"/>.
    /// </exception>
    ///
    /// <remarks>
    /// Any existing variables with the same keys will be overridden.
    /// </remarks>
    public static SendEmailRequest CustomVariable(this SendEmailRequest request, params KeyValuePair<string, string>[] variables)
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
    /// Adds provided custom variable to the <see cref="SendEmailRequest.Headers"/>
    /// collection of the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="key">
    /// Variable key to add.
    /// </param>
    /// 
    /// <param name="value">
    /// Variable value to add.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> is <see langword="null"/>.<br />
    /// When <paramref name="key"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    ///
    /// <remarks>
    /// Any existing variable with the same key will be overridden.
    /// </remarks>
    public static SendEmailRequest CustomVariable(this SendEmailRequest request, string key, string value)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(key, nameof(key));

        request.CustomVariables[key] = value;

        return request;
    }

    #endregion



    /// <summary>
    /// Sets provided <paramref name="subject"/> to the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="subject">
    /// Value to initialize request's <see cref="SendEmailRequest.Subject"/> property.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> is <see langword="null"/>.<br />
    /// When <paramref name="subject"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    /// 
    /// <remarks>
    /// Subsequent calls will override value that was set before (last wins).
    /// <para>
    /// Value must remain <see langword="null"/> if <see cref="SendEmailRequest.TemplateId"/> is used
    /// to create email from template.
    /// </para>
    /// </remarks>
    public static SendEmailRequest Subject(this SendEmailRequest request, string subject)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(subject, nameof(subject));

        request.Subject = subject;

        return request;
    }

    /// <summary>
    /// Sets provided <paramref name="text"/> to the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="text">
    /// Value to initialize request's <see cref="SendEmailRequest.TextBody"/> property.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <remarks>
    /// <para>
    /// Subsequent calls will override value that was set before (last wins).
    /// </para>
    /// <para>
    /// Value must remain <see langword="null"/> if <see cref="SendEmailRequest.TemplateId"/> is used
    /// to create email from template.
    /// </para>
    /// </remarks>
    public static SendEmailRequest Text(this SendEmailRequest request, string? text)
    {
        Ensure.NotNull(request, nameof(request));

        request.TextBody = text;

        return request;
    }

    /// <summary>
    /// Sets provided <paramref name="html"/> to the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="html">
    /// Value to initialize request's <see cref="SendEmailRequest.HtmlBody"/> property.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <remarks>
    /// <para>
    /// It is a caller responsibility to ensure that <paramref name="html"/> contains a valid,
    /// well-formed HTML markup and is sanitized properly.
    /// </para>
    /// <para>
    /// Subsequent calls will override value that was set before (last wins).
    /// </para>
    /// <para>
    /// Value must remain <see langword="null"/> if <see cref="SendEmailRequest.TemplateId"/> is used
    /// to create email from template.
    /// </para>
    /// </remarks>
    public static SendEmailRequest Html(this SendEmailRequest request, string? html)
    {
        Ensure.NotNull(request, nameof(request));

        request.HtmlBody = html;

        return request;
    }

    /// <summary>
    /// Sets provided <paramref name="category"/> to the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="category">
    /// Value to initialize request's <see cref="SendEmailRequest.Category"/> property.
    /// <para>
    /// Should be less or equal to 255 characters.
    /// </para>
    /// </param>
    /// 
    /// <returns>
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <remarks>
    /// Subsequent calls will override value that was set before (last wins).
    /// <para>
    /// Value must remain <see langword="null"/> if <see cref="SendEmailRequest.TemplateId"/> is used
    /// to create email from template.
    /// </para>
    /// </remarks>
    public static SendEmailRequest Category(this SendEmailRequest request, string? category)
    {
        Ensure.NotNull(request, nameof(request));

        request.Category = category;

        return request;
    }



    /// <summary>
    /// Sets provided <paramref name="templateId"/> to the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="templateId">
    /// Value containing UUID of the template to initialize request's <see cref="SendEmailRequest.TemplateId"/> property.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> is <see langword="null"/>.<br />
    /// When <paramref name="templateId"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    /// 
    /// <remarks>
    /// Subsequent calls will override value that was set before (last wins).
    /// <para>
    /// When <see cref="SendEmailRequest.TemplateId"/> is set, then <see cref="SendEmailRequest.Subject"/>,
    /// <see cref="SendEmailRequest.TextBody"/>, <see cref="SendEmailRequest.HtmlBody"/>
    /// and <see cref="SendEmailRequest.Category"/> properties are forbidden and must be set to <see langword="null"/>.
    /// </para>
    /// </remarks>
    public static SendEmailRequest Template(this SendEmailRequest request, string templateId)
    {
        Ensure.NotNull(request, nameof(request));
        Ensure.NotNullOrEmpty(templateId, nameof(templateId));

        request.TemplateId = templateId;

        return request;
    }

    /// <summary>
    /// Sets provided <paramref name="templateVariables"/> to the <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/param[@name='request']"/>
    /// </param>
    /// 
    /// <param name="templateVariables">
    /// Value containing object to initialize request's <see cref="SendEmailRequest.TemplateVariables"/> property.
    /// </param>
    ///
    /// <returns>
    /// <inheritdoc cref="From(SendEmailRequest, EmailAddress)" path="/returns"/>
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <remarks>
    /// Subsequent calls will override value that was set before (last wins).
    /// <para>
    /// Will be used only in case template is set.
    /// </para>
    /// </remarks>
    public static SendEmailRequest TemplateVariables(this SendEmailRequest request, object? templateVariables)
    {
        Ensure.NotNull(request, nameof(request));

        request.TemplateVariables = templateVariables;

        return request;
    }
}
