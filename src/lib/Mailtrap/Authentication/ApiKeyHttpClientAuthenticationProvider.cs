// -----------------------------------------------------------------------
// <copyright file="ApiKeyHttpClientAuthenticationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Authentication;


internal class ApiKeyHttpClientAuthenticationProvider : IHttpClientAuthenticationProvider
{
    private readonly IAccessTokenProvider _accessTokenProvider;


    public ApiKeyHttpClientAuthenticationProvider(IAccessTokenProvider accessTokenProvider)
    {
        Ensure.NotNull(accessTokenProvider, nameof(accessTokenProvider));

        _accessTokenProvider = accessTokenProvider;
    }


    public async Task AuthenticateAsync(HttpClient httpClient, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(httpClient, nameof(httpClient));

        var token = await _accessTokenProvider
            .GetAccessTokenAsync(cancellationToken)
            .ConfigureAwait(false);

        httpClient.WithApiAuthenticationHeader(token);
    }
}
