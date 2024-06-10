// -----------------------------------------------------------------------
// <copyright file="HttpRequestMessageConfigurationPolicy.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Http.Request;


internal sealed class HttpRequestMessageConfigurationPolicy : IHttpRequestMessageConfigurationPolicy
{
    private readonly IHttpRequestMessageAuthenticationProvider _authenticationProvider;


    public HttpRequestMessageConfigurationPolicy(IHttpRequestMessageAuthenticationProvider authenticationProvider)
    {
        Ensure.NotNull(authenticationProvider, nameof(authenticationProvider));

        _authenticationProvider = authenticationProvider;
    }

    public async Task ApplyPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        await _authenticationProvider
            .AuthenticateAsync(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
