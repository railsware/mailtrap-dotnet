namespace Mailtrap.Inbound;


internal sealed class InboundInboxResource : RestResource, IInboundInboxResource
{
    public InboundInboxResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public Task<InboundInbox> GetDetails(CancellationToken cancellationToken = default)
        => Get<InboundInbox>(cancellationToken);

    public Task<InboundInbox> Update(UpdateInboundInboxRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        return Update<UpdateInboundInboxRequest, InboundInbox>(request, cancellationToken);
    }

    public Task Delete(CancellationToken cancellationToken = default)
        => DeleteWithStatusCodeResult(cancellationToken);
}
