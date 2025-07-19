namespace Mailtrap.Billing.Models;


/// <summary>
/// Represents billing plan usage statistics for testing.
/// </summary>
public sealed record TestingBillingPlanUsageStatistics : BillingPlanUsageStatistics
{
    /// <summary>
    /// Gets forwarded messages counters.
    /// </summary>
    ///
    /// <value>
    /// Forwarded messages counters.
    /// </value>
    [JsonPropertyName("forwarded_messages_count")]
    [JsonPropertyOrder(2)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public BillingPlanUsageMessageCounters ForwardedMessageCounters { get; } = new();
}

