// -----------------------------------------------------------------------
// <copyright file="ApiKeyAuthenticationHttpRequestMessagePolicy.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


/// <summary>
/// <see cref="IHttpRequestMessagePolicy"/> implementation that applies authentication headers to the request,
/// required by Mailtrap API.
/// </summary>
internal class ApiKeyAuthenticationHttpRequestMessagePolicy : IHttpRequestMessagePolicy
{
    private readonly IAccessTokenProvider _accessTokenProvider;


    public ApiKeyAuthenticationHttpRequestMessagePolicy(IAccessTokenProvider accessTokenProvider)
    {
        Ensure.NotNull(accessTokenProvider, nameof(accessTokenProvider));

        _accessTokenProvider = accessTokenProvider;
    }


    public async Task ApplyPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        var token = await _accessTokenProvider
            .GetAccessTokenAsync(cancellationToken)
            .ConfigureAwait(false);

        request.ConfigureApiAuthenticationHeader(token);
    }
}
