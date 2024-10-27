// -----------------------------------------------------------------------
// <copyright file="EmailMessageSpamReport.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Models;


/// <summary>
/// Represents spam report details for the message.
/// </summary>
public sealed record EmailMessageSpamReport
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
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public SpamReport Report { get; } = new();
}
