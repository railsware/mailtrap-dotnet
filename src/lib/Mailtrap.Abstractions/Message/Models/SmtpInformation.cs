// -----------------------------------------------------------------------
// <copyright file="SmtpInformation.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Message.Models;


/// <summary>
/// Represents SMTP information of a message.
/// </summary>
public sealed record SmtpInformation
{
    /// <summary>
    /// Gets flag indicating if SMTP is ok.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if SMTP is fine.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("ok")]
    [JsonPropertyOrder(1)]
    public bool? Ok { get; }

    /// <summary>
    /// Gets SMTP information details.
    /// </summary>
    ///
    /// <value>
    /// SMTP information details.
    /// </value>
    [JsonPropertyName("data")]
    [JsonPropertyOrder(2)]
    public SmtpDetails Details { get; } = new();
}
