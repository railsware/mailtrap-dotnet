// -----------------------------------------------------------------------
// <copyright file="BillingPlanUsageDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Billing.Models;


/// <summary>
/// 
/// </summary>
public sealed record BillingPlanUsageDetails<TUsageStatistics>
    where TUsageStatistics : BillingPlanUsageStatistics, new()
{
    /// <summary>
    ///
    /// </summary>
    ///
    /// <value>
    ///
    /// </value>
    [JsonPropertyName("plan")]
    [JsonPropertyOrder(1)]
    public BillingPlan Plan { get; } = new();

    /// <summary>
    ///
    /// </summary>
    ///
    /// <value>
    ///
    /// </value>
    [JsonPropertyName("usage")]
    [JsonPropertyOrder(2)]
    public TUsageStatistics Usage { get; } = new();
}

