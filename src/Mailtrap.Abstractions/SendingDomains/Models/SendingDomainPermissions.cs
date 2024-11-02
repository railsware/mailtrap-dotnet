// -----------------------------------------------------------------------
// <copyright file="SendingDomainPermissions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomains.Models;


/// <summary>
/// Represents sending domain permissions.
/// </summary>
public sealed record SendingDomainPermissions
{
    /// <summary>
    /// Gets the flag indicating whether user can read sending domain.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if user can read sending domain.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_read")]
    [JsonPropertyOrder(1)]
    public bool? CanRead { get; set; }

    /// <summary>
    /// Gets the flag indicating whether user can update sending domain.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if user can update sending domain.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_update")]
    [JsonPropertyOrder(2)]
    public bool? CanUpdate { get; set; }

    /// <summary>
    /// Gets the flag indicating whether user can destroy sending domain.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if user can destroy sending domain.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_destroy")]
    [JsonPropertyOrder(3)]
    public bool? CanDestroy { get; set; }
}

