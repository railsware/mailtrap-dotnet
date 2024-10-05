// -----------------------------------------------------------------------
// <copyright file="SpecifierType.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccess.Models;


/// <summary>
/// Represents access specifier type.
/// </summary>
public sealed record SpecifierType : StringEnum<SpecifierType>
{
    /// <summary>
    /// </summary>
    public static SpecifierType User { get; } = Define("User");

    /// <summary>
    /// </summary>
    public static SpecifierType Invite { get; } = Define("Invite");

    /// <summary>
    /// </summary>
    public static SpecifierType ApiToken { get; } = Define("ApiToken");
}
