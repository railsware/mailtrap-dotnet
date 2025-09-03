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


    public IProjectCollectionResource Projects()
        => new ProjectCollectionResource(RestResourceCommandFactory, ResourceUri.Append(UrlSegments.ProjectsSegment));

    public IProjectResource Project(long projectId)
        => new ProjectResource(RestResourceCommandFactory, ResourceUri.Append(UrlSegments.ProjectsSegment).Append(projectId));


    // Passing account resource URI is expected, since we need to append both:
    // inboxes and projects segments to it for different scenarios.
    public IInboxCollectionResource Inboxes()
        => new InboxCollectionResource(RestResourceCommandFactory, ResourceUri);

    public IInboxResource Inbox(long inboxId)
        => new InboxResource(RestResourceCommandFactory, ResourceUri.Append(UrlSegments.InboxesSegment).Append(inboxId));

    public IContactCollectionResource Contacts()
        => new ContactCollectionResource(RestResourceCommandFactory, ResourceUri.Append(UrlSegments.ContactsSegment));

    public IContactResource Contact(string idOrEmail)
        => new ContactResource(RestResourceCommandFactory, ResourceUri.Append(UrlSegments.ContactsSegment).Append(idOrEmail));

}
