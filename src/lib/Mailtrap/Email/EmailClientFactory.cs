// -----------------------------------------------------------------------
// <copyright file="EmailClientFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email;


internal sealed class EmailClientFactory : IEmailClientFactory
{
    private readonly MailtrapClientOptions _clientConfiguration;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpRequestMessageFactory _httpRequestMessageFactory;
    private readonly IHttpRequestContentFactory _httpRequestContentFactory;
    private readonly IEmailClientEndpointProvider _emailClientEndpointProvider;
    private readonly JsonSerializerOptions _jsonSerializationOptions;


    public EmailClientFactory(
        IOptions<MailtrapClientOptions> clientOptions,
        IHttpClientFactory httpClientFactory,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpRequestContentFactory httpRequestContentFactory,
        IEmailClientEndpointProvider emailClientEndpointProvider)
    {
        Ensure.NotNull(clientOptions, nameof(clientOptions));
        Ensure.NotNull(httpClientFactory, nameof(httpClientFactory));
        Ensure.NotNull(httpRequestMessageFactory, nameof(httpRequestMessageFactory));
        Ensure.NotNull(httpRequestContentFactory, nameof(httpRequestContentFactory));
        Ensure.NotNull(emailClientEndpointProvider, nameof(emailClientEndpointProvider));

        _clientConfiguration = clientOptions.Value;

        MailtrapClientOptionsValidator.Instance
            .Validate(_clientConfiguration)
            .EnsureValidity(nameof(clientOptions));

        _httpClientFactory = httpClientFactory;
        _httpRequestMessageFactory = httpRequestMessageFactory;
        _httpRequestContentFactory = httpRequestContentFactory;
        _emailClientEndpointProvider = emailClientEndpointProvider;
        _jsonSerializationOptions = _clientConfiguration.ToJsonSerializerOptions();
    }


    public IEmailClient Create(bool isBulk = false, long? inboxId = default)
    {
        var sendUri = _emailClientEndpointProvider.GetSendRequestUri(isBulk, inboxId);

        return new EmailClient(_httpClientFactory, _httpRequestMessageFactory, _httpRequestContentFactory, _jsonSerializationOptions, sendUri);
    }

    public IEmailClient CreateDefault() => Create(_clientConfiguration.UseBulkApi, _clientConfiguration.InboxId);

    public IEmailClient CreateTransactional() => Create();

    public IEmailClient CreateBulk() => Create(isBulk: true);

    public IEmailClient CreateTest(long inboxId) => Create(inboxId: inboxId);
}
