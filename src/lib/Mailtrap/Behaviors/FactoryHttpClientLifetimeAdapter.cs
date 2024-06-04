// -----------------------------------------------------------------------
// <copyright file="FactoryHttpClientLifetimeAdapter.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Behaviors;


internal class FactoryHttpClientLifetimeAdapter : IHttpClientLifetimeAdapter
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly Lazy<HttpClient> _httpClient;


    public FactoryHttpClientLifetimeAdapter(IHttpClientFactory httpClientFactory, string clientName)
    {
        _httpClientFactory = httpClientFactory;
        _httpClient = new Lazy<HttpClient>(() =>
        {
            return _httpClientFactory
                .CreateClient(clientName)
                .ConfigureAcceptHeader();
        });
    }


    public void Dispose() => _httpClient.Value.Dispose();

    public HttpClient GetHttpClient() => _httpClient.Value;
}
