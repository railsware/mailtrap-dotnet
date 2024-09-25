// -----------------------------------------------------------------------
// <copyright file="BillingUsageDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Billing.Models;


/// <summary>
/// 
/// </summary>
public sealed record BillingUsageDetails
{
    /// <summary>
    ///
    /// </summary>
    ///
    /// <value>
    ///
    /// </value>
    [JsonPropertyName("billing")]
    [JsonPropertyOrder(1)]
    public BillingUsagePeriod Billing { get; } = new();

    /// <summary>
    ///
    /// </summary>
    ///
    /// <value>
    ///
    /// </value>
    [JsonPropertyName("testing")]
    [JsonPropertyOrder(2)]
    public BillingPlanUsageDetails<TestingBillingPlanUsageStatistics> Testing { get; } = new();

    /// <summary>
    ///
    /// </summary>
    ///
    /// <value>
    ///
    /// </value>
    [JsonPropertyName("sending")]
    [JsonPropertyOrder(3)]
    public BillingPlanUsageDetails<BillingPlanUsageStatistics> Sending { get; } = new();
}

