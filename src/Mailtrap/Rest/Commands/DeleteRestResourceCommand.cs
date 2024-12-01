// -----------------------------------------------------------------------
// <copyright file="DeleteRestResourceCommand.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Rest.Commands;


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
