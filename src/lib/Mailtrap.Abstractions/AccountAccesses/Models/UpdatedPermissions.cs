// -----------------------------------------------------------------------
// <copyright file="UpdatedPermissions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccesses.Models;


/// <summary>
/// Represents details of updated account access permissions.
/// </summary>
public sealed record UpdatedPermissions
{
    /// <summary>
    /// Gets the message about successful update of permissions.
    /// </summary>
    ///
    /// <value>
    /// Message about successful update of permissions.
    /// </value>
    [JsonPropertyName("message")]
    [JsonPropertyOrder(1)]
    public string? Message { get; }
}
