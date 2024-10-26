// -----------------------------------------------------------------------
// <copyright file="RestResourceCommandFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Rest;


internal sealed class RestResourceCommandFactory : IRestResourceCommandFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpResponseHandlerFactory _httpResponseHandlerFactory;
    private readonly IHttpRequestMessageFactory _httpRequestMessageFactory;


    public RestResourceCommandFactory(
        IHttpClientFactory httpClientFactory,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpResponseHandlerFactory httpResponseHandlerFactory)
    {
        Ensure.NotNull(httpClientFactory, nameof(httpClientFactory));
        Ensure.NotNull(httpRequestMessageFactory, nameof(httpRequestMessageFactory));
        Ensure.NotNull(httpResponseHandlerFactory, nameof(httpResponseHandlerFactory));

        _httpClientFactory = httpClientFactory;
        _httpRequestMessageFactory = httpRequestMessageFactory;
        _httpResponseHandlerFactory = httpResponseHandlerFactory;
    }


    public GetRestResourceCommand<TResponse> CreateGet<TResponse>(Uri resourceUri, params string[] additionalAcceptContentTypes)
        => new(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri,
            additionalAcceptContentTypes);

    public GetPlainTextRestResourceCommand CreatePlainText(Uri resourceUri, params string[] additionalAcceptContentTypes)
        => new(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri,
            additionalAcceptContentTypes);

    public PatchRestResourceCommand<TResponse> CreatePatch<TResponse>(Uri resourceUri)
        => new(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri);

    public DeleteRestResourceCommand<TResponse> CreateDelete<TResponse>(Uri resourceUri)
        => new(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri);

    public PostWithStatusCodeResultRestResourceCommand<TRequest> CreatePostWithStatusCodeResult<TRequest>(Uri resourceUri, TRequest request)
        where TRequest : class
        => new(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri,
            request);

    public PostRestResourceCommand<TRequest, TResponse> CreatePost<TRequest, TResponse>(Uri resourceUri, TRequest request)
        where TRequest : class
        => new(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri,
            request);

    public PutRestResourceCommand<TRequest, TResponse> CreatePut<TRequest, TResponse>(Uri resourceUri, TRequest request)
        where TRequest : class
        => new(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri,
            request);

    public PatchWithContentRestResourceCommand<TRequest, TResponse> CreatePatchWithContent<TRequest, TResponse>(Uri resourceUri, TRequest request)
        where TRequest : class
        => new(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri,
            request);
}
