// -----------------------------------------------------------------------
// <copyright file="JsonContentHttpResponseHandler.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Http.ResponseHandlers;


internal sealed class JsonContentHttpResponseHandler<T> : HttpResponseHandler<T>
{
    public JsonContentHttpResponseHandler(
        JsonSerializerOptions jsonSerializerOptions,
        HttpResponseMessage httpResponseMessage)
        : base(jsonSerializerOptions, httpResponseMessage) { }


    protected override async Task<T> ProcessSuccessResponse(CancellationToken cancellationToken)
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
}
