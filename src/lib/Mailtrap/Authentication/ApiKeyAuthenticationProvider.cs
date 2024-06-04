// -----------------------------------------------------------------------
// <copyright file="DefaultAuthenticationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------



namespace Mailtrap.Authentication;


internal class ApiKeyAuthenticationProvider : IAuthenticationProvider
{
    private readonly IAccessTokenProvider _accessTokenProvider;

    public ApiKeyAuthenticationProvider(IAccessTokenProvider accessTokenProvider)
    {
        ExceptionHelpers.ThrowIfNull(accessTokenProvider, nameof(accessTokenProvider));

        _accessTokenProvider = accessTokenProvider;
    }

    public async Task AuthenticateRequestAsync(HttpClient httpClient, CancellationToken cancellationToken = default)
    {
        ExceptionHelpers.ThrowIfNull(httpClient, nameof(httpClient));

        var token = await _accessTokenProvider
            .GetAccessTokenAsync(cancellationToken)
            .ConfigureAwait(false);

        httpClient.ConfigureApiAuthenticationHeader(token);
    }
}
