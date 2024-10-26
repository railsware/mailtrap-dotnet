// -----------------------------------------------------------------------
// <copyright file="InboxCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Inboxes;


internal sealed class InboxCollectionResource : RestResource, IInboxCollectionResource
{
    public InboxCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<IList<Inbox>> GetAll(CancellationToken cancellationToken = default)
        => await GetList<Inbox>(cancellationToken).ConfigureAwait(false);

    public async Task<Inbox> Create(CreateInboxRequest request, CancellationToken cancellationToken = default)
        => await Create<CreateInboxRequestDto, Inbox>(request.ToDto(), cancellationToken).ConfigureAwait(false);
}
