// -----------------------------------------------------------------------
// <copyright file="StaticHttpClientLifetimeFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Lifetime;


internal sealed class StaticHttpClientLifetimeFactory : IHttpClientLifetimeFactory
{
    private readonly HttpClient _httpClient;


    internal StaticHttpClientLifetimeFactory(HttpClient httpClient)
    {
        Ensure.NotNull(httpClient, nameof(httpClient));

        _httpClient = httpClient;
    }


    public Task<IHttpClientLifetimeAdapter> GetClientAsync(MailtrapClientEndpointOptions _, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IHttpClientLifetimeAdapter>(new StaticHttpClientLifetimeAdapter(_httpClient));
    }
}
