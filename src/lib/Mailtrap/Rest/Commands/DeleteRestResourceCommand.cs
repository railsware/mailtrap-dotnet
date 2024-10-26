// -----------------------------------------------------------------------
// <copyright file="DeleteRestResourceCommand.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Rest.Commands;


/// <summary>
/// </summary>
internal sealed class DeleteRestResourceCommand<TResponse> : RestResourceCommand<TResponse>
{
    public DeleteRestResourceCommand(
        IHttpClientFactory httpClientFactory,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpResponseHandlerFactory httpResponseHandlerFactory,
        Uri resourceUri)
        : base(
            httpClientFactory,
            httpRequestMessageFactory,
            httpResponseHandlerFactory,
            resourceUri)
    { }


    protected override HttpRequestMessage CreateHttpRequest()
        => _httpRequestMessageFactory.CreateDelete(ResourceUri);
}
