// -----------------------------------------------------------------------
// <copyright file="SendingDomainDnsRecordStatus.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomains.Models;


/// <summary>
/// Represents the status of the DNS record for the sending domain.
/// </summary>
public sealed record SendingDomainDnsRecordStatus : StringEnum<SendingDomainDnsRecordStatus>
{
    /// <summary>
    /// Gets the value representing "pass" DNS record status.
    /// </summary>
    ///
    /// <value>
    /// Represents "pass" DNS record status.
    /// </value>
    public static SendingDomainDnsRecordStatus Pass { get; } = Define("pass");

    /// <summary>
    /// Gets the value representing "fail" DNS record status.
    /// </summary>
    ///
    /// <value>
    /// Represents "fail" DNS record status.
    /// </value>
    public static SendingDomainDnsRecordStatus Fail { get; } = Define("fail");

    /// <summary>
    /// Gets the value representing "unchecked" DNS record status.
    /// </summary>
    ///
    /// <value>
    /// Represents "unchecked" DNS record status.
    /// </value>
    public static SendingDomainDnsRecordStatus Unchecked { get; } = Define("unchecked");

    /// <summary>
    /// Gets the value representing "missing" DNS record status.
    /// </summary>
    ///
    /// <value>
    /// Represents "missing" DNS record status.
    /// </value>
    public static SendingDomainDnsRecordStatus Missing { get; } = Define("missing");

    /// <summary>
    /// Gets the value representing "softfail" DNS record status.
    /// </summary>
    ///
    /// <value>
    /// Represents "softfail" DNS record status.
    /// </value>
    public static SendingDomainDnsRecordStatus SoftFail { get; } = Define("softfail");

    /// <summary>
    /// Gets the value representing "network_error" DNS record status.
    /// </summary>
    ///
    /// <value>
    /// Represents "network_error" DNS record status.
    /// </value>
    public static SendingDomainDnsRecordStatus NetworkError { get; } = Define("network_error");
}
