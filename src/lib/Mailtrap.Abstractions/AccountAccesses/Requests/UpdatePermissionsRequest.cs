// -----------------------------------------------------------------------
// <copyright file="UpdatePermissionsRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.AccountAccesses.Requests;


// TODO: Add validation

/// <summary>
/// Request object for updating account access permissions.
/// </summary>
public sealed record UpdatePermissionsRequest
{
    /// <summary>
    /// Gets a collection of resources to update access permissions.
    /// </summary>
    ///
    /// <value>
    /// A list of resources to update access permissions.
    /// </value>
    [JsonPropertyName("permissions")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<UpdatePermissionsRequestItem> Permissions { get; } = [];
}
