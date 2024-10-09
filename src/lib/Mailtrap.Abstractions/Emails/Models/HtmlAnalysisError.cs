// -----------------------------------------------------------------------
// <copyright file="HtmlAnalysisError.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Models;


/// <summary>
/// Represents HTML analysis error details.
/// </summary>
public sealed record HtmlAnalysisError
{
    /// <summary>
    /// Gets a line number of the HTML, where error was found.
    /// </summary>
    ///
    /// <value>
    /// Line number of the HTML, where error was found.
    /// </value>
    [JsonPropertyName("error_line")]
    [JsonPropertyOrder(1)]
    public int? Line { get; }

    /// <summary>
    /// Gets HTML analysis rule name, that triggered the error.
    /// </summary>
    ///
    /// <value>
    /// HTML analysis rule name, that triggered the error.
    /// </value>
    [JsonPropertyName("rule_name")]
    [JsonPropertyOrder(2)]
    public string? RuleName { get; }

    /// <summary>
    /// Gets email clients affected by error.
    /// </summary>
    ///
    /// <value>
    /// Email clients affected by error.
    /// </value>
    [JsonPropertyName("email_clients")]
    [JsonPropertyOrder(3)]
    public EmailClients Clients { get; } = new();
}
