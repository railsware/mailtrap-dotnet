// -----------------------------------------------------------------------
// <copyright file="AccountAccessPermissions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccess.Models;


/// <summary>
/// Represents specifier permissions for resources.
/// </summary>
public sealed record AccountAccessPermissions
{
    /// <summary>
    /// Gets the flag indicating whether specifier can read resources.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if specifier can read resources.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_read")]
    [JsonPropertyOrder(1)]
    public bool? CanRead { get; }

    /// <summary>
    /// Gets the flag indicating whether specifier can update resources.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if specifier can update resources.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_update")]
    [JsonPropertyOrder(2)]
    public bool? CanUpdate { get; }

    /// <summary>
    /// Gets the flag indicating whether specifier can destroy resources.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if specifier can destroy resources.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_destroy")]
    [JsonPropertyOrder(3)]
    public bool? CanDestroy { get; }

    /// <summary>
    /// Gets the flag indicating whether specifier can leave resources.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if specifier can leave resources.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_leave")]
    [JsonPropertyOrder(4)]
    public bool? CanLeave { get; }
}
