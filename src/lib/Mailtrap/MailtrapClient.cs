// -----------------------------------------------------------------------
// <copyright file="MailtrapClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap;


/// <summary>
/// <see cref="IMailtrapClient"/> implementation.
/// </summary>
/// 
/// <remarks>
/// Implementation is lightweight, utilizing unit-of-work pattern under the hood,
/// so can be used as transient.
/// </remarks>
internal sealed class MailtrapClient : IMailtrapClient
{
    private readonly MailtrapClientOptions _clientConfiguration;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly HttpClient _httpClient;
    private readonly IHttpRequestMessageFactory _httpRequestMessageFactory;
    private readonly IHttpRequestContentFactory _httpRequestContentFactory;


    /// <summary>
    /// Default instance constructor.
    /// </summary>
    /// 
    /// <param name="options"></param>
    /// <param name="httpClient"></param>
    /// <param name="httpRequestMessageFactory"></param>
    /// <param name="httpRequestContentFactory"></param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When any of the parameters provided is <see langword="null"/>.
    /// </exception>
    public MailtrapClient(
        IOptions<MailtrapClientOptions> options,
        HttpClient httpClient,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpRequestContentFactory httpRequestContentFactory)
    {
        Ensure.NotNull(options, nameof(options));
        Ensure.NotNull(httpClient, nameof(httpClient));
        Ensure.NotNull(httpRequestMessageFactory, nameof(httpRequestMessageFactory));
        Ensure.NotNull(httpRequestContentFactory, nameof(httpRequestContentFactory));

        _clientConfiguration = options.Value;
        _jsonSerializerOptions = _clientConfiguration.Serialization.AsJsonSerializerOptions();

        _httpClient = httpClient;
        _httpRequestMessageFactory = httpRequestMessageFactory;
        _httpRequestContentFactory = httpRequestContentFactory;
    }


    /// <inheritdoc />
    public async Task<SendEmailResponse?> SendEmail(
        SendEmailRequest request,
        SendEndpoint? endpoint = default,
        int? inboxId = default,
        CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        if (inboxId is null && endpoint == SendEndpoint.Test)
        {
            throw new ArgumentNullException(nameof(inboxId), "Inbox ID must be provided when using test endpoint.");
        }

        request.Validate();

        var jsonContent = JsonSerializer.Serialize(request, _jsonSerializerOptions);
        using var httpContent = _httpRequestContentFactory.CreateStringContent(jsonContent);

        var sendUrl = GetUrlForSend(inboxId, endpoint);
        using var httpRequest = _httpRequestMessageFactory.Create(HttpMethod.Post, sendUrl, httpContent);

        using var httpResponse = await _httpClient
            .SendAsync(httpRequest, cancellationToken)
            .ConfigureAwait(false);

        httpResponse.EnsureSuccessStatusCode();

        var body = await httpResponse.Content
            .ReadAsStreamAsync()
            .ConfigureAwait(false);

        return await JsonSerializer
            .DeserializeAsync<SendEmailResponse>(body, _jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }


    private Uri GetUrlForSend(int? inboxId, SendEndpoint? endpoint)
    {
        var finalEndpoint = inboxId is null ? (endpoint ?? SendEndpoint.Transactional) : SendEndpoint.Test;

        var endpointConfig = _clientConfiguration.GetSendEndpointConfiguration(finalEndpoint);

        // We cannot rely on pre-configured HttpClient.BaseAddress,
        // since it can be external instance with wrong URL configured.
        var sendUrl = endpointConfig.BaseUrl.Append(UrlSegments.ApiRootSegment, UrlSegments.SendEmailSegment);

        if (inboxId is not null)
        {
            sendUrl = sendUrl.Append(inboxId.Value.ToString(CultureInfo.InvariantCulture));
        }

        return sendUrl;
    }
}
