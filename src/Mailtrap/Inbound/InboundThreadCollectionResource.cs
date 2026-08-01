namespace Mailtrap.Inbound;


internal sealed class InboundThreadCollectionResource : RestResource, IInboundThreadCollectionResource
{
    private const string LastIdParameter = "last_id";


    public InboundThreadCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public Task<InboundThreadsListResponse> List(string? lastId = null, CancellationToken cancellationToken = default)
    {
        var uri = string.IsNullOrEmpty(lastId)
            ? ResourceUri
            : ResourceUri.AppendQueryParameters([new KeyValuePair<string, string>(LastIdParameter, lastId!)]);

        return RestResourceCommandFactory
            .CreateGet<InboundThreadsListResponse>(uri)
            .Execute(cancellationToken);
    }
}
