// -----------------------------------------------------------------------
// <copyright file="SendingDomainDnsRecord.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomain.Models;


/// <summary>
/// Represents sending domain DNS record.
/// </summary>
public sealed record SendingDomainDnsRecord
{
    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("key")]
    [JsonPropertyOrder(1)]
    public string? Key { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("domain")]
    [JsonPropertyOrder(2)]
    public string? Domain { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("type")]
    [JsonPropertyOrder(3)]
    public string? Type { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("value")]
    [JsonPropertyOrder(4)]
    public string? Value { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("status")]
    [JsonPropertyOrder(5)]
    public string? Status { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(6)]
    public string? Name { get; }
}

