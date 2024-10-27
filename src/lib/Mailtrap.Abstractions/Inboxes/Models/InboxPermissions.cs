// -----------------------------------------------------------------------
// <copyright file="InboxPermissions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Inboxes.Models;


/// <summary>
/// Represents inbox permissions.
/// </summary>
public sealed record InboxPermissions
{
    /// <summary>
    /// Gets the flag indicating whether user can read inbox.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if user can read inbox.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_read")]
    [JsonPropertyOrder(1)]
    public bool? CanRead { get; set; }

    /// <summary>
    /// Gets the flag indicating whether user can update inbox.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if user can update inbox.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_update")]
    [JsonPropertyOrder(2)]
    public bool? CanUpdate { get; set; }

    /// <summary>
    /// Gets the flag indicating whether user can destroy inbox.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if user can destroy inbox.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_destroy")]
    [JsonPropertyOrder(3)]
    public bool? CanDestroy { get; set; }

    /// <summary>
    /// Gets the flag indicating whether user can leave inbox.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if user can leave inbox.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_leave")]
    [JsonPropertyOrder(4)]
    public bool? CanLeave { get; set; }
}
