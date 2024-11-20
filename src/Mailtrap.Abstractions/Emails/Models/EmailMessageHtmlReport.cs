// -----------------------------------------------------------------------
// <copyright file="EmailMessageHtmlReport.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Models;


/// <summary>
/// Represents HTML analysis report details for the message.
/// </summary>
public sealed record EmailMessageHtmlReport
{
    /// <summary>
    /// Gets HTML analysis report.
    /// </summary>
    ///
    /// <value>
    /// HTML analysis report.
    /// </value>
    [JsonPropertyName("report")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public HtmlAnalysisReport Report { get; } = new();
}
