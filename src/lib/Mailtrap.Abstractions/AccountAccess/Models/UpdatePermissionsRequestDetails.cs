// -----------------------------------------------------------------------
// <copyright file="UpdatePermissionsRequestDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccess.Models;


// TODO: add validation

/// <summary>
/// Represents permissions details for account access update request.
/// </summary>
public sealed record UpdatePermissionsRequestDetails
{
    /// <summary>
    /// Gets or sets the resource identifier.
    /// </summary>
    ///
    /// <value>
    /// Resource identifier.
    /// </value>
    [JsonPropertyName("resource_id")]
    [JsonPropertyOrder(1)]
    public long? Id { get; set; }

    /// <summary>
    /// Gets or sets the resource type.
    /// </summary>
    ///
    /// <value>
    /// Resource type.
    /// </value>
    [JsonPropertyName("resource_type")]
    [JsonPropertyOrder(2)]
    public AccountResourceType? Type { get; set; }

    /// <summary>
    /// Gets or sets the resource access level.
    /// </summary>
    ///
    /// <value>
    /// Access level for resource.
    /// </value>
    ///
    /// <remarks>
    /// Allowed values: <see cref="AccessLevel.Viewer"/> or <see cref="AccessLevel.Admin"/>
    /// </remarks>
    [JsonPropertyName("access_level")]
    [JsonPropertyOrder(3)]
    public AccessLevel? AccessLevel { get; set; }

    /// <summary>
    /// Gets or sets the flag indicating whether to revoke resource permissions.<br />
    /// If set to <see langword="true"/> will completely revoke access permissions from the resource, instead of update.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> means a revocation of access permissions from the resource, instead of updating them.
    /// </value>
    ///
    /// <remarks>
    /// Has a priority over <see cref="AccessLevel"/>.<br />
    /// If set to <see langword="true"/>, the <see cref="AccessLevel"/> value will be ignored.
    /// </remarks>
    [JsonPropertyName("_destroy")]
    [JsonPropertyOrder(4)]
    public bool Revoke { get; set; } = false;
}
