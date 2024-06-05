// -----------------------------------------------------------------------
// <copyright file="HttpRequestMessageConfigurationPolicy.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http;


internal sealed class HttpRequestMessageConfigurationPolicy : IHttpRequestMessageConfigurationPolicy
{
    private readonly IHttpRequestMessageAuthenticationProvider _authenticationProvider;


    internal HttpRequestMessageConfigurationPolicy(IHttpRequestMessageAuthenticationProvider authenticationProvider)
    {
        ExceptionHelpers.ThrowIfNull(authenticationProvider, nameof(authenticationProvider));

        _authenticationProvider = authenticationProvider;
    }

    public async Task ApplyPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        request.ConfigureAcceptHeader();

        await _authenticationProvider
            .AuthenticateAsync(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
