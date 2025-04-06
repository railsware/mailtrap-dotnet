namespace Mailtrap;


/// <summary>
/// <see cref="IMailtrapClient"/> implementation.
/// </summary>
internal sealed class MailtrapClient : RestResource, IMailtrapClient
{
    private const string AccountsSegment = "accounts";

    private readonly IEmailClientFactory _emailClientFactory;
    private readonly ISendEmailClient _defaultSendEmailClient;
    private readonly IBatchEmailClient _defaultBatchEmailClient;


    /// <summary>
    /// Default instance constructor.
    /// </summary>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="emailClientFactory"/> is <see langword="null"/>.
    /// </exception>
    public MailtrapClient(IEmailClientFactory emailClientFactory, IRestResourceCommandFactory restResourceCommandFactory)
        : base(restResourceCommandFactory, Endpoints.ApiDefaultUrl.Append(UrlSegments.ApiRootSegment))
    {
        Ensure.NotNull(emailClientFactory, nameof(emailClientFactory));

        _emailClientFactory = emailClientFactory;
        _defaultSendEmailClient = emailClientFactory.CreateDefaultSend();
        _defaultBatchEmailClient = emailClientFactory.CreateDefaultBatch();
    }


    /// <inheritdoc/>
    public ISendEmailClient Email() => _defaultSendEmailClient;

    /// <inheritdoc/>
    public IBatchEmailClient BatchEmail() => _defaultBatchEmailClient;

    /// <inheritdoc/>
    public ISendEmailClient Transactional() => _emailClientFactory.CreateTransactional();

    /// <inheritdoc/>
    public ISendEmailClient Bulk() => _emailClientFactory.CreateBulk();

    /// <inheritdoc/>
    public ISendEmailClient Test(long inboxId) => _emailClientFactory.CreateTest(inboxId);

    /// <inheritdoc/>
    public IBatchEmailClient Batch(long inboxId) => _emailClientFactory.CreateBatch(inboxId);


    /// <inheritdoc/>
    public IAccountCollectionResource Accounts()
        => new AccountCollectionResource(RestResourceCommandFactory, ResourceUri.Append(AccountsSegment));

    /// <inheritdoc/>
    public IAccountResource Account(long accountId)
        => new AccountResource(RestResourceCommandFactory, ResourceUri.Append(AccountsSegment).Append(accountId));
}
