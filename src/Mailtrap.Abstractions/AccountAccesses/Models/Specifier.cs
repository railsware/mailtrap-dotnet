// -----------------------------------------------------------------------
// <copyright file="Specifier.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccesses.Models;


/// <summary>
/// Represents account access specifier (principal) details.
/// </summary>
public sealed record Specifier
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
    public long Id { get; set; }

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
    public string? Email { get; set; }

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
    public string? Name { get; set; }


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
    public string? AuthorName { get; set; }

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
    public string? Token { get; set; }

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
    public DateTimeOffset? ExpiresAt { get; set; }

    /// <summary>
    /// Gets the flag indicating if 2FA enabled for user.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> when 2FA enabled for user.<br/>
    /// <see langword="false"/> otherwise.
    /// </value>
    ///
    /// <remarks>
    /// Applicable to 'User' specifier type only.
    /// </remarks>
    [JsonPropertyName("two_factor_authentication_enabled")]
    [JsonPropertyOrder(7)]
    public bool? TwoFactorAuthEnabled { get; set; }
}
