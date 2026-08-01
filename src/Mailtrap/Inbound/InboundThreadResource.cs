namespace Mailtrap.Inbound;


internal sealed class InboundThreadResource : RestResource, IInboundThreadResource
{
    public InboundThreadResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public Task<InboundThread> GetDetails(CancellationToken cancellationToken = default)
        => Get<InboundThread>(cancellationToken);

    public Task Delete(CancellationToken cancellationToken = default)
        => DeleteWithStatusCodeResult(cancellationToken);
}
