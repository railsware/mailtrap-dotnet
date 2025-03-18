namespace Mailtrap.Billing.Models;


/// <summary>
/// Represents billing plan usage details for account.
/// </summary>
public sealed record BillingPlanUsage<TUsageStatistics>
    where TUsageStatistics : BillingPlanUsageStatistics, new()
{
    /// <summary>
    /// Gets billing plan details.
    /// </summary>
    ///
    /// <value>
    /// Billing plan details.
    /// </value>
    [JsonPropertyName("plan")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public BillingPlan Plan { get; } = new();

    /// <summary>
    /// Gets billing plan usage statistics.
    /// </summary>
    ///
    /// <value>
    /// Billing plan usage statistics.
    /// </value>
    [JsonPropertyName("usage")]
    [JsonPropertyOrder(2)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public TUsageStatistics Usage { get; } = new();
}

