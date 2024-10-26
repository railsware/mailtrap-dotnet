// -----------------------------------------------------------------------
// <copyright file="EmailCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails;


internal sealed class EmailCollectionResource : RestResource, IEmailCollectionResource
{
    private const string LastIdQueryParameter = "last_id";
    private const string PageQueryParameter = "page";
    private const string SearchFilterQueryParameter = "search";


    public EmailCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<IList<EmailMessage>> Fetch(
        EmailMessageFilter? filter = null,
        CancellationToken cancellationToken = default)
        => await GetList<EmailMessage>(CreateFetchUri(filter), cancellationToken).ConfigureAwait(false);


    private Uri CreateFetchUri(EmailMessageFilter? filter)
    {
        var uri = ResourceUri;

        if (filter?.LastId is not null)
        {
            var page = filter.LastId.Value.ToUriSegment();
            uri = uri.AppendQueryParameter(LastIdQueryParameter, page);
        }

        if (filter?.Page is not null)
        {
            var page = filter.Page.Value.ToUriSegment();
            uri = uri.AppendQueryParameter(PageQueryParameter, page);
        }

        if (!string.IsNullOrEmpty(filter?.SearchFilter))
        {
            var searchFilter = filter?.SearchFilter!;
            uri = uri.AppendQueryParameter(SearchFilterQueryParameter, searchFilter);
        }

        return uri;
    }
}
