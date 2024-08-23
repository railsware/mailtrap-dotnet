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
    private readonly HttpClient _httpClient;
    private readonly IHttpRequestMessageFactory _httpRequestMessageFactory;
    private readonly IHttpRequestContentFactory _httpRequestContentFactory;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly Uri _requestUri;
    private readonly HttpMethod _requestMethod;


    /// <summary>
    /// Default instance constructor.
    /// </summary>
    /// 
    /// <param name="httpClient"></param>
    /// <param name="httpRequestMessageFactory"></param>
    /// <param name="httpRequestContentFactory"></param>
    /// <param name="jsonSerializerOptions"></param>
    /// <param name="sendUri"></param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When any of the parameters provided is <see langword="null"/>.
    /// </exception>
    public EmailClient(
        HttpClient httpClient,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpRequestContentFactory httpRequestContentFactory,
        JsonSerializerOptions jsonSerializerOptions,
        Uri sendUri)
    {
        Ensure.NotNull(httpClient, nameof(httpClient));
        Ensure.NotNull(httpRequestMessageFactory, nameof(httpRequestMessageFactory));
        Ensure.NotNull(httpRequestContentFactory, nameof(httpRequestContentFactory));
        Ensure.NotNull(jsonSerializerOptions, nameof(jsonSerializerOptions));

        _httpClient = httpClient;
        _httpRequestMessageFactory = httpRequestMessageFactory;
        _httpRequestContentFactory = httpRequestContentFactory;
        _jsonSerializerOptions = jsonSerializerOptions;
        _requestUri = sendUri;

        _requestMethod = HttpMethod.Post;
    }


    /// <inheritdoc />
    public async Task<SendEmailResponse?> Send(
        SendEmailRequest request,
        CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        request.Validate();

        var jsonContent = JsonSerializer.Serialize(request, _jsonSerializerOptions);
        using var httpContent = _httpRequestContentFactory.CreateStringContent(jsonContent);

        using var httpRequest = _httpRequestMessageFactory.Create(_requestMethod, _requestUri, httpContent);

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
}
