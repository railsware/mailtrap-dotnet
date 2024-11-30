// -----------------------------------------------------------------------
// <copyright file="SendingDomain.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomains.Models;


/// <summary>
/// Represents sending domain information.<br />
/// Lists domain attributes, DNS records, status, etc.
/// </summary>
public sealed record SendingDomain
{
    /// <summary>
    /// Gets sending domain identifier.
    /// </summary>
    ///
    /// <value>
    /// Sending domain identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    [JsonRequired]
    public long Id { get; set; }

    /// <summary>
    /// Gets sending domain name.
    /// </summary>
    ///
    /// <value>
    /// Sending domain name.
    /// </value>
    [JsonPropertyName("domain_name")]
    [JsonPropertyOrder(2)]
    public string? DomainName { get; set; }

    /// <summary>
    /// Gets flag indicating demo sending domain.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if it is a demo sending domain.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("demo")]
    [JsonPropertyOrder(3)]
    public bool? Demo { get; set; }

    /// <summary>
    /// Gets compliance status of the domain.
    /// </summary>
    ///
    /// <value>
    /// Compliance status of domain.
    /// </value>
    [JsonPropertyName("compliance_status")]
    [JsonPropertyOrder(4)]
    public SendingDomainComplianceStatus ComplianceStatus { get; set; } = SendingDomainComplianceStatus.Unknown;

    /// <summary>
    /// Gets flag indicating if DNS was verified for the sending domain.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if DNS was verified.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("dns_verified")]
    [JsonPropertyOrder(5)]
    public bool? DnsVerified { get; set; }

    /// <summary>
    /// Gets a list of DNS records for the domain.
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
    /// Gets flag indicating if open tracking was enabled for the sending domain.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if open tracking was enabled.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("open_tracking_enabled")]
    [JsonPropertyOrder(7)]
    public bool? OpenTrackingEnabled { get; set; }

    /// <summary>
    /// Gets flag indicating if click tracking was enabled for the sending domain.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if click tracking was enabled.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("click_tracking_enabled")]
    [JsonPropertyOrder(8)]
    public bool? ClickTrackingEnabled { get; set; }

    /// <summary>
    /// Gets flag indicating if automatic unsubscribe link was enabled for the sending domain.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if automatic unsubscribe link was enabled.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("auto_unsubscribe_link_enabled")]
    [JsonPropertyOrder(9)]
    public bool? AutoUnsubscribeLinkEnabled { get; set; }

    /// <summary>
    /// Gets flag indicating if custom domain tracking was enabled for the sending domain.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if custom domain tracking was enabled.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("custom_domain_tracking_enabled")]
    [JsonPropertyOrder(10)]
    public bool? CustomDomainTrackingEnabled { get; set; }

    /// <summary>
    /// Gets flag indicating if health alerts were enabled for the sending domain.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if health alerts were enabled.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("health_alerts_enabled")]
    [JsonPropertyOrder(11)]
    public bool? HealthAlertsEnabled { get; set; }

    /// <summary>
    /// Gets flag indicating if critical alerts were enabled for the sending domain.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if critical alerts were enabled.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("critical_alerts_enabled")]
    [JsonPropertyOrder(12)]
    public bool? CriticalAlertsEnabled { get; set; }

    /// <summary>
    /// Gets email address of the alerts recipient.
    /// </summary>
    ///
    /// <value>
    /// Email address of the alerts recipient.
    /// </value>
    [JsonPropertyName("alert_recipient_email")]
    [JsonPropertyOrder(13)]
    public string? AlertRecipientEmail { get; set; }

    /// <summary>
    /// Gets permissions for the sending domain.
    /// </summary>
    ///
    /// <value>
    /// Permissions for sending domain.
    /// </value>
    [JsonPropertyName("permissions")]
    [JsonPropertyOrder(14)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public SendingDomainPermissions Permissions { get; } = new();
}
