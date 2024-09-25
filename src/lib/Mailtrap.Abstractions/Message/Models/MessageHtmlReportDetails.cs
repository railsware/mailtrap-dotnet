// -----------------------------------------------------------------------
// <copyright file="MessageHtmlReportDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Message.Models;


/// <summary>
/// Represents HTML analysis report details for the message.
/// </summary>
public sealed record MessageHtmlReportDetails
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
    public HtmlAnalysisReport Report { get; } = new();
}
