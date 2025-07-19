namespace Mailtrap.Core.Rest.Commands;


internal sealed class DeleteRestResourceCommand<TResponse> : RestResourceCommand<TResponse>
{
    public DeleteRestResourceCommand(
        IHttpClientProvider httpClientProvider,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpResponseHandlerFactory httpResponseHandlerFactory,
        Uri resourceUri)
        : base(
            httpClientProvider,
            httpRequestMessageFactory,
            httpResponseHandlerFactory,
            resourceUri,
            HttpMethod.Delete)
    { }
}
