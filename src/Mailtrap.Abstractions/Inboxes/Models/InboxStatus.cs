// -----------------------------------------------------------------------
// <copyright file="InboxStatus.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Inboxes.Models;


/// <summary>
/// Represents status of the inbox.
/// </summary>
public sealed record InboxStatus : StringEnum<InboxStatus>
{
    /// <summary>
    /// Gets the value representing "active" status.
    /// </summary>
    ///
    /// <value>
    /// Represents "active" status.
    /// </value>
    public static InboxStatus Active { get; } = Define("active");

    /// <summary>
    /// Gets the value representing "inactive" status.
    /// </summary>
    ///
    /// <value>
    /// Represents "inactive" status.
    /// </value>
    public static InboxStatus Inactive { get; } = Define("inactive");

    /// <summary>
    /// Gets the value representing "pending" status.
    /// </summary>
    ///
    /// <value>
    /// Represents "pending" status.
    /// </value>
    public static InboxStatus Pending { get; } = Define("pending");
}
