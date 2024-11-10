// -----------------------------------------------------------------------
// <copyright file="BillingResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Billing;


internal sealed class BillingResource : RestResource, IBillingResource
{
    private const string UsageSegment = "usage";


    public BillingResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<BillingUsage> GetUsage(CancellationToken cancellationToken = default)
        => await Get<BillingUsage>(UsageSegment, cancellationToken).ConfigureAwait(false);
}
