// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Mailtrap.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


namespace Mailtrap;


/// <inheritdoc cref="IMailtrapApiClient"/>
public class MailtrapApiClient : IMailtrapApiClient
{
    private readonly MailtrapApiClientOptions _clientConfiguration;
    private readonly IHttpClientLifetimeFactory _httpClientLifetimeFactory;
    private readonly IHttpRequestMessageFactory _httpRequestMessageBuilder;
    private readonly IHttpRequestContentFactory _httpRequestContentBuilder;
    private readonly JsonSerializerOptions _jsonSerializerOptions;


    /// <summary>
    /// Shortcut constructor to be used with API key parameter, using default production endpoints and
    /// default <see cref="HttpClient"/> settings for all of them.
    /// </summary>
    /// <param name="apiKey">API authorization key</param>
    /// <exception cref="ArgumentNullException"/>
    public MailtrapApiClient(string apiKey)
    {
        Ensure.NotNullOrEmpty(apiKey, nameof(apiKey));

        _clientConfiguration = MailtrapApiClientOptions.Default with
        {
            Authentication = new MailtrapApiClientAuthenticationOptions
            {
                ApiToken = apiKey
            }
        };

        _jsonSerializerOptions = _clientConfiguration.Serialization.ToJsonSerializerOptions();


        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddOptions<MailtrapApiClientOptions>()
            .Configure(options =>
            {
                options = _clientConfiguration;
            });

        serviceCollection.AddMailtrapClient();
        var serviceProvider = serviceCollection.BuildServiceProvider();

        _httpClientLifetimeFactory = serviceProvider.GetRequiredService<IHttpClientLifetimeFactory>();
        _httpRequestMessageBuilder = serviceProvider.GetRequiredService<IHttpRequestMessageFactory>();
        _httpRequestContentBuilder = serviceProvider.GetRequiredService<IHttpRequestContentFactory>();
    }

    /// <summary>
    /// Shortcut constructor to be used with base URL and API key parameters
    /// </summary>
    /// <param name="apiHost">Root API URL, e.g. https://send.api.mailtrap.io/. <b>Should contain trailing slash.</b></param>
    /// <param name="apiKey">API authorization key</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    //public MailtrapApiClient(string apiHost, string apiKey)
    //{ }


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
        _httpRequestMessageBuilder = httpRequestMessageBuilder;
        _httpRequestContentBuilder = httpRequestContentBuilder;
    }


    /// <inheritdoc />
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ValidationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="TaskCanceledException"/>
    /// <exception cref="OperationCanceledException"/>
    /// <exception cref="JsonException"/>
    public async Task<EmailSendApiResponse?> SendAsync(EmailSendApiRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        request.Validate();

        var jsonContent = JsonSerializer.Serialize(request, _jsonSerializerOptions);

        using var httpContent = await _httpRequestContentBuilder
            .CreateAsync(jsonContent)
            .ConfigureAwait(false);

        // We are relying on pre-configured HttpClient.BaseAddress, passing only relative URL into request
        var uri = string
            .Join("/", ApiUrlSegments.ApiRootSegment, ApiUrlSegments.SendEmailSegment)
            .ToRelativeUri();

        using var httpRequest = await _httpRequestMessageBuilder
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

        return JsonSerializer.Deserialize<EmailSendApiResponse>(body, _jsonSerializerOptions);
    }
}
