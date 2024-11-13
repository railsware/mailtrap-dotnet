// -----------------------------------------------------------------------
// <copyright file="ResourceAccessPermissions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccesses.Models;


/// <summary>
/// Represents access permissions for resource.
/// </summary>
public sealed record ResourceAccessPermissions
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
    public bool? CanRead { get; set; }

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
    public bool? CanUpdate { get; set; }

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
    public bool? CanDestroy { get; set; }

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
    public bool? CanLeave { get; set; }
}
