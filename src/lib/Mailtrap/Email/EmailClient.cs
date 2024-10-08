// -----------------------------------------------------------------------
// <copyright file="EmailClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email;


/// <summary>
/// <see cref="IEmailClient"/> implementation.
/// </summary>
internal sealed class EmailClient : IEmailClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpRequestMessageFactory _httpRequestMessageFactory;
    private readonly IHttpRequestContentFactory _httpRequestContentFactory;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly HttpMethod _sendRequestMethod;


    public Uri SendUri { get; }


    /// <summary>
    /// Default instance constructor.
    /// </summary>
    /// 
    /// <param name="httpClientFactory"></param>
    /// <param name="httpRequestMessageFactory"></param>
    /// <param name="httpRequestContentFactory"></param>
    /// <param name="jsonSerializerOptions"></param>
    /// <param name="sendUri"></param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When any of the parameters provided is <see langword="null"/>.
    /// </exception>
    public EmailClient(
        IHttpClientFactory httpClientFactory,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpRequestContentFactory httpRequestContentFactory,
        JsonSerializerOptions jsonSerializerOptions,
        Uri sendUri)
    {
        Ensure.NotNull(httpClientFactory, nameof(httpClientFactory));
        Ensure.NotNull(httpRequestMessageFactory, nameof(httpRequestMessageFactory));
        Ensure.NotNull(httpRequestContentFactory, nameof(httpRequestContentFactory));
        Ensure.NotNull(jsonSerializerOptions, nameof(jsonSerializerOptions));
        Ensure.NotNull(sendUri, nameof(sendUri));

        _httpClientFactory = httpClientFactory;
        _httpRequestMessageFactory = httpRequestMessageFactory;
        _httpRequestContentFactory = httpRequestContentFactory;
        _jsonSerializerOptions = jsonSerializerOptions;

        _sendRequestMethod = HttpMethod.Post;

        SendUri = sendUri;
    }


    /// <inheritdoc/>
    public async Task<SendEmailResponse> Send(SendEmailRequest request, CancellationToken cancellationToken = default)
    {
        ValidateRequest(request);

        // Should not dispose HttpClient here, it's managed by the factory.
        // Also it can be a singleton instance, shared across requests.
        var httpClient = _httpClientFactory.CreateClient(Client.Name);

        var jsonContent = JsonSerializer.Serialize(request, _jsonSerializerOptions);
        using var httpContent = _httpRequestContentFactory.CreateStringContent(jsonContent);
        using var httpRequest = _httpRequestMessageFactory.Create(_sendRequestMethod, SendUri, httpContent);

        using var httpResponse = await httpClient
            .SendAsync(httpRequest, cancellationToken)
            .ConfigureAwait(false);

        httpResponse.EnsureSuccessStatusCode();

        var body = await httpResponse.Content
            .ReadAsStreamAsync()
            .ConfigureAwait(false);

        var response = await JsonSerializer
            .DeserializeAsync<SendEmailResponse>(body, _jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);

        return response ?? throw InvalidResponseFormatException.Create(SendUri.ToString());
    }


    private static void ValidateRequest(SendEmailRequest request)
    {
        Ensure.NotNull(request, nameof(request));

        request
            .Validate()
            .EnsureValidity(nameof(request));
    }
}
