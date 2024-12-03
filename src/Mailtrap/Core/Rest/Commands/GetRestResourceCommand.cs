// -----------------------------------------------------------------------
// <copyright file="GetRestResourceCommand.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Rest.Commands;


internal class GetRestResourceCommand<TResponse> : RestResourceCommand<TResponse>
{
    private readonly string[] _acceptContentTypes;


    public GetRestResourceCommand(
        IHttpClientProvider httpClientProvider,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpResponseHandlerFactory httpResponseHandlerFactory,
        Uri resourceUri,
        params string[] additionalAcceptContentTypes)
        : base(
            httpClientProvider,
            httpRequestMessageFactory,
            httpResponseHandlerFactory,
            resourceUri,
            HttpMethod.Get)
    {
        Ensure.NotNull(additionalAcceptContentTypes, nameof(additionalAcceptContentTypes));

        _acceptContentTypes = additionalAcceptContentTypes;
    }


    protected override HttpRequestMessage CreateHttpRequest()
        => base.CreateHttpRequest().AppendAcceptHeaders(_acceptContentTypes);
}
