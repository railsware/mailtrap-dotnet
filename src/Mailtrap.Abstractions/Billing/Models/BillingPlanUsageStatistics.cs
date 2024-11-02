// -----------------------------------------------------------------------
// <copyright file="BillingPlanUsageStatistics.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Billing.Models;


/// <summary>
/// 
/// </summary>
public record BillingPlanUsageStatistics
{
    /// <summary>
    ///
    /// </summary>
    ///
    /// <value>
    ///
    /// </value>
    [JsonPropertyName("sent_messages_count")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public BillingPlanUsageMessageCounters SentMessageCounters { get; } = new();
}

