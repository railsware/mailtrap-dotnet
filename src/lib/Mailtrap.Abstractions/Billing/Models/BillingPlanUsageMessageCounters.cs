// -----------------------------------------------------------------------
// <copyright file="BillingPlanUsageMessageCounters.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Billing.Models;


/// <summary>
/// 
/// </summary>
public sealed record BillingPlanUsageMessageCounters
{
    /// <summary>
    ///
    /// </summary>
    ///
    /// <value>
    ///
    /// </value>
    [JsonPropertyName("current")]
    [JsonPropertyOrder(1)]
    public long Current { get; set; } = 0;

    /// <summary>
    ///
    /// </summary>
    ///
    /// <value>
    ///
    /// </value>
    [JsonPropertyName("limit")]
    [JsonPropertyOrder(1)]
    public long Limit { get; set; } = 0;
}
