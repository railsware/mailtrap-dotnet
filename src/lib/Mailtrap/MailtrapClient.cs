// -----------------------------------------------------------------------
// <copyright file="MailtrapClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap;


/// <inheritdoc cref="IMailtrapClient"/>
public sealed class MailtrapClient : IMailtrapClient, IDisposable
{
    private readonly MailtrapClientOptions _clientConfiguration;
    private readonly IHttpClientLifetimeAdapterFactory _httpClientLifetimeFactory;
    private readonly IHttpRequestMessageFactory _httpRequestMessageFactory;
    private readonly IHttpRequestContentFactory _httpRequestContentFactory;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly ServiceProvider? _serviceProvider;


    /// <summary>
    /// Constructor for DI use.
    /// </summary>
    /// <param name="clientConfigurationProvider"></param>
    /// <param name="httpClientLifetimeFactory"></param>
    /// <param name="httpRequestMessageFactory"></param>
    /// <param name="httpRequestContentFactory"></param>
    /// <exception cref="ArgumentNullException">
    /// When any of the parameters provided is <see langword="null"/>.
    /// </exception>
    public MailtrapClient(
        IMailtrapClientConfigurationProvider clientConfigurationProvider,
        IHttpClientLifetimeAdapterFactory httpClientLifetimeFactory,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpRequestContentFactory httpRequestContentFactory)
    {
        Ensure.NotNull(clientConfigurationProvider, nameof(clientConfigurationProvider));
        Ensure.NotNull(httpClientLifetimeFactory, nameof(httpClientLifetimeFactory));
        Ensure.NotNull(httpRequestMessageFactory, nameof(httpRequestMessageFactory));
        Ensure.NotNull(httpRequestContentFactory, nameof(httpRequestContentFactory));

        _clientConfiguration = clientConfigurationProvider.Configuration;

        _jsonSerializerOptions = _clientConfiguration.Serialization.ToJsonSerializerOptions();

        _httpClientLifetimeFactory = httpClientLifetimeFactory;
        _httpRequestMessageFactory = httpRequestMessageFactory;
        _httpRequestContentFactory = httpRequestContentFactory;
    }

    /// <summary>
    /// Constructor to create a new instance of <see cref="MailtrapClient"/> 
    /// with provided <paramref name="configuration"/> section
    /// and optional <see cref="HttpClient"/> configuration delegate.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="configureHttpClient"></param>
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="configuration"/> is <see langword="null"/>.
    /// </exception>
    public MailtrapClient(IConfiguration configuration, Action<IHttpClientBuilder>? configureHttpClient = null)
    {
        Ensure.NotNull(configuration, nameof(configuration));

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddMailtrapClient(configuration, configureHttpClient);

        _serviceProvider = serviceCollection.BuildServiceProvider();

        _clientConfiguration = _serviceProvider.GetRequiredService<IMailtrapClientConfigurationProvider>().Configuration;

        _jsonSerializerOptions = _clientConfiguration.Serialization.ToJsonSerializerOptions();

        _httpClientLifetimeFactory = _serviceProvider.GetRequiredService<IHttpClientLifetimeAdapterFactory>();
        _httpRequestMessageFactory = _serviceProvider.GetRequiredService<IHttpRequestMessageFactory>();
        _httpRequestContentFactory = _serviceProvider.GetRequiredService<IHttpRequestContentFactory>();
    }

    /// <summary>
    /// Constructor to create a new instance of <see cref="MailtrapClient"/> 
    /// using provided <paramref name="configuration"/> section
    /// and preconfigured <see cref="HttpClient"/> instance.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="httpClient"></param>
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="configuration"/> or <paramref name="httpClient"/> is <see langword="null"/>.
    /// </exception>
    public MailtrapClient(IConfiguration configuration, HttpClient httpClient)
    {
        Ensure.NotNull(configuration, nameof(configuration));
        Ensure.NotNull(httpClient, nameof(httpClient));

        var serviceCollection = new ServiceCollection();

        serviceCollection.Configure<MailtrapClientOptions>(configuration);
        serviceCollection.AddMailtrapServices<StaticHttpClientLifetimeAdapterFactory>();
        serviceCollection.AddSingleton(httpClient);

        _serviceProvider = serviceCollection.BuildServiceProvider();

        _clientConfiguration = _serviceProvider.GetRequiredService<IMailtrapClientConfigurationProvider>().Configuration;

        _jsonSerializerOptions = _clientConfiguration.Serialization.ToJsonSerializerOptions();

        _httpClientLifetimeFactory = _serviceProvider.GetRequiredService<IHttpClientLifetimeAdapterFactory>();
        _httpRequestMessageFactory = _serviceProvider.GetRequiredService<IHttpRequestMessageFactory>();
        _httpRequestContentFactory = _serviceProvider.GetRequiredService<IHttpRequestContentFactory>();
    }

    /// <summary>
    /// Constructor to create a new instance of <see cref="MailtrapClient"/> 
    /// with provided <paramref name="configuration"/>
    /// and optional <see cref="HttpClient"/> configuration delegate.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="configure"></param>
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="configuration"/> is <see langword="null"/>.
    /// </exception>
    public MailtrapClient(MailtrapClientOptions configuration, Action<IHttpClientBuilder>? configure = null)
    {
        Ensure.NotNull(configuration, nameof(configuration));

        _clientConfiguration = configuration;

        _jsonSerializerOptions = _clientConfiguration.Serialization.ToJsonSerializerOptions();

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddMailtrapClient(_clientConfiguration, configure);

        _serviceProvider = serviceCollection.BuildServiceProvider();

        _httpClientLifetimeFactory = _serviceProvider.GetRequiredService<IHttpClientLifetimeAdapterFactory>();
        _httpRequestMessageFactory = _serviceProvider.GetRequiredService<IHttpRequestMessageFactory>();
        _httpRequestContentFactory = _serviceProvider.GetRequiredService<IHttpRequestContentFactory>();
    }

    /// <summary>
    /// Constructor to create a new instance of <see cref="MailtrapClient"/> 
    /// using provided <paramref name="configuration"/>
    /// and preconfigured <see cref="HttpClient"/> instance.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="httpClient"></param>
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="configuration"/> or <paramref name="httpClient"/> is <see langword="null"/>.
    /// </exception>
    public MailtrapClient(MailtrapClientOptions configuration, HttpClient httpClient)
    {
        Ensure.NotNull(configuration, nameof(configuration));
        Ensure.NotNull(httpClient, nameof(httpClient));

        _clientConfiguration = configuration;

        _jsonSerializerOptions = _clientConfiguration.Serialization.ToJsonSerializerOptions();

        var serviceCollection = new ServiceCollection();

        serviceCollection.Configure<MailtrapClientOptions>(options => options = _clientConfiguration);

        serviceCollection.AddMailtrapServices<StaticHttpClientLifetimeAdapterFactory>();

        serviceCollection.AddSingleton(httpClient);

        _serviceProvider = serviceCollection.BuildServiceProvider();

        _httpClientLifetimeFactory = _serviceProvider.GetRequiredService<IHttpClientLifetimeAdapterFactory>();
        _httpRequestMessageFactory = _serviceProvider.GetRequiredService<IHttpRequestMessageFactory>();
        _httpRequestContentFactory = _serviceProvider.GetRequiredService<IHttpRequestContentFactory>();
    }

    /// <summary>
    /// Shortcut constructor to create a new instance of <see cref="MailtrapClient"/> 
    /// using provided <paramref name="apiKey"/>
    /// and optional <see cref="HttpClient"/> configuration delegate.
    /// </summary>
    /// <param name="apiKey"></param>
    /// <param name="configure"></param>
    public MailtrapClient(
        string apiKey,
        Action<IHttpClientBuilder>? configure = null)
        : this(new MailtrapClientOptions(apiKey), configure)
    { }

    /// <summary>
    /// Shortcut constructor to create a new instance of <see cref="MailtrapClient"/>
    /// using provided <paramref name="apiKey"/>
    /// and preconfigured <see cref="HttpClient"/> instance.
    /// </summary>
    /// <param name="apiKey"></param>
    /// <param name="httpClient"></param>
    public MailtrapClient(
        string apiKey,
        HttpClient httpClient)
        : this(new MailtrapClientOptions(apiKey), httpClient)
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
            .CreateAsync(jsonContent, cancellationToken)
            .ConfigureAwait(false);

        // We cannot rely on pre-configured HttpClient.BaseAddress,
        // since it can be external instance with wrong URI configured.
        var sendUrl = _clientConfiguration.SendEndpoint.BaseUrl.Append(UrlSegments.ApiRootSegment, UrlSegments.SendEmailSegment);

        using var httpRequest = await _httpRequestMessageFactory
            .CreateAsync(HttpMethod.Post, sendUrl, httpContent, cancellationToken)
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
