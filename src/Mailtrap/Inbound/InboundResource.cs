namespace Mailtrap.Inbound;


internal sealed class InboundResource : RestResource, IInboundResource
{
    public InboundResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public IInboundFolderCollectionResource Folders()
        => new InboundFolderCollectionResource(RestResourceCommandFactory, ResourceUri.Append(UrlSegments.FoldersSegment));

    public IInboundFolderResource Folder(long folderId)
    {
        Ensure.GreaterThanZero(folderId, nameof(folderId));

        return new InboundFolderResource(RestResourceCommandFactory, ResourceUri.Append(UrlSegments.FoldersSegment).Append(folderId));
    }

    public IInboundInboxContentResource Inbox(long inboxId)
    {
        Ensure.GreaterThanZero(inboxId, nameof(inboxId));

        return new InboundInboxContentResource(RestResourceCommandFactory, ResourceUri.Append(UrlSegments.InboxesSegment).Append(inboxId));
    }
}
