// -----------------------------------------------------------------------
// <copyright file="PostRestResourceCommand.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Rest.Commands;


internal class PostRestResourceCommand<TRequest, TResponse>
    : RestResourceCommandWithRequest<TRequest, TResponse>
    where TRequest : class
{
    public PostRestResourceCommand(
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
            HttpMethod.Post,
            request)
    { }
}
