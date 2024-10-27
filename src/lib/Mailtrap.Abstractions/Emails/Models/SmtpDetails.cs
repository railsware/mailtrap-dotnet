// -----------------------------------------------------------------------
// <copyright file="SmtpDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Models;


/// <summary>
/// Represents SMTP details of a message.
/// </summary>
public sealed record SmtpDetails
{
    /// <summary>
    /// Gets 'Mail From' email address.
    /// </summary>
    ///
    /// <value>
    /// 'Mail From' email address.
    /// </value>
    [JsonPropertyName("mail_from_addr")]
    [JsonPropertyOrder(1)]
    public string? MailFromAddress { get; set; }

    /// <summary>
    /// Gets client IP address.
    /// </summary>
    ///
    /// <value>
    /// Client IP address.
    /// </value>
    [JsonPropertyName("client_ip")]
    [JsonPropertyOrder(2)]
    public string? ClientIpAddress { get; set; }
}
