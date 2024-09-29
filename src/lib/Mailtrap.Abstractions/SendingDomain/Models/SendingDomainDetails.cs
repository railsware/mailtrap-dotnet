// -----------------------------------------------------------------------
// <copyright file="SendingDomainDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomain.Models;


/// <summary>
/// Lists domain attributes, DNS records, status, etc.
/// </summary>
public sealed record SendingDomainDetails
{
    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    [JsonRequired]
    public long Id { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("domain_name")]
    [JsonPropertyOrder(2)]
    public string? DomainName { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("demo")]
    [JsonPropertyOrder(3)]
    public bool? Demo { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("compliance_status")]
    [JsonPropertyOrder(4)]
    public string? ComplianceStatus { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("dns_verified")]
    [JsonPropertyOrder(5)]
    public bool? DnsVerified { get; }

    /// <summary>
    /// Gets a list of DNS records for domain.
    /// </summary>
    ///
    /// <value>
    /// List of DNS records for domain.
    /// </value>
    [JsonPropertyName("dns_records")]
    [JsonPropertyOrder(6)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<SendingDomainDnsRecord> DnsRecords { get; } = [];

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("open_tracking_enabled")]
    [JsonPropertyOrder(7)]
    public bool? OpenTrackingEnabled { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("click_tracking_enabled")]
    [JsonPropertyOrder(8)]
    public bool? ClickTrackingEnabled { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("auto_unsubscribe_link_enabled")]
    [JsonPropertyOrder(9)]
    public bool? AutoUnsubscribeLinkEnabled { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("custom_domain_tracking_enabled")]
    [JsonPropertyOrder(10)]
    public bool? CustomDomainTrackingEnabled { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("health_alerts_enabled")]
    [JsonPropertyOrder(11)]
    public bool? HealthAlertsEnabled { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("critical_alerts_enabled")]
    [JsonPropertyOrder(12)]
    public bool? CriticalAlertsEnabled { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("alert_recipient_email")]
    [JsonPropertyOrder(13)]
    public string? AlertRecipientEmail { get; }

    /// <summary>
    /// </summary>
    ///
    /// <value>
    /// </value>
    [JsonPropertyName("permissions")]
    [JsonPropertyOrder(14)]
    public SendingDomainPermissions Permissions { get; } = new();
}
