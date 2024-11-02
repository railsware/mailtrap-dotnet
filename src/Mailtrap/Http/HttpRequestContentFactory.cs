// -----------------------------------------------------------------------
// <copyright file="HttpRequestContentFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http;


/// <summary>
/// <see cref="IHttpRequestContentFactory"/> default implementation.
/// </summary>
internal sealed class HttpRequestContentFactory : IHttpRequestContentFactory
{
    private readonly JsonSerializerOptions _jsonSerializerOptions;


    public HttpRequestContentFactory(IOptions<MailtrapClientOptions> clientOptions)
    {
        Ensure.NotNull(clientOptions, nameof(clientOptions));

        _jsonSerializerOptions = clientOptions.Value.ToJsonSerializerOptions();
    }


    /// <inheritdoc/>
    public StringContent? CreateStringContent<T>(T? content)
    {
        if (content == null)
        {
            return null;
        }

        var jsonContent = JsonSerializer.Serialize(content, _jsonSerializerOptions);
        var httpRequestContent = new StringContent(jsonContent).ApplyJsonContentTypeHeader();

        return httpRequestContent;
    }
}
