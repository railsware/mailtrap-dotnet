// -----------------------------------------------------------------------
// <copyright file="DeletedAccountAccessDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccess.Models;


/// <summary>
/// Represents details of deleted account access.
/// </summary>
public sealed record DeletedAccountAccessDetails
{
    /// <summary>
    /// Gets the deleted account access identifier.
    /// </summary>
    ///
    /// <value>
    /// Deleted account access identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    [JsonRequired]
    public long Id { get; }
}
