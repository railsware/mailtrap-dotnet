// -----------------------------------------------------------------------
// <copyright file="MailtrapEmailApiClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System.Net.Http.Json;


namespace Mailtrap;


/// <inheritdoc cref="IMailtrapEmailApiClient"/>
public class MailtrapEmailApiClient : IMailtrapEmailApiClient
{
    private readonly Uri _apiHost;
    private readonly IHttpClientProvider _httpClientProvider;
    private readonly ISerializationOptionsProvider _serializationOptionsProvider;


    /// <summary>
    /// Internal constructor to be used in unit tests to mock dependencies.
    /// Later can be converted to public one to support DI.
    /// </summary>
    /// <param name="apiHostProvider"></param>
    /// <param name="httpClientProvider"></param>
    /// <param name="serializationOptionsProvider"></param>
    internal MailtrapEmailApiClient(
        IApiBaseUrlProvider apiHostProvider,
        IHttpClientProvider httpClientProvider,
        ISerializationOptionsProvider serializationOptionsProvider)
    {
        ExceptionHelpers.ThrowIfNull(apiHostProvider, nameof(apiHostProvider));
        ExceptionHelpers.ThrowIfNull(httpClientProvider, nameof(httpClientProvider));
        ExceptionHelpers.ThrowIfNull(serializationOptionsProvider, nameof(serializationOptionsProvider));

        _apiHost = apiHostProvider.SendEmailHost;
        _httpClientProvider = httpClientProvider;
        _serializationOptionsProvider = serializationOptionsProvider;
    }

    /// <summary>
    /// Shortcut constructor to be used with base URL and API key parameters
    /// </summary>
    /// <param name="apiHost">Root API URL, e.g. https://send.api.mailtrap.io/. <b>Should contain trailing slash.</b></param>
    /// <param name="apiKey">API authorization key</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    public MailtrapEmailApiClient(string apiHost, string apiKey) :
        this(
            new DefaultApiBaseUrlProvider(apiHost),
            new DefaultHttpClientProvider(apiKey),
            DefaultSerializationOptionsProvider.Instance)
    { }


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

        var relativePath = string.Join("/", ApiUrlSegments.ApiRootSegment, ApiUrlSegments.SendEmailSegment);
        var uri = new Uri(_apiHost, relativePath);

        var client = await _httpClientProvider
            .GetClientAsync(cancellationToken)
            .ConfigureAwait(false);

        using var response = await client
            .PostAsJsonAsync(uri, request, _serializationOptionsProvider.Options, cancellationToken)
            .ConfigureAwait(false);

        // For now just throwing standard HttpRequestException for anything except success.
        // More robust exception handling with custom Exception types can be added later on.
        response.EnsureSuccessStatusCode();

        var body = await response.Content
            .ReadAsStringAsync()
            .ConfigureAwait(false);

        return JsonSerializer.Deserialize<EmailSendApiResponse>(body, _serializationOptionsProvider.Options);
    }
}
