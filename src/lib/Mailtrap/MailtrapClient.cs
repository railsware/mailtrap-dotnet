// -----------------------------------------------------------------------
// <copyright file="MailtrapClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap;


/// <summary>
/// <see cref="IMailtrapClient"/> implementation.
/// </summary>
/// <remarks>
/// Implementation is lightweight, utilising unit-of-work pattern under the hood,
/// so can be used as transient.<br />
/// Meanwhile, it isn't thread safe, so singleton usage is not recommended,
/// especially in multi-threaded environments.
/// </remarks>
public class MailtrapClient : IMailtrapClient
{
    private readonly MailtrapClientOptions _clientConfiguration;
    private readonly IHttpClientLifetimeAdapterFactory _httpClientLifetimeFactory;
    private readonly IHttpRequestMessageFactory _httpRequestMessageFactory;
    private readonly IHttpRequestContentFactory _httpRequestContentFactory;
    private readonly JsonSerializerOptions _jsonSerializerOptions;


    /// <summary>
    /// Default instance constructor.
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


    /// <inheritdoc />
    public async Task<SendEmailResponse?> SendAsync(
        SendEmailRequest request,
        Endpoint endpoint = Endpoint.Send,
        int? inboxId = default,
        CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        var validationResult = await SendEmailRequestValidator.Instance
            .ValidateAsync(request, cancellationToken)
            .ConfigureAwait(false);

        validationResult.EnsureValidity(nameof(request));

        var jsonContent = JsonSerializer.Serialize(request, _jsonSerializerOptions);

        using var httpContent = await _httpRequestContentFactory
            .CreateStringContentAsync(jsonContent, cancellationToken)
            .ConfigureAwait(false);

        var endpointConfig = _clientConfiguration.GetEndpoint(inboxId is null ? endpoint : Endpoint.Test);

        // We cannot rely on pre-configured HttpClient.BaseAddress,
        // since it can be external instance with wrong URL configured.
        var sendUrl = endpointConfig.BaseUrl.Append(UrlSegments.ApiRootSegment, UrlSegments.SendEmailSegment);

        using var httpRequest = await _httpRequestMessageFactory
            .CreateAsync(HttpMethod.Post, sendUrl, httpContent, cancellationToken)
            .ConfigureAwait(false);

        // We are using lifetime wrapper for HttpClient, so it's totally OK to dispose it here.
        using var client = await _httpClientLifetimeFactory
            .CreateAsync(endpointConfig, cancellationToken)
            .ConfigureAwait(false);

        using var httpResponse = await client.Client
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
