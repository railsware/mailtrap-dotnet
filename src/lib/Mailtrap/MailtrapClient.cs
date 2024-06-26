// -----------------------------------------------------------------------
// <copyright file="MailtrapClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Mailtrap.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;


namespace Mailtrap;


/// <inheritdoc cref="IMailtrapClient"/>
public sealed class MailtrapClient : IMailtrapClient, IDisposable
{
    private readonly MailtrapClientOptions _clientConfiguration;
    private readonly IHttpClientLifetimeFactory _httpClientLifetimeFactory;
    private readonly IHttpRequestMessageFactory _httpRequestMessageFactory;
    private readonly IHttpRequestContentFactory _httpRequestContentFactory;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly ServiceProvider? _serviceProvider;



    /// <summary>
    /// Primary constructor for DI
    /// </summary>
    /// <param name="clientConfigurationProvider"></param>
    /// <param name="httpClientLifetimeFactory"></param>
    /// <param name="httpRequestMessageBuilder"></param>
    /// <param name="httpRequestContentBuilder"></param>
    public MailtrapClient(
        IMailtrapClientConfigurationProvider clientConfigurationProvider,
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

    /// <summary>
    /// Constructor to create a new instance of <see cref="MailtrapClient"/> with provided configuration.
    /// </summary>
    /// <param name="configuration"></param>
    public MailtrapClient(MailtrapClientOptions configuration)
    {
        Ensure.NotNull(configuration, nameof(configuration));

        _clientConfiguration = configuration;

        _jsonSerializerOptions = _clientConfiguration.Serialization.ToJsonSerializerOptions();

        var serviceCollection = new ServiceCollection();

        serviceCollection.Configure<MailtrapClientOptions>(options => options = _clientConfiguration);

        serviceCollection.AddMailtrapClient();

        _serviceProvider = serviceCollection.BuildServiceProvider();

        _httpClientLifetimeFactory = _serviceProvider.GetRequiredService<IHttpClientLifetimeFactory>();
        _httpRequestMessageFactory = _serviceProvider.GetRequiredService<IHttpRequestMessageFactory>();
        _httpRequestContentFactory = _serviceProvider.GetRequiredService<IHttpRequestContentFactory>();
    }

    /// <summary>
    /// Constructor to create a new instance of <see cref="MailtrapClient"/> using provided <see cref="HttpClient"/> instance.
    /// </summary>
    /// <param name="apiKey"></param>
    /// <param name="httpClient"></param>
    public MailtrapClient(string apiKey, HttpClient httpClient)
    {
        Ensure.NotNullOrEmpty(apiKey, nameof(apiKey));
        Ensure.NotNull(httpClient, nameof(httpClient));

        _clientConfiguration = MailtrapClientOptions.Default with
        {
            Authentication = new MailtrapClientAuthenticationOptions(apiKey)
        };

        _jsonSerializerOptions = _clientConfiguration.Serialization.ToJsonSerializerOptions();

        var serviceCollection = new ServiceCollection();

        serviceCollection.Configure<MailtrapClientOptions>(options => options = _clientConfiguration);

        serviceCollection.AddMailtrapClient();

        serviceCollection.TryAddSingleton<IHttpClientLifetimeFactory, StaticHttpClientLifetimeFactory>();

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
    public MailtrapClient(string apiKey)
        : this(MailtrapClientOptions.Default with
        {
            Authentication = new MailtrapClientAuthenticationOptions(apiKey)
        })
    { }

    /// <summary>
    /// Shortcut constructor with different hosts for each endpoint.
    /// </summary>
    /// <param name="apiKey"></param>
    /// <param name="emailHost"></param>
    /// <param name="bulkHost"></param>
    /// <param name="testHost"></param>
    public MailtrapClient(string apiKey, string emailHost, string bulkHost, string testHost)
        : this(MailtrapClientOptions.Default with
        {
            Authentication = new MailtrapClientAuthenticationOptions(apiKey),
            SendEndpoint = new MailtrapClientEndpointOptions(emailHost),
            BulkEndpoint = new MailtrapClientEndpointOptions(bulkHost),
            TestEndpoint = new MailtrapClientEndpointOptions(testHost)
        })
    { }

    /// <summary>
    /// Shortcut constructor, using the same host for all endpoints.
    /// </summary>
    /// <param name="apiKey"></param>
    /// <param name="apiHost"></param>
    public MailtrapClient(string apiKey, string apiHost)
        : this(apiKey, apiHost, apiHost, apiHost)
    { }


    /// <summary>
    /// Disposes internal DI container used to create transient <see cref="HttpClient"/> instances properly.
    /// </summary>
    public void Dispose() => _serviceProvider?.Dispose();


    /// <inheritdoc />
    public async Task<SendEmailResponse?> SendAsync(SendEmailRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        var validationResult = await SendEmailRequestValidator.Instance
            .ValidateAsync(request, cancellationToken)
            .ConfigureAwait(false);

        if (!validationResult.IsValid)
        {
            throw new ArgumentException($"Invalid request data:\n{validationResult.ToString("\n")}", nameof(request));
        }

        var jsonContent = JsonSerializer.Serialize(request, _jsonSerializerOptions);

        using var httpContent = await _httpRequestContentFactory
            .CreateAsync(jsonContent)
            .ConfigureAwait(false);

        // We cannot rely on pre-configured HttpClient.BaseAddress, since it can be external instance.
        var uri = string
            .Join("/", _clientConfiguration.SendEndpoint.BaseUrl.ToString(), UrlSegments.ApiRootSegment, UrlSegments.SendEmailSegment)
            .ToAbsoluteUri();

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

        return JsonSerializer.Deserialize<SendEmailResponse>(body, _jsonSerializerOptions);
    }
}
