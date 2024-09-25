// -----------------------------------------------------------------------
// <copyright file="BillingUsagePeriod.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Billing.Models;


/// <summary>
/// 
/// </summary>
public sealed record BillingUsagePeriod
{
    /// <summary>
    ///
    /// </summary>
    ///
    /// <value>
    ///
    /// </value>
    [JsonPropertyName("cycle_start")]
    [JsonPropertyOrder(1)]
    public DateTimeOffset? Start { get; }

    /// <summary>
    ///
    /// </summary>
    ///
    /// <value>
    ///
    /// </value>
    [JsonPropertyName("cycle_end")]
    [JsonPropertyOrder(2)]
    public DateTimeOffset? End { get; }
}
