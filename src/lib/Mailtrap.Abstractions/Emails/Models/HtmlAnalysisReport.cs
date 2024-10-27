// -----------------------------------------------------------------------
// <copyright file="HtmlAnalysisReport.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Models;


/// <summary>
/// Represents HTML analysis report for the message.
/// </summary>
public sealed record HtmlAnalysisReport
{
    /// <summary>
    /// Gets HTML analysis report status.
    /// </summary>
    ///
    /// <value>
    /// HTML analysis report status.
    /// </value>
    [JsonPropertyName("status")]
    [JsonPropertyOrder(1)]
    public string? Status { get; set; }

    /// <summary>
    /// Gets the list of HTML analysis errors.
    /// </summary>
    ///
    /// <value>
    /// List of HTML analysis errors.
    /// </value>
    [JsonPropertyName("errors")]
    [JsonPropertyOrder(2)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<HtmlAnalysisError> Errors { get; } = [];
}
