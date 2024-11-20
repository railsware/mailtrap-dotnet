// -----------------------------------------------------------------------
// <copyright file="InboxCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Inboxes;


internal sealed class InboxCollectionResource : RestResource, IInboxCollectionResource
{
    private readonly Uri _projectsResourceUri;


    public InboxCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri.Append(UrlSegments.InboxesSegment))
    {
        _projectsResourceUri = resourceUri.Append(UrlSegments.ProjectsSegment);
    }


    public async Task<IList<Inbox>> GetAll(CancellationToken cancellationToken = default)
        => await GetList<Inbox>(cancellationToken).ConfigureAwait(false);

    public async Task<Inbox> Create(CreateInboxRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        var uri = _projectsResourceUri.Append(request.ProjectId).Append(UrlSegments.InboxesSegment);

        var result = await RestResourceCommandFactory
                .CreatePost<CreateInboxRequestDto, Inbox>(uri, request.ToDto())
                .Execute(cancellationToken)
                .ConfigureAwait(false);

        return result;
    }
}
