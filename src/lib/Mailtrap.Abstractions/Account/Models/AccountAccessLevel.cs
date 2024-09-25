// -----------------------------------------------------------------------
// <copyright file="AccountAccessLevel.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Account.Models;


/// <summary>
/// Account access level enumeration.
/// </summary>
public enum AccountAccessLevel
{
    /// <summary>
    /// None.
    /// </summary>
    None = 0,

    /// <summary>
    /// Account viewer.
    /// </summary>
    Viewer = 10,

    /// <summary>
    /// Account admin.
    /// </summary>
    Admin = 100,

    /// <summary>
    /// Account owner.
    /// </summary>
    Owner = 1000
}
