// -----------------------------------------------------------------------
// <copyright file="HttpClientLifetimeFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Lifetime;


internal sealed class HttpClientLifetimeFactory : IHttpClientLifetimeFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpClientConfigurationPolicy _httpClientConfigurationPolicy;


    internal HttpClientLifetimeFactory(
        IHttpClientFactory httpClientFactory,
        IHttpClientConfigurationPolicy httpClientConfigurationPolicy)
    {
        Ensure.NotNull(httpClientFactory, nameof(httpClientFactory));
        Ensure.NotNull(httpClientConfigurationPolicy, nameof(httpClientConfigurationPolicy));

        _httpClientFactory = httpClientFactory;
        _httpClientConfigurationPolicy = httpClientConfigurationPolicy;
    }


    public async Task<IHttpClientLifetimeAdapter> GetClientAsync(MailtrapApiClientEndpointOptions endpointConfiguration, CancellationToken cancellationToken = default)
    {
        var clientName = endpointConfiguration.HttpClientName;
        var defaultBaseAddress = endpointConfiguration.BaseUrl;

#pragma warning disable IDE0055
        var httpClient = string.IsNullOrEmpty(clientName)
            ? _httpClientFactory
                .CreateClient()
                // overriding any pre-configured BaseAddress in case of using default HttpClient configuration
                .WithBaseAddress(defaultBaseAddress, true)
            : _httpClientFactory
                .CreateClient(clientName!)
                // for named clients expecting BaseAddress to be properly pre-configured with HttpClientBuilder,
                // thus falling back to default value only if it is missing
                .WithBaseAddress(defaultBaseAddress);
#pragma warning restore IDE0055

        await _httpClientConfigurationPolicy
            .ApplyPolicyAsync(httpClient, cancellationToken)
            .ConfigureAwait(false);

        return new TransientHttpClientLifetimeAdapter(httpClient);
    }
}
