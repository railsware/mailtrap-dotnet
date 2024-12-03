// -----------------------------------------------------------------------
// <copyright file="PostWithStatusCodeResultRestResourceCommand.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Rest.Commands;


internal sealed class PostWithStatusCodeResultRestResourceCommand<TRequest>
    : PostRestResourceCommand<TRequest, HttpStatusCode>
    where TRequest : class
{
    public PostWithStatusCodeResultRestResourceCommand(
        IHttpClientProvider httpClientProvider,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpResponseHandlerFactory httpResponseHandlerFactory,
        Uri resourceUri,
        TRequest request)
        : base(
            httpClientProvider,
            httpRequestMessageFactory,
            httpResponseHandlerFactory,
            resourceUri,
            request)
    { }


    protected override IHttpResponseHandler<HttpStatusCode> CreateHttpResponseHandler(HttpResponseMessage httpResponseMessage)
        => _httpResponseHandlerFactory.CreateStatusCodeHandler(httpResponseMessage);
}
