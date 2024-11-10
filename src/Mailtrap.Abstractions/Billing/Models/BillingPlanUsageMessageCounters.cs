// -----------------------------------------------------------------------
// <copyright file="BillingPlanUsageMessageCounters.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Billing.Models;


/// <summary>
/// Represents billing plan usage counters for account.
/// </summary>
public sealed record BillingPlanUsageMessageCounters
{
    /// <summary>
    /// Gets current usage counter.
    /// </summary>
    ///
    /// <value>
    /// Current usage counter.
    /// </value>
    [JsonPropertyName("current")]
    [JsonPropertyOrder(1)]
    public long Current { get; set; } = 0;

    /// <summary>
    /// Gets usage limit.
    /// </summary>
    ///
    /// <value>
    /// Usage limit.
    /// </value>
    [JsonPropertyName("limit")]
    [JsonPropertyOrder(1)]
    public long Limit { get; set; } = 0;
}
