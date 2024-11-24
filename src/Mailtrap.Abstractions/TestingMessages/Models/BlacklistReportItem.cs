// -----------------------------------------------------------------------
// <copyright file="BlacklistReportItem.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.TestingMessages.Models;


/// <summary>
/// Represents blacklist report entry from a particular reporting resource.
/// </summary>
public sealed record BlacklistReportItem
{
    /// <summary>
    /// Gets name of the reporting resource.
    /// </summary>
    ///
    /// <value>
    /// Name of the reporting resource.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(1)]
    public string? Name { get; set; }

    /// <summary>
    /// Gets URL of the reporting resource.
    /// </summary>
    ///
    /// <value>
    /// URL of the reporting resource.
    /// </value>
    [JsonPropertyName("url")]
    [JsonPropertyOrder(2)]
    public Uri? Url { get; set; }

    /// <summary>
    /// Gets flag indicating if message was put in a black list.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if the message was put in black list.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("in_black_list")]
    [JsonPropertyOrder(3)]
    public bool? Blacklisted { get; set; }
}
