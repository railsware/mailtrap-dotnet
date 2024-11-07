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


    public IRestResourceCommand<TResponse> CreateGet<TResponse>(Uri resourceUri, params string[] additionalAcceptContentTypes)
        => new GetRestResourceCommand<TResponse>(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri,
            additionalAcceptContentTypes);

    public IRestResourceCommand<string> CreatePlainText(Uri resourceUri, params string[] additionalAcceptContentTypes)
        => new GetWithPlainTextResultRestResourceCommand(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri,
            additionalAcceptContentTypes);

    public IRestResourceCommand<TResponse> CreatePatch<TResponse>(Uri resourceUri)
        => new PatchRestResourceCommand<TResponse>(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri);

    public IRestResourceCommand<TResponse> CreateDelete<TResponse>(Uri resourceUri)
        => new DeleteRestResourceCommand<TResponse>(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri);

    public IRestResourceCommand<HttpStatusCode> CreatePostWithStatusCodeResult<TRequest>(Uri resourceUri, TRequest request)
        where TRequest : class
        => new PostWithStatusCodeResultRestResourceCommand<TRequest>(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri,
            request);

    public IRestResourceCommand<TResponse> CreatePost<TRequest, TResponse>(Uri resourceUri, TRequest request)
        where TRequest : class
        => new PostRestResourceCommand<TRequest, TResponse>(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri,
            request);

    public IRestResourceCommand<TResponse> CreatePut<TRequest, TResponse>(Uri resourceUri, TRequest request)
        where TRequest : class
        => new PutRestResourceCommand<TRequest, TResponse>(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri,
            request);

    public IRestResourceCommand<TResponse> CreatePatchWithContent<TRequest, TResponse>(Uri resourceUri, TRequest request)
        where TRequest : class
        => new PatchWithContentRestResourceCommand<TRequest, TResponse>(
            _httpClientFactory,
            _httpRequestMessageFactory,
            _httpResponseHandlerFactory,
            resourceUri,
            request);
}
