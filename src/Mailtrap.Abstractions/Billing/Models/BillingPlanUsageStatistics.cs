// -----------------------------------------------------------------------
// <copyright file="BillingPlanUsageStatistics.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Billing.Models;


/// <summary>
/// Represents billing plan usage statistics for account.
/// </summary>
public record BillingPlanUsageStatistics
{
    /// <summary>
    /// Gets sent messages counters.
    /// </summary>
    ///
    /// <value>
    /// Sent messages counters.
    /// </value>
    [JsonPropertyName("sent_messages_count")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public BillingPlanUsageMessageCounters SentMessageCounters { get; } = new();
}

