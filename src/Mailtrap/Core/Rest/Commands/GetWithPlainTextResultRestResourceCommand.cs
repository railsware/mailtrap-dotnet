namespace Mailtrap.Core.Rest.Commands;


internal sealed class GetWithPlainTextResultRestResourceCommand : GetRestResourceCommand<string>
{
    public GetWithPlainTextResultRestResourceCommand(
        IHttpClientProvider httpClientProvider,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpResponseHandlerFactory httpResponseHandlerFactory,
        Uri resourceUri,
        params string[] additionalAcceptContentTypes)
        : base(
            httpClientProvider,
            httpRequestMessageFactory,
            httpResponseHandlerFactory,
            resourceUri,
            additionalAcceptContentTypes)
    { }


    protected override IHttpResponseHandler<string> CreateHttpResponseHandler(HttpResponseMessage httpResponseMessage)
        => _httpResponseHandlerFactory.CreatePlainTextContentHandler(httpResponseMessage);
}
