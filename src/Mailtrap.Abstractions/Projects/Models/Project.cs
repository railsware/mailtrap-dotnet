// -----------------------------------------------------------------------
// <copyright file="Project.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects.Models;


/// <summary>
/// Represents project details.
/// </summary>
public sealed record Project
{
    /// <summary>
    /// Gets project identifier.
    /// </summary>
    ///
    /// <value>
    /// Project identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    [JsonRequired]
    public long Id { get; set; }

    /// <summary>
    /// Gets project name.
    /// </summary>
    ///
    /// <value>
    /// Project name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(2)]
    public string? Name { get; set; }

    /// <summary>
    /// Gets project sharing links.
    /// </summary>
    ///
    /// <value>
    /// Project sharing links.
    /// </value>
    [JsonPropertyName("share_links")]
    [JsonPropertyOrder(3)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ProjectShareLinks ShareLinks { get; } = new();

    /// <summary>
    /// Gets permissions for this project granted for the current token.
    /// </summary>
    ///
    /// <value>
    /// Permissions for this project granted for the current token.
    /// </value>
    [JsonPropertyName("permissions")]
    [JsonPropertyOrder(4)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public ProjectPermissions Permissions { get; } = new();

    /// <summary>
    /// Gets a list of project's inboxes.
    /// </summary>
    ///
    /// <value>
    /// A list of project's inboxes.
    /// </value>
    [JsonPropertyName("inboxes")]
    [JsonPropertyOrder(5)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<object> Inboxes { get; } = []; // TODO: Change type when Inbox model is ready
}
