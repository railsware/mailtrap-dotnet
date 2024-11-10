// -----------------------------------------------------------------------
// <copyright file="BillingUsage.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Billing.Models;


/// <summary>
/// Represents billing usage details for account.
/// </summary>
public sealed record BillingUsage
{
    /// <summary>
    /// Gets billing usage period.
    /// </summary>
    ///
    /// <value>
    /// Billing usage period.
    /// </value>
    [JsonPropertyName("billing")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public BillingUsagePeriod Billing { get; } = new();

    /// <summary>
    /// Gets testing usage details.
    /// </summary>
    ///
    /// <value>
    /// Testing usage details.
    /// </value>
    [JsonPropertyName("testing")]
    [JsonPropertyOrder(2)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public BillingPlanUsage<TestingBillingPlanUsageStatistics> Testing { get; } = new();

    /// <summary>
    /// Gets sending usage details.
    /// </summary>
    ///
    /// <value>
    /// Sending usage details.
    /// </value>
    [JsonPropertyName("sending")]
    [JsonPropertyOrder(3)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public BillingPlanUsage<BillingPlanUsageStatistics> Sending { get; } = new();
}

