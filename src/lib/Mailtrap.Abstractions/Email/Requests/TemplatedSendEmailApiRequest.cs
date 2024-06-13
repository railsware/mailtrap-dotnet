// -----------------------------------------------------------------------
// <copyright file="EmailSendApiRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Requests;


/// <summary>
/// Request for sending email using predefined templates
/// </summary>
public record TemplatedSendEmailApiRequest : SendEmailApiRequest
{
    /// <summary>
    /// UUID of email template.
    /// <para>
    /// Subject, text and html will be generated from template using optional template_variables.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Required.
    /// </remarks>
    [JsonPropertyName("template_uuid")]
    public string? TemplateId { get; set; }

    /// <summary>
    /// Optional template variables that will be used to generate actual subject, text and html from email template.
    /// </summary>
    /// <remarks>
    /// Optional.
    /// </remarks>
    [JsonPropertyName("template_variables")]
    public object? TemplateVariables { get; set; }


    /// <inheritdoc />
    public TemplatedSendEmailApiRequest() { }

    /// <summary>
    /// Primary constructor with required parameters
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="recipient"></param>
    /// <param name="templateId"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public TemplatedSendEmailApiRequest(EmailParty sender, EmailParty recipient, string templateId)
        : base(sender, recipient)
    {
        Ensure.NotNullOrEmpty(templateId, nameof(templateId));

        TemplateId = templateId;
    }
}
