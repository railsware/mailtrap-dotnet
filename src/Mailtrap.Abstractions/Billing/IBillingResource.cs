// -----------------------------------------------------------------------
// <copyright file="IBillingResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Billing;


/// <summary>
/// Represents account billing resource.
/// </summary>
public interface IBillingResource : IRestResource
{
    /// <summary>
    /// Gets current billing cycle usage for Email Testing and Email Sending.
    /// </summary>
    /// 
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Billing usage details.
    /// </returns>
    public Task<BillingUsage> GetUsage(CancellationToken cancellationToken = default);
}
