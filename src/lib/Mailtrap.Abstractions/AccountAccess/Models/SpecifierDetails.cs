// -----------------------------------------------------------------------
// <copyright file="SpecifierDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccess.Models;


/// <summary>
/// Represents account access specifier details.
/// </summary>
public sealed record SpecifierDetails
{
    /// <summary>
    /// Gets the specifier unique identifier (user, invite or token).
    /// </summary>
    ///
    /// <value>
    /// Specifier unique identifier (user, invite or token).
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    [JsonRequired]
    public long Id { get; }

    /// <summary>
    /// Gets the specifier email address (user or invite).
    /// </summary>
    ///
    /// <value>
    /// Specifier email address (user or invite).
    /// </value>
    ///
    /// <remarks>
    /// Applicable to 'User' and 'Invite' specifier types only.
    /// </remarks>
    [JsonPropertyName("email")]
    [JsonPropertyOrder(2)]
    public string? Email { get; }

    /// <summary>
    /// Gets the specifier name (user or API token).
    /// </summary>
    ///
    /// <value>
    /// Specifier name (user or API token).
    /// </value>
    ///
    /// <remarks>
    /// Applicable to 'User' and 'ApiToken' specifier types only.
    /// </remarks>
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
    /// 
    /// <remarks>
    /// Applicable to 'ApiToken' specifier type only.
    /// </remarks>
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
    /// 
    /// <remarks>
    /// Applicable to 'ApiToken' specifier type only.
    /// </remarks>
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
    ///
    /// <remarks>
    /// Applicable to 'ApiToken' specifier type only.
    /// </remarks>
    [JsonPropertyName("expires_at")]
    [JsonPropertyOrder(6)]
    public DateTimeOffset? ExpiresAt { get; }
}
