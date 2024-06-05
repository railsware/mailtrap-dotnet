// -----------------------------------------------------------------------
// <copyright file="ApiKeyHttpRequestMessageAuthenticationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Authentication;


internal class ApiKeyHttpRequestMessageAuthenticationProvider : IHttpRequestMessageAuthenticationProvider
{
    private readonly IAccessTokenProvider _accessTokenProvider;

    public ApiKeyHttpRequestMessageAuthenticationProvider(IAccessTokenProvider accessTokenProvider)
    {
        ExceptionHelpers.ThrowIfNull(accessTokenProvider, nameof(accessTokenProvider));

        _accessTokenProvider = accessTokenProvider;
    }

    public async Task AuthenticateAsync(HttpClient httpClient, CancellationToken cancellationToken = default)
    {
        ExceptionHelpers.ThrowIfNull(httpClient, nameof(httpClient));

        var token = await _accessTokenProvider
            .GetAccessTokenAsync(cancellationToken)
            .ConfigureAwait(false);

        httpClient.WithApiAuthenticationHeader(token);
    }

    public async Task AuthenticateAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        ExceptionHelpers.ThrowIfNull(request, nameof(request));

        var token = await _accessTokenProvider
            .GetAccessTokenAsync(cancellationToken)
            .ConfigureAwait(false);

        request.ConfigureApiAuthenticationHeader(token);
    }
}
