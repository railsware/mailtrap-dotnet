// -----------------------------------------------------------------------
// <copyright file="MessageSpamReportDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Message.Models;


/// <summary>
/// Represents spam report details for the message.
/// </summary>
public sealed record MessageSpamReportDetails
{
    /// <summary>
    /// Gets spam report.
    /// </summary>
    ///
    /// <value>
    /// Spam report.
    /// </value>
    [JsonPropertyName("report")]
    [JsonPropertyOrder(1)]
    public SpamReport Report { get; } = new();
}
