namespace Mailtrap.Inbound;


internal sealed class InboundMessageCollectionResource : RestResource, IInboundMessageCollectionResource
{
    private const string LastIdParameter = "last_id";


    public InboundMessageCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public Task<InboundMessagesListResponse> List(string? lastId = null, CancellationToken cancellationToken = default)
    {
        var uri = string.IsNullOrEmpty(lastId)
            ? ResourceUri
            : ResourceUri.AppendQueryParameters([new KeyValuePair<string, string>(LastIdParameter, lastId!)]);

        return RestResourceCommandFactory
            .CreateGet<InboundMessagesListResponse>(uri)
            .Execute(cancellationToken);
    }
}
