// -----------------------------------------------------------------------
// <copyright file="ApiKeyHttpRequestMessageAuthenticationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Http.Request;


internal class ApiKeyHttpRequestMessageAuthenticationProvider : IHttpRequestMessageAuthenticationProvider
{
    private readonly IAccessTokenProvider _accessTokenProvider;


    public ApiKeyHttpRequestMessageAuthenticationProvider(IAccessTokenProvider accessTokenProvider)
    {
        Ensure.NotNull(accessTokenProvider, nameof(accessTokenProvider));

        _accessTokenProvider = accessTokenProvider;
    }


    public async Task AuthenticateAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        var token = await _accessTokenProvider
            .GetAccessTokenAsync(cancellationToken)
            .ConfigureAwait(false);

        request.ConfigureApiAuthenticationHeader(token);
    }
}
