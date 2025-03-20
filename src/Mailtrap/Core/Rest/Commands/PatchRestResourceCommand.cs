namespace Mailtrap.Core.Rest.Commands;


internal sealed class PatchRestResourceCommand<TResponse> : RestResourceCommand<TResponse>
{
    public PatchRestResourceCommand(
        IHttpClientProvider httpClientProvider,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpResponseHandlerFactory httpResponseHandlerFactory,
        Uri resourceUri)
        : base(
            httpClientProvider,
            httpRequestMessageFactory,
            httpResponseHandlerFactory,
            resourceUri,
            HttpMethodEx.Patch)
    { }
}
