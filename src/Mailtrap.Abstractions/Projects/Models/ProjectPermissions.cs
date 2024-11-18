// -----------------------------------------------------------------------
// <copyright file="ProjectPermissions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Projects.Models;


/// <summary>
/// Represents permissions for a project.
/// </summary>
public sealed record ProjectPermissions
{
    /// <summary>
    /// Gets the flag indicating whether user can read the project.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if user can read the project.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_read")]
    [JsonPropertyOrder(1)]
    public bool? CanRead { get; set; }

    /// <summary>
    /// Gets the flag indicating whether user can update the project.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if user can update the project.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_update")]
    [JsonPropertyOrder(2)]
    public bool? CanUpdate { get; set; }

    /// <summary>
    /// Gets the flag indicating whether user can destroy the project.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if user can destroy the project.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_destroy")]
    [JsonPropertyOrder(3)]
    public bool? CanDestroy { get; set; }

    /// <summary>
    /// Gets the flag indicating whether user can leave the project.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if user can leave the project.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_leave")]
    [JsonPropertyOrder(4)]
    public bool? CanLeave { get; set; }
}
