// -----------------------------------------------------------------------
// <copyright file="AccountResourceType.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccess.Models;


/// <summary>
/// Represents access specifier type.
/// </summary>
public sealed record AccountResourceType : StringEnum<AccountResourceType>
{
    /// <summary>
    /// </summary>
    public static AccountResourceType Account { get; } = Define("account");

    /// <summary>
    /// </summary>
    public static AccountResourceType Billing { get; } = Define("billing");

    /// <summary>
    /// </summary>
    public static AccountResourceType Project { get; } = Define("project");

    /// <summary>
    /// </summary>
    public static AccountResourceType Inbox { get; } = Define("inbox");

    /// <summary>
    /// </summary>
    public static AccountResourceType SendingDomain { get; } = Define("mailsend_domain");
}
