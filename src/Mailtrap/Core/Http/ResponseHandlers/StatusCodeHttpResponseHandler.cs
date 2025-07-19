namespace Mailtrap.Core.Http.ResponseHandlers;


internal sealed class StatusCodeHttpResponseHandler : HttpResponseHandler<HttpStatusCode>
{
    public StatusCodeHttpResponseHandler(
        JsonSerializerOptions jsonSerializerOptions,
        HttpResponseMessage httpResponseMessage)
        : base(jsonSerializerOptions, httpResponseMessage) { }


    protected override Task<HttpStatusCode> ProcessSuccessResponse(CancellationToken cancellationToken)
    {
        return Task.FromResult(_httpResponseMessage.StatusCode);
    }
}
