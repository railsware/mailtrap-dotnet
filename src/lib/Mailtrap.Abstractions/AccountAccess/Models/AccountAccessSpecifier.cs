// -----------------------------------------------------------------------
// <copyright file="AccountAccessSpecifier.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccess.Models;


/// <summary>
/// Represents account access specifier details.
/// </summary>
public sealed record AccountAccessSpecifier
{
    /// <summary>
    /// Gets the specifier identifier.
    /// </summary>
    ///
    /// <value>
    /// Specifier identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    [JsonRequired]
    public long Id { get; }

    /// <summary>
    /// Gets the specifier email address.
    /// </summary>
    ///
    /// <value>
    /// Specifier email address.
    /// </value>
    [JsonPropertyName("email")]
    [JsonPropertyOrder(2)]
    public string? Email { get; }

    /// <summary>
    /// Gets the specifier name.
    /// </summary>
    ///
    /// <value>
    /// Specifier name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(3)]
    public string? Name { get; }


    /// <summary>
    /// Gets the origin of the token.
    /// </summary>
    ///
    /// <value>
    /// Origin of the token.
    /// </value>
    [JsonPropertyName("author_name")]
    [JsonPropertyOrder(4)]
    public string? AuthorName { get; }

    /// <summary>
    /// Gets the token value.
    /// </summary>
    ///
    /// <value>
    /// Token value.
    /// </value>
    [JsonPropertyName("token")]
    [JsonPropertyOrder(5)]
    public string? Token { get; }

    /// <summary>
    /// Gets the token expiration date and time.
    /// </summary>
    ///
    /// <value>
    /// Token expiration date and time.
    /// </value>
    [JsonPropertyName("expires_at")]
    [JsonPropertyOrder(6)]
    public DateTimeOffset? ExpiresAt { get; }
}
