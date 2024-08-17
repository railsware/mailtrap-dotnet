// -----------------------------------------------------------------------
// <copyright file="SendClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email;


/// <summary>
/// Generic <see cref="ISendClient"/> implementation.
/// </summary>
internal class SendClient : ISendClient
{
    private readonly HttpClient _httpClient;
    private readonly IHttpRequestMessageFactory _httpRequestMessageFactory;
    private readonly IHttpRequestContentFactory _httpRequestContentFactory;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly MailtrapClientEndpointOptions _sendEndpointConfiguration;


    /// <summary>
    /// Default instance constructor.
    /// </summary>
    /// 
    /// <param name="httpClientFactory"></param>
    /// <param name="httpRequestMessageFactory"></param>
    /// <param name="httpRequestContentFactory"></param>
    /// <param name="sendEndpointOptions"></param>
    /// <param name="serializationOptions"></param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When any of the parameters provided is <see langword="null"/>.
    /// </exception>
    public SendClient(
        IHttpClientFactory httpClientFactory,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpRequestContentFactory httpRequestContentFactory,
        MailtrapClientEndpointOptions sendEndpointOptions,
        MailtrapClientSerializationOptions serializationOptions)
    {
        Ensure.NotNull(httpClientFactory, nameof(httpClientFactory));
        Ensure.NotNull(httpRequestMessageFactory, nameof(httpRequestMessageFactory));
        Ensure.NotNull(httpRequestContentFactory, nameof(httpRequestContentFactory));
        Ensure.NotNull(serializationOptions, nameof(serializationOptions));
        Ensure.NotNull(sendEndpointOptions, nameof(sendEndpointOptions));

        _httpClient = httpClientFactory.CreateClient(Client.Name);
        _httpRequestMessageFactory = httpRequestMessageFactory;
        _httpRequestContentFactory = httpRequestContentFactory;

        _jsonSerializerOptions = serializationOptions.ToJsonSerializerOptions();
        _sendEndpointConfiguration = sendEndpointOptions;
    }


    /// <inheritdoc />
    public async Task<SendEmailResponse?> SendEmail(SendEmailRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        request.Validate();

        var method = HttpMethod.Post;

        var sendUrl = GetUrlForSend();

        var jsonContent = JsonSerializer.Serialize(request, _jsonSerializerOptions);
        using var httpContent = _httpRequestContentFactory.CreateStringContent(jsonContent);

        using var httpRequest = _httpRequestMessageFactory.Create(method, sendUrl, httpContent);

        using var httpResponse = await _httpClient
            .SendAsync(httpRequest, cancellationToken)
            .ConfigureAwait(false);

        httpResponse.EnsureSuccessStatusCode();

        using var body = await httpResponse.Content
            .ReadAsStreamAsync()
            .ConfigureAwait(false);

        var response = await JsonSerializer
            .DeserializeAsync<SendEmailResponse>(body, _jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);

        return response;
    }


    protected virtual Uri GetUrlForSend()
    {
        // We cannot rely on pre-configured HttpClient.BaseAddress,
        // since it can be external instance with wrong URL configured.
        var result = _sendEndpointConfiguration.BaseUrl.Append(UrlSegments.ApiRootSegment, UrlSegments.SendEmailSegment);

        return result;
    }
}
