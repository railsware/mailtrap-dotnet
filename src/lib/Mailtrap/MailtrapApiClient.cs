// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Mailtrap.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


namespace Mailtrap;


/// <inheritdoc cref="IMailtrapApiClient"/>
public sealed class MailtrapApiClient : IMailtrapApiClient, IDisposable
{
    private readonly MailtrapApiClientOptions _clientConfiguration;
    private readonly IHttpClientLifetimeFactory _httpClientLifetimeFactory;
    private readonly IHttpRequestMessageFactory _httpRequestMessageFactory;
    private readonly IHttpRequestContentFactory _httpRequestContentFactory;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly ServiceProvider? _serviceProvider;


    public MailtrapApiClient(MailtrapApiClientOptions configuration)
    {
        Ensure.NotNull(configuration, nameof(configuration));

        _clientConfiguration = configuration;

        _jsonSerializerOptions = _clientConfiguration.Serialization.ToJsonSerializerOptions();

        var serviceCollection = new ServiceCollection();

        serviceCollection.Configure<MailtrapApiClientOptions>(options => options = _clientConfiguration);

        serviceCollection.AddMailtrapClient();

        _serviceProvider = serviceCollection.BuildServiceProvider();

        _httpClientLifetimeFactory = _serviceProvider.GetRequiredService<IHttpClientLifetimeFactory>();
        _httpRequestMessageFactory = _serviceProvider.GetRequiredService<IHttpRequestMessageFactory>();
        _httpRequestContentFactory = _serviceProvider.GetRequiredService<IHttpRequestContentFactory>();
    }

    /// <summary>
    /// Shortcut constructor to be used with API key parameter, using default production endpoints and
    /// default <see cref="HttpClient"/> settings for all of them.
    /// </summary>
    /// <param name="apiKey">API authorization key</param>
    /// <exception cref="ArgumentNullException"/>
    public MailtrapApiClient(string apiKey)
        : this(MailtrapApiClientOptions.Default with
        {
            Authentication = new MailtrapApiClientAuthenticationOptions(apiKey)
        })
    { }

    public MailtrapApiClient(string apiKey, string emailHost, string bulkHost, string testHost)
        : this(MailtrapApiClientOptions.Default with
        {
            Authentication = new MailtrapApiClientAuthenticationOptions(apiKey),
            SendEndpoint = new MailtrapApiClientEndpointOptions(emailHost),
            BulkEndpoint = new MailtrapApiClientEndpointOptions(bulkHost),
            TestEndpoint = new MailtrapApiClientEndpointOptions(testHost)
        })
    { }

    public MailtrapApiClient(string apiKey, string apiHost)
        : this(apiKey, apiHost, apiHost, apiHost)
    { }

    /// <summary>
    /// Primary constructor for DI
    /// </summary>
    /// <param name="clientConfigurationProvider"></param>
    /// <param name="httpClientLifetimeFactory"></param>
    /// <param name="httpRequestMessageBuilder"></param>
    /// <param name="httpRequestContentBuilder"></param>
    public MailtrapApiClient(
        IMailtrapApiClientConfigurationProvider clientConfigurationProvider,
        IHttpClientLifetimeFactory httpClientLifetimeFactory,
        IHttpRequestMessageFactory httpRequestMessageBuilder,
        IHttpRequestContentFactory httpRequestContentBuilder)
    {
        Ensure.NotNull(clientConfigurationProvider, nameof(clientConfigurationProvider));
        Ensure.NotNull(httpClientLifetimeFactory, nameof(httpClientLifetimeFactory));
        Ensure.NotNull(httpRequestMessageBuilder, nameof(httpRequestMessageBuilder));
        Ensure.NotNull(httpRequestContentBuilder, nameof(httpRequestContentBuilder));

        _clientConfiguration = clientConfigurationProvider.Configuration;

        _jsonSerializerOptions = _clientConfiguration.Serialization.ToJsonSerializerOptions();

        _httpClientLifetimeFactory = httpClientLifetimeFactory;
        _httpRequestMessageFactory = httpRequestMessageBuilder;
        _httpRequestContentFactory = httpRequestContentBuilder;
    }


    public void Dispose() => _serviceProvider?.Dispose();


    /// <inheritdoc />
    public async Task<SendEmailApiResponse?> SendAsync(SendEmailApiRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        var validationResult = await SendEmailApiRequestValidator.Instance
            .ValidateAsync(request, cancellationToken)
            .ConfigureAwait(false);

        if (!validationResult.IsValid)
        {
            throw new ArgumentException($"Invalid request data:\n{validationResult}", nameof(request));
        }

        var jsonContent = JsonSerializer.Serialize(request, _jsonSerializerOptions);

        using var httpContent = await _httpRequestContentFactory
            .CreateAsync(jsonContent)
            .ConfigureAwait(false);

        // We are relying on pre-configured HttpClient.BaseAddress, passing only relative URL into request
        var uri = string
            .Join("/", ApiUrlSegments.ApiRootSegment, ApiUrlSegments.SendEmailSegment)
            .ToRelativeUri();

        using var httpRequest = await _httpRequestMessageFactory
            .CreateAsync(HttpMethod.Post, uri, httpContent)
            .ConfigureAwait(false);

        // We are using lifetime wrapper for HttpClient, so it's totally OK to dispose it here.
        using var client = await _httpClientLifetimeFactory
            .GetClientAsync(_clientConfiguration.SendEndpoint, cancellationToken)
            .ConfigureAwait(false);

        using var httpResponse = await client.HttpClient
            .SendAsync(httpRequest, cancellationToken)
            .ConfigureAwait(false);

        // For now just throwing standard HttpRequestException for anything except success.
        // More robust exception handling with custom Exception types can be added later on.
        httpResponse.EnsureSuccessStatusCode();

        var body = await httpResponse.Content
            .ReadAsStringAsync()
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<SendEmailApiResponse>(body, _jsonSerializerOptions);
    }
}
