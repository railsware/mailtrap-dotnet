// -----------------------------------------------------------------------
// <copyright file="StatusCodeHttpResponseHandler.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.ResponseHandlers;


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
