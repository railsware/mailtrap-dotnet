// -----------------------------------------------------------------------
// <copyright file="AccountAccessCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------



namespace Mailtrap.AccountAccesses;


internal sealed class AccountAccessCollectionResource : RestResource, IAccountAccessCollectionResource
{
    private const string ProjectsQueryParameter = "project_ids";
    private const string InboxesQueryParameter = "inbox_ids";
    private const string DomainsQueryParameter = "domain_ids";


    public AccountAccessCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<IList<AccountAccess>> Fetch(AccountAccessFilter? filter = null, CancellationToken cancellationToken = default)
        => await GetList<AccountAccess>(CreateFetchUri(filter), cancellationToken).ConfigureAwait(false);


    private Uri CreateFetchUri(AccountAccessFilter? filter)
    {
        var uri = ResourceUri;

        // TODO: Ensure serialization is correct
        if (filter?.ProjectIds is not null)
        {
            var projects = JsonSerializer.Serialize(filter.ProjectIds);
            uri = uri.AppendQueryParameter(ProjectsQueryParameter, projects);
        }

        if (filter?.InboxIds is not null)
        {
            var inboxes = JsonSerializer.Serialize(filter.InboxIds);
            uri = uri.AppendQueryParameter(InboxesQueryParameter, inboxes);
        }

        if (filter?.DomainIds is not null)
        {
            var domains = JsonSerializer.Serialize(filter.DomainIds);
            uri = uri.AppendQueryParameter(DomainsQueryParameter, domains);
        }

        return uri;
    }
}
