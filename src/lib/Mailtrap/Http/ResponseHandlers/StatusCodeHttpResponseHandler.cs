// -----------------------------------------------------------------------
// <copyright file="StatusCodeHttpResponseHandler.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.ResponseHandlers;


internal sealed class StatusCodeHttpResponseHandler : IHttpResponseHandler<HttpStatusCode>
{
    private readonly HttpResponseMessage _httpResponseMessage;


    public StatusCodeHttpResponseHandler(HttpResponseMessage httpResponseMessage)
    {
        Ensure.NotNull(httpResponseMessage, nameof(httpResponseMessage));

        _httpResponseMessage = httpResponseMessage;
    }


    public Task<HttpStatusCode> ProcessResponse(CancellationToken cancellationToken = default)
    {
        _httpResponseMessage.EnsureSuccessStatusCode();

        var response = _httpResponseMessage.StatusCode;

        return Task.FromResult(response);
    }
}
