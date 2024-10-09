// -----------------------------------------------------------------------
// <copyright file="BillingUsage.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Billing.Models;


/// <summary>
/// 
/// </summary>
public sealed record BillingUsage
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
    public BillingPlanUsage<TestingBillingPlanUsageStatistics> Testing { get; } = new();

    /// <summary>
    ///
    /// </summary>
    ///
    /// <value>
    ///
    /// </value>
    [JsonPropertyName("sending")]
    [JsonPropertyOrder(3)]
    public BillingPlanUsage<BillingPlanUsageStatistics> Sending { get; } = new();
}

