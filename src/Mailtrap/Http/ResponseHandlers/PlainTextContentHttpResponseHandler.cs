// -----------------------------------------------------------------------
// <copyright file="PlainTextContentHttpResponseHandler.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.ResponseHandlers;


internal sealed class PlainTextContentHttpResponseHandler : IHttpResponseHandler<string>
{
    private readonly HttpResponseMessage _httpResponseMessage;


    public PlainTextContentHttpResponseHandler(HttpResponseMessage httpResponseMessage)
    {
        Ensure.NotNull(httpResponseMessage, nameof(httpResponseMessage));

        _httpResponseMessage = httpResponseMessage;
    }


    public async Task<string> ProcessResponse(CancellationToken cancellationToken = default)
    {
        var content = await _httpResponseMessage.Content
            .ReadAsStringAsync()
            .ConfigureAwait(false);

        if (_httpResponseMessage.IsSuccessStatusCode)
        {
            return content ?? throw new EmptyResponseException(
                _httpResponseMessage.RequestMessage.RequestUri,
                _httpResponseMessage.RequestMessage.Method);
        }
        else
        {
            throw new BadRequestException(
                _httpResponseMessage.RequestMessage.RequestUri,
                _httpResponseMessage.RequestMessage.Method,
                _httpResponseMessage.StatusCode,
                _httpResponseMessage.ReasonPhrase,
                content);
        }
    }
}
