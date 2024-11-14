// -----------------------------------------------------------------------
// <copyright file="SendingDomainComplianceStatus.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomains.Models;


/// <summary>
/// Represents compliance status of the sending domain.
/// </summary>
public sealed record SendingDomainComplianceStatus : StringEnum<SendingDomainComplianceStatus>
{
    /// <summary>
    /// Gets the value representing "initial" compliance status.
    /// </summary>
    ///
    /// <value>
    /// Represents "initial" compliance status.
    /// </value>
    public static SendingDomainComplianceStatus Initial { get; } = Define("initial");

    /// <summary>
    /// Gets the value representing "pending" compliance status.
    /// </summary>
    ///
    /// <value>
    /// Represents "pending" compliance status.
    /// </value>
    public static SendingDomainComplianceStatus Pending { get; } = Define("pending");

    /// <summary>
    /// Gets the value representing "under_review" compliance status.
    /// </summary>
    ///
    /// <value>
    /// Represents "under_review" compliance status.
    /// </value>
    public static SendingDomainComplianceStatus UnderReview { get; } = Define("under_review");

    /// <summary>
    /// Gets the value representing "non_compliant" status.
    /// </summary>
    ///
    /// <value>
    /// Represents "non_compliant" status.
    /// </value>
    public static SendingDomainComplianceStatus NonCompliant { get; } = Define("non_compliant");

    /// <summary>
    /// Gets the value representing "compliant" status.
    /// </summary>
    ///
    /// <value>
    /// Represents "compliant" status.
    /// </value>
    public static SendingDomainComplianceStatus Compliant { get; } = Define("compliant");
}
