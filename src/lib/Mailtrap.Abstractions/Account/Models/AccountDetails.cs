// -----------------------------------------------------------------------
// <copyright file="AccountDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Account.Models;


/// <summary>
/// Represents account details.
/// </summary>
public sealed record AccountDetails
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
    public long? AccountId { get; }

    /// <summary>
    /// Gets the account name.
    /// </summary>
    ///
    /// <value>
    /// Account name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(2)]
    public string? Name { get; }

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
    public IList<AccountAccessLevel> AccessLevels { get; } = [];
}
