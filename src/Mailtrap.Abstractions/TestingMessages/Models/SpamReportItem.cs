// -----------------------------------------------------------------------
// <copyright file="SpamReportItem.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.TestingMessages.Models;


/// <summary>
/// Represents spam report details for the particular rule.
/// </summary>
public sealed record SpamReportItem
{
    /// <summary>
    /// Gets the score for the particular spam rule.
    /// </summary>
    ///
    /// <value>
    /// Score for the particular spam rule.
    /// </value>
    [JsonPropertyName("Pts")]
    [JsonPropertyOrder(1)]
    public decimal? Score { get; set; }

    /// <summary>
    /// Gets the name of the rule.
    /// </summary>
    ///
    /// <value>
    /// Name of the rule.
    /// </value>
    [JsonPropertyName("RuleName")]
    [JsonPropertyOrder(2)]
    public string? RuleName { get; set; }

    /// <summary>
    /// Gets the description of the rule.
    /// </summary>
    ///
    /// <value>
    /// Description of the rule.
    /// </value>
    [JsonPropertyName("Description")]
    [JsonPropertyOrder(3)]
    public string? Description { get; set; }
}
