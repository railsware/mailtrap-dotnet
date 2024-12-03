// -----------------------------------------------------------------------
// <copyright file="GetWithPlainTextResultRestResourceCommand.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Rest.Commands;


internal sealed class GetWithPlainTextResultRestResourceCommand : GetRestResourceCommand<string>
{
    public GetWithPlainTextResultRestResourceCommand(
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
