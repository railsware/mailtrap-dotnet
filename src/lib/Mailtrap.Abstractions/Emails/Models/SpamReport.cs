// -----------------------------------------------------------------------
// <copyright file="SpamReport.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Models;


/// <summary>
/// Represents spam report for the message.
/// </summary>
public sealed record SpamReport
{
    /// <summary>
    /// Gets response code.
    /// </summary>
    ///
    /// <value>
    /// Response code.
    /// </value>
    [JsonPropertyName("ResponseCode")]
    [JsonPropertyOrder(1)]
    public int? ResponseCode { get; }

    /// <summary>
    /// Gets response message.
    /// </summary>
    ///
    /// <value>
    /// Response message.
    /// </value>
    [JsonPropertyName("ResponseMessage")]
    [JsonPropertyOrder(2)]
    public string? ResponseMessage { get; }

    /// <summary>
    /// Gets response version.
    /// </summary>
    ///
    /// <value>
    /// Response version.
    /// </value>
    [JsonPropertyName("ResponseVersion")]
    [JsonPropertyOrder(3)]
    public string? ResponseVersion { get; }

    // TODO: Confirm type
    /// <summary>
    /// Gets spam score.
    /// </summary>
    ///
    /// <value>
    /// Spam score.
    /// </value>
    [JsonPropertyName("Score")]
    [JsonPropertyOrder(4)]
    public decimal? Score { get; }

    // TODO: Confirm type
    /// <summary>
    /// Gets spam score threshold.
    /// </summary>
    ///
    /// <value>
    /// Spam score threshold.
    /// </value>
    [JsonPropertyName("Threshold")]
    [JsonPropertyOrder(5)]
    public decimal? Threshold { get; }

    /// <summary>
    /// Gets a flag indicating that message is marked as spam.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if the message is marked as spam.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("Spam")]
    [JsonPropertyOrder(6)]
    public bool? Spam { get; }

    /// <summary>
    /// Gets a list of spam report details.
    /// </summary>
    ///
    /// <value>
    /// List of spam report details.
    /// </value>
    [JsonPropertyName("Details")]
    [JsonPropertyOrder(7)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<SpamReportItem> Details { get; } = [];
}
