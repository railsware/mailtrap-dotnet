// -----------------------------------------------------------------------
// <copyright file="RestResourceCommand.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Rest.Commands;


internal abstract class RestResourceCommand<TResponse>
{
    private readonly IHttpClientFactory _httpClientFactory;
    protected readonly IHttpResponseHandlerFactory _httpResponseHandlerFactory;
    protected readonly IHttpRequestMessageFactory _httpRequestMessageFactory;


    public Uri ResourceUri { get; }
    public HttpMethod HttpMethod { get; }


    public RestResourceCommand(
        IHttpClientFactory httpClientFactory,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpResponseHandlerFactory httpResponseHandlerFactory,
        Uri resourceUri,
        HttpMethod httpMethod)
    {
        Ensure.NotNull(httpClientFactory, nameof(httpClientFactory));
        Ensure.NotNull(httpRequestMessageFactory, nameof(httpRequestMessageFactory));
        Ensure.NotNull(httpResponseHandlerFactory, nameof(httpResponseHandlerFactory));
        Ensure.NotNull(resourceUri, nameof(resourceUri));
        Ensure.NotNull(httpMethod, nameof(httpMethod));

        _httpClientFactory = httpClientFactory;
        _httpRequestMessageFactory = httpRequestMessageFactory;
        _httpResponseHandlerFactory = httpResponseHandlerFactory;

        ResourceUri = resourceUri;
        HttpMethod = httpMethod;
    }


    public async Task<TResponse> Execute(CancellationToken cancellationToken = default)
    {
        using var httpRequest = CreateHttpRequest();

        // Should not dispose HttpClient here, it's managed by the factory.
        // Also it can be a singleton instance, shared across requests.
        using var httpResponse = await _httpClientFactory
            .CreateClient(Client.Name)
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
