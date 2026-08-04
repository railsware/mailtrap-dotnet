namespace Mailtrap.Inbound;


internal sealed class InboundInboxCollectionResource : RestResource, IInboundInboxCollectionResource
{
    public InboundInboxCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public Task<IList<InboundInbox>> GetAll(CancellationToken cancellationToken = default)
        => GetList<InboundInbox>(cancellationToken);

    public Task<InboundInbox> Create(CreateInboundInboxRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        return Create<CreateInboundInboxRequest, InboundInbox>(request, cancellationToken);
    }
}
