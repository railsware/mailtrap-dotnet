// -----------------------------------------------------------------------
// <copyright file="TransientHttpClientLifetimeAdapterFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Lifetime;


/// <summary>
/// Implementation of <see cref="IHttpClientLifetimeAdapterFactory"/> that produces
/// <see cref="TransientHttpClientLifetimeAdapter"/> instances,
/// wrapping transient <see cref="HttpClient"/>, obtained from <see cref="IHttpClientFactory"/>.
/// </summary>
internal sealed class TransientHttpClientLifetimeAdapterFactory : IHttpClientLifetimeAdapterFactory
{
    private readonly IHttpClientFactory _httpClientFactory;


    public TransientHttpClientLifetimeAdapterFactory(IHttpClientFactory httpClientFactory)
    {
        Ensure.NotNull(httpClientFactory, nameof(httpClientFactory));

        _httpClientFactory = httpClientFactory;
    }


    /// <summary>
    /// Returns new instance of <see cref="TransientHttpClientLifetimeAdapter"/>,
    /// by wrapping transient <see cref="HttpClient"/> instance, obtained from <see cref="IHttpClientFactory"/>.
    /// </summary>
    public Task<IHttpClientLifetimeAdapter> GetClientAsync(MailtrapClientEndpointOptions endpointConfiguration, CancellationToken _ = default)
    {
        Ensure.NotNull(endpointConfiguration, nameof(endpointConfiguration));

        var httpClient = _httpClientFactory.CreateClient(endpointConfiguration.HttpClientName ?? Options.DefaultName);

        return Task.FromResult<IHttpClientLifetimeAdapter>(new TransientHttpClientLifetimeAdapter(httpClient));
    }
}
