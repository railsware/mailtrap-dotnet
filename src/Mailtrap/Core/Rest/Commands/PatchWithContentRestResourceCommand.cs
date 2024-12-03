// -----------------------------------------------------------------------
// <copyright file="PatchWithContentRestResourceCommand.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Rest.Commands;


internal sealed class PatchWithContentRestResourceCommand<TRequest, TResponse>
    : RestResourceCommandWithRequest<TRequest, TResponse>
    where TRequest : class
{
    public PatchWithContentRestResourceCommand(
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
            HttpMethodEx.Patch,
            request)
    { }
}
