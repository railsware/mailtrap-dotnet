// -----------------------------------------------------------------------
// <copyright file="HttpResponseHandlerFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Http;


internal sealed class HttpResponseHandlerFactory : IHttpResponseHandlerFactory
{
    private readonly JsonSerializerOptions _jsonSerializerOptions;


    public HttpResponseHandlerFactory(IOptions<MailtrapClientOptions> clientOptions)
    {
        Ensure.NotNull(clientOptions, nameof(clientOptions));

        _jsonSerializerOptions = clientOptions.Value.ToJsonSerializerOptions();
    }


    public IHttpResponseHandler<T> CreateJsonContentHandler<T>(HttpResponseMessage httpResponseMessage)
        => new JsonContentHttpResponseHandler<T>(_jsonSerializerOptions, httpResponseMessage);

    public IHttpResponseHandler<string> CreatePlainTextContentHandler(HttpResponseMessage httpResponseMessage)
        => new PlainTextContentHttpResponseHandler(_jsonSerializerOptions, httpResponseMessage);

    public IHttpResponseHandler<HttpStatusCode> CreateStatusCodeHandler(HttpResponseMessage httpResponseMessage)
        => new StatusCodeHttpResponseHandler(_jsonSerializerOptions, httpResponseMessage);
}
