// -----------------------------------------------------------------------
// <copyright file="MailtrapClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Mailtrap.Extensions.DependencyInjection;


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
    /// Constructor for DI use
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
    /// Constructor to create a new instance of <see cref="MailtrapClient"/> with provided <paramref name="configuration"/>
    /// and optional <see cref="HttpClient"/> configuration delegate.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="configure"></param>
    public MailtrapClient(MailtrapClientOptions configuration, Action<IHttpClientBuilder>? configure = null)
    {
        Ensure.NotNull(configuration, nameof(configuration));

        _clientConfiguration = configuration;

        _jsonSerializerOptions = _clientConfiguration.Serialization.ToJsonSerializerOptions();

        var serviceCollection = new ServiceCollection();

        serviceCollection.ConfigureMailtrapClient(options => options = _clientConfiguration);

        serviceCollection.AddMailtrapClient(configure);

        _serviceProvider = serviceCollection.BuildServiceProvider();

        _httpClientLifetimeFactory = _serviceProvider.GetRequiredService<IHttpClientLifetimeFactory>();
        _httpRequestMessageFactory = _serviceProvider.GetRequiredService<IHttpRequestMessageFactory>();
        _httpRequestContentFactory = _serviceProvider.GetRequiredService<IHttpRequestContentFactory>();
    }

    /// <summary>
    /// Constructor to create a new instance of <see cref="MailtrapClient"/> using provided <paramref name="configuration"/>
    /// and preconfigured <see cref="HttpClient"/> instance.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="httpClient"></param>
    public MailtrapClient(MailtrapClientOptions configuration, HttpClient httpClient)
    {
        Ensure.NotNull(configuration, nameof(configuration));
        Ensure.NotNull(httpClient, nameof(httpClient));

        _clientConfiguration = configuration;

        _jsonSerializerOptions = _clientConfiguration.Serialization.ToJsonSerializerOptions();

        var serviceCollection = new ServiceCollection();

        serviceCollection.ConfigureMailtrapClient(options => options = _clientConfiguration);

        serviceCollection.AddMailtrapServices<StaticHttpClientLifetimeFactory>();

        serviceCollection.AddSingleton(httpClient);

        _serviceProvider = serviceCollection.BuildServiceProvider();

        _httpClientLifetimeFactory = _serviceProvider.GetRequiredService<IHttpClientLifetimeFactory>();
        _httpRequestMessageFactory = _serviceProvider.GetRequiredService<IHttpRequestMessageFactory>();
        _httpRequestContentFactory = _serviceProvider.GetRequiredService<IHttpRequestContentFactory>();
    }

    /// <summary>
    /// Constructor to create a new instance of <see cref="MailtrapClient"/> using provided <paramref name="apiKey"/>
    /// and optional <see cref="HttpClient"/> configuration delegate.
    /// </summary>
    /// <param name="apiKey"></param>
    /// <param name="configure"></param>
    /// <param name="emailHost"></param>
    /// <param name="bulkHost"></param>
    /// <param name="testHost"></param>
    public MailtrapClient(
        string apiKey,
        Action<IHttpClientBuilder>? configure = null,
        string? emailHost = null,
        string? bulkHost = null,
        string? testHost = null)
        : this(MailtrapClientOptions.Default with
        {
            Authentication = new MailtrapClientAuthenticationOptions(apiKey),
            SendEndpoint = new MailtrapClientEndpointOptions(emailHost ?? Endpoints.SendDefaultUrl),
            BulkEndpoint = new MailtrapClientEndpointOptions(bulkHost ?? Endpoints.BulkDefaultUrl),
            TestEndpoint = new MailtrapClientEndpointOptions(testHost ?? Endpoints.TestDefaultUrl)
        }, configure)
    { }

    /// <summary>
    /// Constructor to create a new instance of <see cref="MailtrapClient"/> using provided <paramref name="apiKey"/>
    /// and preconfigured <see cref="HttpClient"/> instance.
    /// </summary>
    /// <param name="apiKey"></param>
    /// <param name="httpClient"></param>
    /// <param name="emailHost"></param>
    /// <param name="bulkHost"></param>
    /// <param name="testHost"></param>
    public MailtrapClient(
        string apiKey,
        HttpClient httpClient,
        string? emailHost = null,
        string? bulkHost = null,
        string? testHost = null)
        : this(MailtrapClientOptions.Default with
        {
            Authentication = new MailtrapClientAuthenticationOptions(apiKey),
            SendEndpoint = new MailtrapClientEndpointOptions(emailHost ?? Endpoints.SendDefaultUrl),
            BulkEndpoint = new MailtrapClientEndpointOptions(bulkHost ?? Endpoints.BulkDefaultUrl),
            TestEndpoint = new MailtrapClientEndpointOptions(testHost ?? Endpoints.TestDefaultUrl)
        }, httpClient)
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

        // We cannot rely on pre-configured HttpClient.BaseAddress, since it can be external instance with unknown BaseUrl.
        var uri = string
            .Join("/", _clientConfiguration.SendEndpoint.BaseUrl.ToString(), UrlSegments.ApiRootSegment, UrlSegments.SendEmailSegment)
            .ToAbsoluteUri();

        using var httpRequest = await _httpRequestMessageFactory
            .CreateAsync(HttpMethod.Post, uri, httpContent, cancellationToken)
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
