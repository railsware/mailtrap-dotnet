// -----------------------------------------------------------------------
// <copyright file="ResourcePermissions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Permissions.Models;


/// <summary>
/// Represents resource hierarchy permissions.
/// </summary>
public sealed record ResourcePermissions
{
    /// <summary>
    /// Gets the resource identifier.
    /// </summary>
    ///
    /// <value>
    /// Resource identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    [JsonRequired]
    public long Id { get; }

    /// <summary>
    /// Gets the resource name.
    /// </summary>
    ///
    /// <value>
    /// Resource name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(2)]
    public string? Name { get; }

    /// <summary>
    /// Gets the resource type.
    /// </summary>
    ///
    /// <value>
    /// Resource type.
    /// </value>
    [JsonPropertyName("type")]
    [JsonPropertyOrder(3)]
    public string? Type { get; }

    /// <summary>
    /// Gets the resource access level.
    /// </summary>
    ///
    /// <value>
    /// Access level for resource.
    /// </value>
    [JsonPropertyName("access_level")]
    [JsonPropertyOrder(4)]
    public AccessLevel? AccessLevel { get; }

    /// <summary>
    /// Gets the collection of nested resources.
    /// </summary>
    ///
    /// <value>
    /// Contains a list of nested resources.
    /// </value>
    [JsonPropertyName("resources")]
    [JsonPropertyOrder(5)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<ResourcePermissions> Resources { get; } = [];
}
