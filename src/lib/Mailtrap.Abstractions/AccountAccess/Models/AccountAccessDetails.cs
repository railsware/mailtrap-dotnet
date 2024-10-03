// -----------------------------------------------------------------------
// <copyright file="AccountAccessDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.AccountAccess.Models;


/// <summary>
/// Represents account access details.
/// </summary>
public sealed record AccountAccessDetails
{
    /// <summary>
    /// Gets the account access identifier.
    /// </summary>
    ///
    /// <value>
    /// Account access identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    [JsonRequired]
    public long Id { get; }

    /// <summary>
    /// Gets the specifier type for the account access.
    /// </summary>
    ///
    /// <value>
    /// Specifier type for the account access.
    /// </value>
    [JsonPropertyName("specifier_type")]
    [JsonPropertyOrder(2)]
    public string? SpecifierType { get; }

    /// <summary>
    /// Gets the specifier details for the account access.
    /// </summary>
    ///
    /// <value>
    /// Specifier details for the account access.
    /// </value>
    [JsonPropertyName("specifier")]
    [JsonPropertyOrder(3)]
    public AccountAccessSpecifier? Specifier { get; }

    /// <summary>
    /// Gets the collection of resources for the account access.
    /// </summary>
    ///
    /// <value>
    /// Contains a list of resources for the account access.
    /// </value>
    [JsonPropertyName("resources")]
    [JsonPropertyOrder(4)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<AccountAccessResourceDetails> Resources { get; } = [];

    /// <summary>
    /// Gets account access permissions.
    /// </summary>
    ///
    /// <value>
    /// Account access permissions.
    /// </value>
    [JsonPropertyName("permissions")]
    [JsonPropertyOrder(5)]
    public AccountAccessPermissions Permissions { get; } = new();
}
