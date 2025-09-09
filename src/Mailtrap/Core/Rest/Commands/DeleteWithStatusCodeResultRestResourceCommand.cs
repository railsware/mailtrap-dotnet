namespace Mailtrap.Core.Rest.Commands;

internal sealed class DeleteWithStatusCodeResultRestResourceCommand<TResponse> : DeleteRestResourceCommand<HttpStatusCode>
{
    public DeleteWithStatusCodeResultRestResourceCommand(
        IHttpClientProvider httpClientProvider,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpResponseHandlerFactory httpResponseHandlerFactory,
        Uri resourceUri)
        : base(
            httpClientProvider,
            httpRequestMessageFactory,
            httpResponseHandlerFactory,
            resourceUri)
    { }

    protected override IHttpResponseHandler<HttpStatusCode> CreateHttpResponseHandler(HttpResponseMessage httpResponseMessage)
        => _httpResponseHandlerFactory.CreateStatusCodeHandler(httpResponseMessage);
}
