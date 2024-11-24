// -----------------------------------------------------------------------
// <copyright file="SendingDomainDnsRecord.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomains.Models;


/// <summary>
/// Represents sending domain DNS record information.
/// </summary>
public sealed record SendingDomainDnsRecord
{
    /// <summary>
    /// Gets DNS record key.
    /// </summary>
    ///
    /// <value>
    /// DNS record key.
    /// </value>
    [JsonPropertyName("key")]
    [JsonPropertyOrder(1)]
    public string? Key { get; set; }

    /// <summary>
    /// Gets the DNS record domain.
    /// </summary>
    ///
    /// <value>
    /// DNS record domain.
    /// </value>
    [JsonPropertyName("domain")]
    [JsonPropertyOrder(2)]
    public string? Domain { get; set; }

    /// <summary>
    /// Gets DNS record type.
    /// </summary>
    ///
    /// <value>
    /// DNS record type.
    /// </value>
    [JsonPropertyName("type")]
    [JsonPropertyOrder(3)]
    public string? Type { get; set; }

    /// <summary>
    /// Gets DNS record value.
    /// </summary>
    ///
    /// <value>
    /// DNS record value.
    /// </value>
    [JsonPropertyName("value")]
    [JsonPropertyOrder(4)]
    public string? Value { get; set; }

    /// <summary>
    /// Gets DNS record status.
    /// </summary>
    ///
    /// <value>
    /// DNS record status.
    /// </value>
    [JsonPropertyName("status")]
    [JsonPropertyOrder(5)]
    public SendingDomainDnsRecordStatus Status { get; set; } = SendingDomainDnsRecordStatus.Unknown;

    /// <summary>
    /// Gets DNS record name.
    /// </summary>
    ///
    /// <value>
    /// DNS record name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(6)]
    public string? Name { get; set; }
}

