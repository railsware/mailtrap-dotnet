// -----------------------------------------------------------------------
// <copyright file="ProjectDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Project.Models;


/// <summary>
/// Represents project details.
/// </summary>
public sealed record ProjectDetails
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
    public long? Id { get; }

    /// <summary>
    /// Gets project name.
    /// </summary>
    ///
    /// <value>
    /// Project name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(2)]
    public string? Name { get; }

    /// <summary>
    /// Gets project sharing links.
    /// </summary>
    ///
    /// <value>
    /// Project sharing links.
    /// </value>
    [JsonPropertyName("share_links")]
    [JsonPropertyOrder(3)]
    public ProjectShareLinks? ShareLinks { get; }

    /// <summary>
    /// Gets project permissions.
    /// </summary>
    ///
    /// <value>
    /// Project permissions.
    /// </value>
    [JsonPropertyName("permissions")]
    [JsonPropertyOrder(4)]
    public ProjectPermissions Permissions { get; } = new();

    // TODO: Change list type parameter, when 'Inbox' abstraction will be available.
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
    public IList<object> Inboxes { get; } = [];
}
