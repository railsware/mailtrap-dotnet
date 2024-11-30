// -----------------------------------------------------------------------
// <copyright file="SpecifierType.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccesses.Models;


/// <summary>
/// Represents access specifier (principal) type.
/// </summary>
public sealed record SpecifierType : StringEnum<SpecifierType>
{
    /// <summary>
    /// Gets the value representing "User" specifier type.
    /// </summary>
    ///
    /// <value>
    /// Represents "User" specifier type.
    /// </value>
    public static SpecifierType User { get; } = Define("User");

    /// <summary>
    /// Gets the value representing "Invite" specifier type.
    /// </summary>
    ///
    /// <value>
    /// Represents "Invite" specifier type.
    /// </value>
    public static SpecifierType Invite { get; } = Define("Invite");

    /// <summary>
    /// Gets the value representing "API Token" specifier type.
    /// </summary>
    ///
    /// <value>
    /// Represents "API Token" specifier type.
    /// </value>
    public static SpecifierType ApiToken { get; } = Define("ApiToken");
}
