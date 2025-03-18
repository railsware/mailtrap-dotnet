namespace Mailtrap.Core.Http.ResponseHandlers;


internal sealed class PlainTextContentHttpResponseHandler : HttpResponseHandler<string>
{
    public PlainTextContentHttpResponseHandler(
        JsonSerializerOptions jsonSerializerOptions,
        HttpResponseMessage httpResponseMessage)
        : base(jsonSerializerOptions, httpResponseMessage) { }


    protected override async Task<string> ProcessSuccessResponse(CancellationToken cancellationToken)
    {
        var content = await _httpResponseMessage.Content
            .ReadAsStringAsync()
            .ConfigureAwait(false);

        return content ?? throw new EmptyResponseException(
            _httpResponseMessage.RequestMessage.RequestUri,
            _httpResponseMessage.RequestMessage.Method);
    }
}
