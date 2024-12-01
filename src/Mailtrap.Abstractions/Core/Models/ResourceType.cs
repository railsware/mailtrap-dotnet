// -----------------------------------------------------------------------
// <copyright file="ResourceType.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Models;


/// <summary>
/// Represents resource type from permissions management perspective.
/// </summary>
public sealed record ResourceType : StringEnum<ResourceType>
{
    /// <summary>
    /// Gets the value representing "account" resource type.
    /// </summary>
    ///
    /// <value>
    /// Represents "account" resource type.
    /// </value>
    public static ResourceType Account { get; } = Define("account");

    /// <summary>
    /// Gets the value representing "billing" resource type.
    /// </summary>
    ///
    /// <value>
    /// Represents "billing" resource type.
    /// </value>
    public static ResourceType Billing { get; } = Define("billing");

    /// <summary>
    /// Gets the value representing "project" resource type.
    /// </summary>
    ///
    /// <value>
    /// Represents "project" resource type.
    /// </value>
    public static ResourceType Project { get; } = Define("project");

    /// <summary>
    /// Gets the value representing "inbox" resource type.
    /// </summary>
    ///
    /// <value>
    /// Represents "inbox" resource type.
    /// </value>
    public static ResourceType Inbox { get; } = Define("inbox");

    /// <summary>
    /// Gets the value representing "sending domain" resource type.
    /// </summary>
    ///
    /// <value>
    /// Represents "sending domain" resource type.
    /// </value>
    public static ResourceType SendingDomain { get; } = Define("mailsend_domain");

    /// <summary>
    /// Gets the value representing "email campaigns" resource type.
    /// </summary>
    ///
    /// <value>
    /// Represents "email campaigns" resource type.
    /// </value>
    public static ResourceType EmailCampaign { get; } = Define("email_campaign_permission_scope");
}
