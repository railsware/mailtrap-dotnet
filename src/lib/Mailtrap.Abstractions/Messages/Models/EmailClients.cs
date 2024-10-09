// -----------------------------------------------------------------------
// <copyright file="EmailClients.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Messages.Models;


/// <summary>
/// Represents details of email clients affected by HTML analysis error.
/// </summary>
public sealed record EmailClients
{
    /// <summary>
    /// Gets the list of desktop clients affected.
    /// </summary>
    ///
    /// <value>
    /// List of desktop clients affected.
    /// </value>
    [JsonPropertyName("desktop")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<string> Desktop { get; } = [];

    /// <summary>
    /// Gets the list of mobile clients affected.
    /// </summary>
    ///
    /// <value>
    /// List of mobile clients affected.
    /// </value>
    [JsonPropertyName("mobile")]
    [JsonPropertyOrder(2)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<string> Mobile { get; } = [];

    /// <summary>
    /// Gets the list of web clients affected.
    /// </summary>
    ///
    /// <value>
    /// List of web clients affected.
    /// </value>
    [JsonPropertyName("web")]
    [JsonPropertyOrder(3)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<string> Web { get; } = [];
}
