// -----------------------------------------------------------------------
// <copyright file="JsonContentHttpResponseHandler.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.ResponseHandlers;


internal sealed class JsonContentHttpResponseHandler<T> : IHttpResponseHandler<T>
{
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly HttpResponseMessage _httpResponseMessage;


    public JsonContentHttpResponseHandler(
        JsonSerializerOptions jsonSerializerOptions,
        HttpResponseMessage httpResponseMessage)
    {
        Ensure.NotNull(jsonSerializerOptions, nameof(jsonSerializerOptions));
        Ensure.NotNull(httpResponseMessage, nameof(httpResponseMessage));

        _jsonSerializerOptions = jsonSerializerOptions;
        _httpResponseMessage = httpResponseMessage;
    }


    public async Task<T> ProcessResponse(CancellationToken cancellationToken = default)
    {
        if (_httpResponseMessage.IsSuccessStatusCode)
        {
            var content = await _httpResponseMessage.Content
                .ReadAsStreamAsync()
                .ConfigureAwait(false);

            var response = await JsonSerializer
                .DeserializeAsync<T>(content, _jsonSerializerOptions, cancellationToken)
                .ConfigureAwait(false);

            return response ?? throw new EmptyResponseException(
                _httpResponseMessage.RequestMessage.RequestUri,
                _httpResponseMessage.RequestMessage.Method);
        }
        else
        {
            var content = await _httpResponseMessage.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            var problem = JsonSerializer.Deserialize<Problem>(content, _jsonSerializerOptions);

            throw new HttpRequestFailedException(
                _httpResponseMessage.RequestMessage.RequestUri,
                _httpResponseMessage.RequestMessage.Method,
                _httpResponseMessage.StatusCode,
                _httpResponseMessage.ReasonPhrase,
                problem?.ToString());
        }
    }
}
