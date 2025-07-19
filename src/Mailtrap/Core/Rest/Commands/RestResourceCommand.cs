namespace Mailtrap.Core.Rest.Commands;


internal abstract class RestResourceCommand<TResponse> : IRestResourceCommand<TResponse>
{
    private readonly IHttpClientProvider _httpClientProvider;
    protected readonly IHttpResponseHandlerFactory _httpResponseHandlerFactory;
    protected readonly IHttpRequestMessageFactory _httpRequestMessageFactory;


    public Uri ResourceUri { get; }
    public HttpMethod HttpMethod { get; }


    public RestResourceCommand(
        IHttpClientProvider httpClientProvider,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpResponseHandlerFactory httpResponseHandlerFactory,
        Uri resourceUri,
        HttpMethod httpMethod)
    {
        Ensure.NotNull(httpClientProvider, nameof(httpClientProvider));
        Ensure.NotNull(httpRequestMessageFactory, nameof(httpRequestMessageFactory));
        Ensure.NotNull(httpResponseHandlerFactory, nameof(httpResponseHandlerFactory));
        Ensure.NotNull(resourceUri, nameof(resourceUri));
        Ensure.NotNull(httpMethod, nameof(httpMethod));

        _httpClientProvider = httpClientProvider;
        _httpRequestMessageFactory = httpRequestMessageFactory;
        _httpResponseHandlerFactory = httpResponseHandlerFactory;

        ResourceUri = resourceUri;
        HttpMethod = httpMethod;
    }


    public async Task<TResponse> Execute(CancellationToken cancellationToken = default)
    {
        using var httpRequest = CreateHttpRequest();

        // Should not dispose HttpClient here, since its lifetime is managed by provider.
        // Also it can be a singleton instance, shared across requests.
        using var httpResponse = await _httpClientProvider.Client
            .SendAsync(httpRequest, cancellationToken)
            .ConfigureAwait(false);

        var response = await CreateHttpResponseHandler(httpResponse)
            .ProcessResponse(cancellationToken)
            .ConfigureAwait(false);

        return response;
    }


    protected virtual HttpRequestMessage CreateHttpRequest()
        => _httpRequestMessageFactory.Create(HttpMethod, ResourceUri);

    protected virtual IHttpResponseHandler<TResponse> CreateHttpResponseHandler(HttpResponseMessage httpResponseMessage)
        => _httpResponseHandlerFactory.CreateJsonContentHandler<TResponse>(httpResponseMessage);
}
