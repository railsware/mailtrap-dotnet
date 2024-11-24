// -----------------------------------------------------------------------
// <copyright file="TestingMessageSpamReport.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.TestingMessages.Models;


/// <summary>
/// Represents spam report details for the message.
/// </summary>
public sealed record TestingMessageSpamReport
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
