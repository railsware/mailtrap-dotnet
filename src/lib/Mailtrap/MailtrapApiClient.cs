// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap;


/// <inheritdoc cref="IMailtrapApiClient"/>
public class MailtrapApiClient : IMailtrapApiClient
{
    private readonly IHttpClientLifetimeFactory _httpClientLifetimeFactory;
    private readonly IHttpRequestMessageBuilder _httpRequestMessageBuilder;
    private readonly IHttpRequestContentBuilder _httpRequestContentBuilder;
    private readonly IJsonSerializerFacade _jsonSerializer;
    private readonly MailtrapApiClientOptions _clientConfiguration;

    /// <summary>
    /// Shortcut constructor to be used with base URL and API key parameters
    /// </summary>
    /// <param name="apiHost">Root API URL, e.g. https://send.api.mailtrap.io/. <b>Should contain trailing slash.</b></param>
    /// <param name="apiKey">API authorization key</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    public MailtrapApiClient(string apiHost, string apiKey) :
    { }

    /// <summary>
    /// Shortcut constructor to be used with API key parameter
    /// </summary>
    /// <param name="apiKey">API authorization key</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    public MailtrapApiClient(string apiKey)
    { }


    public MailtrapApiClient(
        IMailtrapApiClientConfigurationProvider clientConfigurationProvider,
        IHttpClientLifetimeFactory httpClientLifetimeFactory,
        IHttpRequestMessageBuilder httpRequestMessageBuilder,
        IHttpRequestContentBuilder httpRequestContentBuilder,
        IJsonSerializerFacade jsonSerializer)
    {
        ExceptionHelpers.ThrowIfNull(clientConfigurationProvider, nameof(clientConfigurationProvider));
        ExceptionHelpers.ThrowIfNull(httpClientLifetimeFactory, nameof(httpClientLifetimeFactory));
        ExceptionHelpers.ThrowIfNull(httpRequestMessageBuilder, nameof(httpRequestMessageBuilder));
        ExceptionHelpers.ThrowIfNull(httpRequestContentBuilder, nameof(httpRequestContentBuilder));
        ExceptionHelpers.ThrowIfNull(jsonSerializer, nameof(jsonSerializer));

        _clientConfiguration = clientConfigurationProvider.Configuration;
        _httpClientLifetimeFactory = httpClientLifetimeFactory;
        _httpRequestMessageBuilder = httpRequestMessageBuilder;
        _httpRequestContentBuilder = httpRequestContentBuilder;
        _jsonSerializer = jsonSerializer;
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
        ExceptionHelpers.ThrowIfNull(request, nameof(request));

        request.Validate();

        var jsonContent = _jsonSerializer.Serialize(request);

        using var httpContent = await _httpRequestContentBuilder
            .BuildAsync(jsonContent)
            .ConfigureAwait(false);

        // We are relying on pre-configured HttpClient.BaseAddress, passing only relative URL into request
        var uri = string
            .Join("/", ApiUrlSegments.ApiRootSegment, ApiUrlSegments.SendEmailSegment)
            .ToRelativeUri();

        using var httpRequest = await _httpRequestMessageBuilder
            .BuildAsync(HttpMethod.Post, uri, httpContent)
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

        return _jsonSerializer.Deserialize<EmailSendApiResponse>(body);
    }
}
