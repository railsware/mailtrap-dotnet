// -----------------------------------------------------------------------
// <copyright file="AccountAccessResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccesses.Models;


/// <summary>
/// Represents resource details for account access.
/// </summary>
public sealed record AccountAccessResource
{
    /// <summary>
    /// Gets the resource identifier.
    /// </summary>
    ///
    /// <value>
    /// Resource identifier.
    /// </value>
    [JsonPropertyName("resource_id")]
    [JsonPropertyOrder(1)]
    [JsonRequired]
    public long Id { get; set; }

    /// <summary>
    /// Gets the resource type.
    /// </summary>
    ///
    /// <value>
    /// Resource type.
    /// </value>
    [JsonPropertyName("resource_type")]
    [JsonPropertyOrder(2)]
    public AccountResourceType? Type { get; set; }

    /// <summary>
    /// Gets the resource access level.
    /// </summary>
    ///
    /// <value>
    /// Access level for resource.
    /// </value>
    [JsonPropertyName("access_level")]
    [JsonPropertyOrder(3)]
    public AccessLevel? AccessLevel { get; set; }
}
