// -----------------------------------------------------------------------
// <copyright file="EmailClientFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------



namespace Mailtrap.Email;


internal sealed class EmailClientFactory : IEmailClientFactory
{
    private readonly MailtrapClientOptions _clientConfiguration;
    private readonly HttpClient _httpClient;
    private readonly IHttpRequestMessageFactory _httpRequestMessageFactory;
    private readonly IHttpRequestContentFactory _httpRequestContentFactory;

    private readonly JsonSerializerOptions _jsonSerializationOptions;


    public EmailClientFactory(
        IOptions<MailtrapClientOptions> clientOptions,
        HttpClient httpClient,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpRequestContentFactory httpRequestContentFactory)
    {
        Ensure.NotNull(clientOptions, nameof(clientOptions));
        Ensure.NotNull(httpClient, nameof(httpClient));
        Ensure.NotNull(httpRequestMessageFactory, nameof(httpRequestMessageFactory));
        Ensure.NotNull(httpRequestContentFactory, nameof(httpRequestContentFactory));

        _clientConfiguration = clientOptions.Value;

        MailtrapClientOptionsValidator.Instance
            .Validate(_clientConfiguration)
            .EnsureValidity(nameof(clientOptions));

        _httpClient = httpClient;
        _httpRequestMessageFactory = httpRequestMessageFactory;
        _httpRequestContentFactory = httpRequestContentFactory;

        _jsonSerializationOptions = _clientConfiguration.ToJsonSerializerOptions();
    }


    public IEmailClient Create(bool isBulk = false, long? inboxId = default)
    {
        var sendUri = GetRequestUri(isBulk, inboxId);

        return new EmailClient(_httpClient, _httpRequestMessageFactory, _httpRequestContentFactory, _jsonSerializationOptions, sendUri);
    }

    public IEmailClient CreateDefault() => Create(_clientConfiguration.UseBulkApi, _clientConfiguration.InboxId);

    public IEmailClient CreateTransactional() => Create();

    public IEmailClient CreateBulk() => Create(isBulk: true);

    public IEmailClient CreateTest(long inboxId) => Create(inboxId: inboxId);



    private static Uri GetRequestUri(bool isBulk, long? inboxId)
    {
        var rootUrl = inboxId switch
        {
            null => isBulk ? Endpoints.BulkDefaultUrl : Endpoints.SendDefaultUrl,
            _ => Endpoints.TestDefaultUrl,
        };

        var result = rootUrl.Append(UrlSegments.ApiRootSegment, UrlSegments.SendEmailSegment);

        return inboxId is null ? result : result.Append(inboxId.Value.ToString(CultureInfo.InvariantCulture));
    }
}
