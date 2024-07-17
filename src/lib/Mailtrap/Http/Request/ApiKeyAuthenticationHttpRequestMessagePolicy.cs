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


    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="accessTokenProvider">Token provider to get access token from.</param>
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="accessTokenProvider"/> is <see langword="null"/>.
    /// </exception>
    public ApiKeyAuthenticationHttpRequestMessagePolicy(IAccessTokenProvider accessTokenProvider)
    {
        Ensure.NotNull(accessTokenProvider, nameof(accessTokenProvider));

        _accessTokenProvider = accessTokenProvider;
    }


    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    public async Task ApplyPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        var token = await _accessTokenProvider
            .GetAccessTokenAsync(cancellationToken)
            .ConfigureAwait(false);

        request.ConfigureAuthorizationHeader(token);
    }
}
