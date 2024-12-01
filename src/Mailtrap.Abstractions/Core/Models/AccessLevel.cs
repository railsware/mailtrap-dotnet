// -----------------------------------------------------------------------
// <copyright file="AccessLevel.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Models;


/// <summary>
/// Access level enumeration.
/// </summary>
public enum AccessLevel
{
    /// <summary>
    /// None.
    /// </summary>
    None = 0,

    /// <summary>
    /// Indeterminate.
    /// </summary>
    Indeterminate = 1,

    /// <summary>
    /// Viewer.
    /// </summary>
    Viewer = 10,

    /// <summary>
    /// Viewer+.
    /// </summary>
    ViewerPlus = 50,

    /// <summary>
    /// Admin.
    /// </summary>
    Admin = 100,

    /// <summary>
    /// Owner.
    /// </summary>
    Owner = 1000
}
