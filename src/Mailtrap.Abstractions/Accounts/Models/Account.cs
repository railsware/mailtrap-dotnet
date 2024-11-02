// -----------------------------------------------------------------------
// <copyright file="Account.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Accounts.Models;


/// <summary>
/// Represents account details.
/// </summary>
public sealed record Account
{
    /// <summary>
    /// Gets the account identifier.
    /// </summary>
    ///
    /// <value>
    /// Account identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    [JsonRequired]
    public long Id { get; set; }

    /// <summary>
    /// Gets the account name.
    /// </summary>
    ///
    /// <value>
    /// Account name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(2)]
    public string? Name { get; set; }

    /// <summary>
    /// Gets the account access levels.
    /// </summary>
    ///
    /// <value>
    /// Contains a list of access levels for account.
    /// </value>
    [JsonPropertyName("access_levels")]
    [JsonPropertyOrder(3)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<AccessLevel> AccessLevels { get; } = [];
}
