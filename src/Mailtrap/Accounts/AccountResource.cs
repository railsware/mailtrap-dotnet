// -----------------------------------------------------------------------
// <copyright file="AccountResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using AccountAccessResource = Mailtrap.AccountAccesses.AccountAccessResource;


namespace Mailtrap.Accounts;


internal sealed class AccountResource : RestResource, IAccountResource
{
    private const string BillingSegment = "billing";
    private const string PermissionsSegment = "permissions";
    private const string AccessesSegment = "account_accesses";
    private const string SendingDomainsSegment = "sending_domains";


    public AccountResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public IBillingResource Billing()
        => new BillingResource(RestResourceCommandFactory, ResourceUri.Append(BillingSegment));


    public IPermissionsResource Permissions()
        => new PermissionsResource(RestResourceCommandFactory, ResourceUri.Append(PermissionsSegment));


    public IAccountAccessCollectionResource Accesses()
        => new AccountAccessCollectionResource(RestResourceCommandFactory, ResourceUri.Append(AccessesSegment));

    public IAccountAccessResource Access(long accessId)
        => new AccountAccessResource(RestResourceCommandFactory, ResourceUri.Append(AccessesSegment).Append(accessId));


    public ISendingDomainCollectionResource SendingDomains()
        => new SendingDomainCollectionResource(RestResourceCommandFactory, ResourceUri.Append(SendingDomainsSegment));

    public ISendingDomainResource SendingDomain(long domainId)
        => new SendingDomainResource(RestResourceCommandFactory, ResourceUri.Append(SendingDomainsSegment).Append(domainId));
}
