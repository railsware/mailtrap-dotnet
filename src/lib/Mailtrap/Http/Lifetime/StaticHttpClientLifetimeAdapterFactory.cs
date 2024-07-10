// -----------------------------------------------------------------------
// <copyright file="StaticHttpClientLifetimeAdapterFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Lifetime;


/// <summary>
/// Implementation of <see cref="IHttpClientLifetimeAdapterFactory"/> that produces
/// <see cref="StaticHttpClientLifetimeAdapter"/> instances,
/// by wrapping external <see cref="HttpClient"/>, provided in constructor.
/// </summary>
internal sealed class StaticHttpClientLifetimeAdapterFactory : IHttpClientLifetimeAdapterFactory
{
    private readonly HttpClient _httpClient;


    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="httpClient">External <see cref="HttpClient"/> instance to wrap.</param>
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="httpClient"/> is <see langword="null"/>.
    /// </exception>
    public StaticHttpClientLifetimeAdapterFactory(HttpClient httpClient)
    {
        Ensure.NotNull(httpClient, nameof(httpClient));

        _httpClient = httpClient;
    }


    /// <summary>
    /// Returns new instance of <see cref="StaticHttpClientLifetimeAdapter"/>,
    /// by wrapping external <see cref="HttpClient"/> instance, provided in constructor.
    /// </summary>
    public Task<IHttpClientLifetimeAdapter> CreateAsync(MailtrapClientEndpointOptions _1, CancellationToken _2 = default)
    {
        return Task.FromResult<IHttpClientLifetimeAdapter>(new StaticHttpClientLifetimeAdapter(_httpClient));
    }
}
