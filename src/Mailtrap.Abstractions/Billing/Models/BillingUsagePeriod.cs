// -----------------------------------------------------------------------
// <copyright file="BillingUsagePeriod.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Billing.Models;


/// <summary>
/// Represents billing period.
/// </summary>
public sealed record BillingUsagePeriod
{
    /// <summary>
    /// Gets start date of the billing period.
    /// </summary>
    ///
    /// <value>
    /// Start date of the billing period.
    /// </value>
    [JsonPropertyName("cycle_start")]
    [JsonPropertyOrder(1)]
    public DateTimeOffset? Start { get; set; }

    /// <summary>
    /// Gets end date of the billing period.
    /// </summary>
    ///
    /// <value>
    /// End date of the billing period.
    /// </value>
    [JsonPropertyName("cycle_end")]
    [JsonPropertyOrder(2)]
    public DateTimeOffset? End { get; set; }
}
