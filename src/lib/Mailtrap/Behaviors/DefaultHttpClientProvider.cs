// -----------------------------------------------------------------------
// <copyright file="DefaultHttpClientProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Nito.AsyncEx;


namespace Mailtrap.Behaviors;


/// <summary>
/// Simplified <see cref="HttpClient" /> provider. <br/>
/// This particular implementation lazily initializes new <see cref="HttpClient"/> instance
/// with preconfigured headers and provides it in singleton fashion to consumers.
/// </summary>
internal class DefaultHttpClientProvider : IHttpClientProvider
{
    private readonly IHttpMessageHandlerFactory _httpMessageHandlerFactory;
    private readonly IHttpClientConfigurationPolicy _httpClientConfigurationPolicy;
    private readonly AsyncLazy<HttpClient> _client;


    internal DefaultHttpClientProvider(
        IHttpMessageHandlerFactory httpMessageHandlerFactory,
        IHttpClientConfigurationPolicy httpClientConfigurationPolicy)
    {
        ExceptionHelpers.ThrowIfNull(httpMessageHandlerFactory, nameof(httpMessageHandlerFactory));
        ExceptionHelpers.ThrowIfNull(httpClientConfigurationPolicy, nameof(httpClientConfigurationPolicy));

        _httpMessageHandlerFactory = httpMessageHandlerFactory;
        _httpClientConfigurationPolicy = httpClientConfigurationPolicy;
        _client = new AsyncLazy<HttpClient>(InitializeClient);
    }

    internal DefaultHttpClientProvider(string apiKey)
        : this(
              new DefaultHttpMessageHandlerFactory(),
              new DefaultHttpClientConfigurationPolicy(apiKey))
    { }


    public async Task<HttpClient> GetClientAsync(CancellationToken cancellationToken = default)
        => await _client.ConfigureAwait(false);


    protected virtual async Task<HttpClient> InitializeClient()
    {
        var resilienceHandler = _httpMessageHandlerFactory.GetHandler();

        var client = new HttpClient(resilienceHandler);

        await _httpClientConfigurationPolicy
            .ApplyPolicyAsync(client)
            .ConfigureAwait(false);

        return client;
    }
}
