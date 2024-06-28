// -----------------------------------------------------------------------
// <copyright file="HttpRequestMessageFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


internal sealed class HttpRequestMessageFactory : IHttpRequestMessageFactory
{
    private readonly IHttpRequestMessageConfigurationPolicy _requestConfigurationPolicy;


    public HttpRequestMessageFactory(IHttpRequestMessageConfigurationPolicy requestConfigurationPolicy)
    {
        Ensure.NotNull(requestConfigurationPolicy, nameof(requestConfigurationPolicy));

        _requestConfigurationPolicy = requestConfigurationPolicy;
    }


    public async Task<HttpRequestMessage> CreateAsync(HttpMethod method, Uri uri, HttpContent content, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(method, nameof(method));
        Ensure.NotNull(uri, nameof(uri));
        Ensure.NotNull(content, nameof(content));

        var request = new HttpRequestMessage(method, uri)
        {
            Content = content
        };

        await _requestConfigurationPolicy
            .ApplyPolicyAsync(request, cancellationToken)
            .ConfigureAwait(false);

        return request;
    }
}
