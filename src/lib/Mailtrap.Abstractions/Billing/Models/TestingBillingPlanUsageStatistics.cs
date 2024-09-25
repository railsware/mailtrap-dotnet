// -----------------------------------------------------------------------
// <copyright file="TestingBillingPlanUsageStatistics.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Billing.Models;


/// <summary>
/// 
/// </summary>
public sealed record TestingBillingPlanUsageStatistics : BillingPlanUsageStatistics
{
    /// <summary>
    ///
    /// </summary>
    ///
    /// <value>
    ///
    /// </value>
    [JsonPropertyName("forwarded_messages_count")]
    [JsonPropertyOrder(2)]
    public BillingPlanUsageMessageCounters ForwardedMessageCounters { get; } = new();
}

