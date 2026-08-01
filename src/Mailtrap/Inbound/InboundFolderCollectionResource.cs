namespace Mailtrap.Inbound;


internal sealed class InboundFolderCollectionResource : RestResource, IInboundFolderCollectionResource
{
    public InboundFolderCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public Task<IList<InboundFolder>> GetAll(CancellationToken cancellationToken = default)
        => GetList<InboundFolder>(cancellationToken);

    public Task<InboundFolder> Create(CreateInboundFolderRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        return Create<CreateInboundFolderRequest, InboundFolder>(request, cancellationToken);
    }
}
