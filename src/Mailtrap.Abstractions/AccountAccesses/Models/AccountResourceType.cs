// -----------------------------------------------------------------------
// <copyright file="AccountResourceType.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccesses.Models;


/// <summary>
/// Represents access specifier type.
/// </summary>
public sealed record AccountResourceType : StringEnum<AccountResourceType>
{
    /// <summary>
    /// Gets the value representing "account" resource type.
    /// </summary>
    ///
    /// <value>
    /// Represents "account" resource type.
    /// </value>
    public static AccountResourceType Account { get; } = Define("account");

    /// <summary>
    /// Gets the value representing "billing" resource type.
    /// </summary>
    ///
    /// <value>
    /// Represents "billing" resource type.
    /// </value>
    public static AccountResourceType Billing { get; } = Define("billing");

    /// <summary>
    /// Gets the value representing "project" resource type.
    /// </summary>
    ///
    /// <value>
    /// Represents "project" resource type.
    /// </value>
    public static AccountResourceType Project { get; } = Define("project");

    /// <summary>
    /// Gets the value representing "inbox" resource type.
    /// </summary>
    ///
    /// <value>
    /// Represents "inbox" resource type.
    /// </value>
    public static AccountResourceType Inbox { get; } = Define("inbox");

    /// <summary>
    /// Gets the value representing "sending domain" resource type.
    /// </summary>
    ///
    /// <value>
    /// Represents "sending domain" resource type.
    /// </value>
    public static AccountResourceType SendingDomain { get; } = Define("mailsend_domain");
}
