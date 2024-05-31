// -----------------------------------------------------------------------
// <copyright file="DefaultHttpClientConfigurationPolicy.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Behaviors;


internal class DefaultHttpClientConfigurationPolicy : IHttpClientConfigurationPolicy
{
    private readonly IAccessTokenProvider _accessTokenProvider;


    internal DefaultHttpClientConfigurationPolicy(IAccessTokenProvider accessTokenProvider)
    {
        ExceptionHelpers.ThrowIfNull(accessTokenProvider, nameof(accessTokenProvider));

        _accessTokenProvider = accessTokenProvider;
    }

    internal DefaultHttpClientConfigurationPolicy(string apiKey)
        : this(new StaticAccessTokenProvider(apiKey)) { }


    public virtual async Task ApplyPolicyAsync(HttpClient httpClient, CancellationToken cancellationToken = default)
    {
        // Preconfiguring default values for headers: Accept and Authentication.
        httpClient.ConfigureAcceptHeader();

        var token = await _accessTokenProvider
            .GetAccessTokenAsync(cancellationToken)
            .ConfigureAwait(false);

        httpClient.ConfigureApiAuthenticationHeader(token);
    }
}
