namespace Mailtrap.Billing.Models;


/// <summary>
/// Represents billing plan details for account.
/// </summary>
public sealed record BillingPlan
{
    /// <summary>
    /// Gets or sets billing plan name.
    /// </summary>
    ///
    /// <value>
    /// Billing plan name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(1)]
    public string? Name { get; set; }
}

