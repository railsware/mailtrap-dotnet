namespace Mailtrap.Inbound;


internal sealed class InboundFolderResource : RestResource, IInboundFolderResource
{
    public InboundFolderResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public Task<InboundFolder> GetDetails(CancellationToken cancellationToken = default)
        => Get<InboundFolder>(cancellationToken);

    public Task<InboundFolder> Update(UpdateInboundFolderRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        return Update<UpdateInboundFolderRequest, InboundFolder>(request, cancellationToken);
    }

    public Task Delete(CancellationToken cancellationToken = default)
        => DeleteWithStatusCodeResult(cancellationToken);


    public IInboundInboxCollectionResource Inboxes()
        => new InboundInboxCollectionResource(RestResourceCommandFactory, ResourceUri.Append(UrlSegments.InboxesSegment));

    public IInboundInboxResource Inbox(long inboxId)
    {
        Ensure.GreaterThanZero(inboxId, nameof(inboxId));

        return new InboundInboxResource(RestResourceCommandFactory, ResourceUri.Append(UrlSegments.InboxesSegment).Append(inboxId));
    }
}
