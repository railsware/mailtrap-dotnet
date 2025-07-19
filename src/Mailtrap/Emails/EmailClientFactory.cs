namespace Mailtrap.Emails;


/// <summary>
/// <see cref="IEmailClientFactory"/> implementation.
/// </summary>
internal sealed class EmailClientFactory : IEmailClientFactory
{
    private readonly MailtrapClientOptions _clientConfiguration;
    private readonly IEmailClientEndpointProvider _emailClientEndpointProvider;
    private readonly IRestResourceCommandFactory _restResourceCommandFactory;


    public EmailClientFactory(
        IOptions<MailtrapClientOptions> clientOptions,
        IEmailClientEndpointProvider emailClientEndpointProvider,
        IRestResourceCommandFactory restResourceCommandFactory)
    {
        Ensure.NotNull(clientOptions, nameof(clientOptions));
        Ensure.NotNull(emailClientEndpointProvider, nameof(emailClientEndpointProvider));
        Ensure.NotNull(restResourceCommandFactory, nameof(restResourceCommandFactory));

        _clientConfiguration = clientOptions.Value;
        _emailClientEndpointProvider = emailClientEndpointProvider;
        _restResourceCommandFactory = restResourceCommandFactory;
    }


    public IEmailClient Create(bool isBulk = false, long? inboxId = default)
    {
        var sendUri = _emailClientEndpointProvider.GetSendRequestUri(isBulk, inboxId);

        return new EmailClient(_restResourceCommandFactory, sendUri);
    }

    public IEmailClient CreateDefault() => Create(_clientConfiguration.UseBulkApi, _clientConfiguration.InboxId);

    public IEmailClient CreateTransactional() => Create();

    public IEmailClient CreateBulk() => Create(isBulk: true);

    public IEmailClient CreateTest(long inboxId) => Create(inboxId: inboxId);
}
