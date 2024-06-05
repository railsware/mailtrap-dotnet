// -----------------------------------------------------------------------
// <copyright file="HttpRequestMessageBuilder.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


internal sealed class HttpRequestMessageBuilder : IHttpRequestMessageBuilder
{
    private readonly IHttpRequestMessageConfigurationPolicy _requestConfigurationPolicy;


    public HttpRequestMessageBuilder(IHttpRequestMessageConfigurationPolicy requestConfigurationPolicy)
    {
        ExceptionHelpers.ThrowIfNull(requestConfigurationPolicy, nameof(requestConfigurationPolicy));

        _requestConfigurationPolicy = requestConfigurationPolicy;
    }


    public async Task<HttpRequestMessage> BuildAsync(HttpMethod method, Uri uri, HttpContent content)
    {
        var request = new HttpRequestMessage(method, uri)
        {
            Content = content
        };

        await _requestConfigurationPolicy
            .ApplyPolicyAsync(request)
            .ConfigureAwait(false);

        return request;
    }
}
