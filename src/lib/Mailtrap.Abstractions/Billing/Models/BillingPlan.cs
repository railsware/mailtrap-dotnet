// -----------------------------------------------------------------------
// <copyright file="BillingPlan.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Billing.Models;


/// <summary>
/// 
/// </summary>
public sealed record BillingPlan
{
    /// <summary>
    ///
    /// </summary>
    ///
    /// <value>
    ///
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(1)]
    public string? Name { get; }
}

