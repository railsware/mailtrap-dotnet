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


    public async Task<HttpStatusCode> ProcessResponse(CancellationToken cancellationToken = default)
    {
        if (_httpResponseMessage.IsSuccessStatusCode)
        {
            return _httpResponseMessage.StatusCode;
        }
        else
        {
            var content = await _httpResponseMessage.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            throw new BadRequestException(
                _httpResponseMessage.RequestMessage.RequestUri,
                _httpResponseMessage.RequestMessage.Method,
                _httpResponseMessage.StatusCode,
                _httpResponseMessage.ReasonPhrase,
                content);
        }
    }
}
