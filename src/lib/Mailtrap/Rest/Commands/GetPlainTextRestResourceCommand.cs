// -----------------------------------------------------------------------
// <copyright file="GetPlainTextRestResourceCommand.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Rest.Commands;


/// <summary>
/// </summary>
internal sealed class GetPlainTextRestResourceCommand : GetRestResourceCommand<string>
{
    public GetPlainTextRestResourceCommand(
        IHttpClientFactory httpClientFactory,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpResponseHandlerFactory httpResponseHandlerFactory,
        Uri resourceUri,
        params string[] additionalAcceptContentTypes)
        : base(
            httpClientFactory,
            httpRequestMessageFactory,
            httpResponseHandlerFactory,
            resourceUri,
            additionalAcceptContentTypes)
    { }


    protected override IHttpResponseHandler<string> CreateHttpResponseHandler(HttpResponseMessage httpResponseMessage)
        => _httpResponseHandlerFactory.CreatePlainTextContentHandler(httpResponseMessage);
}
