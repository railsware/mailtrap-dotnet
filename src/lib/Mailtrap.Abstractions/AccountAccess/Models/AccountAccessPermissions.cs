// -----------------------------------------------------------------------
// <copyright file="AccountAccessPermissions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccess.Models;


/// <summary>
/// Represents specifier permissions to the account access resources.
/// </summary>
public sealed record AccountAccessPermissions
{
    /// <summary>
    /// Gets the flag indicating whether user can read the account access resources.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if user can read the account access resources.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_read")]
    [JsonPropertyOrder(1)]
    public bool? CanRead { get; }

    /// <summary>
    /// Gets the flag indicating whether user can update the account access resources.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if user can update the account access resources.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_update")]
    [JsonPropertyOrder(2)]
    public bool? CanUpdate { get; }

    /// <summary>
    /// Gets the flag indicating whether user can destroy the account access resources.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if user can destroy the account access resources.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_destroy")]
    [JsonPropertyOrder(3)]
    public bool? CanDestroy { get; }

    /// <summary>
    /// Gets the flag indicating whether user can leave the account access resources.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if user can leave the account access resources.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_leave")]
    [JsonPropertyOrder(4)]
    public bool? CanLeave { get; }
}
