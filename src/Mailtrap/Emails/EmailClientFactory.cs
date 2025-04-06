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


    public ISendEmailClient CreateSend(bool isBulk = false, long? inboxId = default)
    {
        var sendUri = _emailClientEndpointProvider.GetSendRequestUri(isBulk, inboxId);

        return new SendEmailClient(_restResourceCommandFactory, sendUri);
    }

    public ISendEmailClient CreateDefaultSend() => CreateSend(_clientConfiguration.UseBulkApi, _clientConfiguration.InboxId);

    public ISendEmailClient CreateTransactional() => CreateSend();

    public ISendEmailClient CreateBulk() => CreateSend(isBulk: true);

    public ISendEmailClient CreateTest(long inboxId) => CreateSend(inboxId: inboxId);


    public IBatchEmailClient CreateBatch(long inboxId)
    {
        var batchUri = _emailClientEndpointProvider.GetBatchRequestUri(inboxId);

        return new BatchEmailClient(_restResourceCommandFactory, batchUri);
    }

    public IBatchEmailClient CreateDefaultBatch() => CreateBatch(_clientConfiguration.InboxId);
}
