namespace Mailtrap;


/// <summary>
/// <see cref="IMailtrapClient"/> implementation.
/// </summary>
internal sealed class MailtrapClient : RestResource, IMailtrapClient
{
    private const string AccountsSegment = "accounts";

    private readonly IEmailClientFactory _emailClientFactory;
    private readonly IEmailClient _defaultEmailClient;


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
        _defaultEmailClient = emailClientFactory.CreateDefault();
    }


    /// <inheritdoc/>
    public IEmailClient Email() => _defaultEmailClient;

    /// <inheritdoc/>
    public IEmailClient Transactional() => _emailClientFactory.CreateTransactional();

    /// <inheritdoc/>
    public IEmailClient Bulk() => _emailClientFactory.CreateBulk();

    /// <inheritdoc/>
    public IEmailClient Test(long inboxId) => _emailClientFactory.CreateTest(inboxId);


    /// <inheritdoc/>
    public IAccountCollectionResource Accounts()
        => new AccountCollectionResource(RestResourceCommandFactory, ResourceUri.Append(AccountsSegment));

    /// <inheritdoc/>
    public IAccountResource Account(long accountId)
        => new AccountResource(RestResourceCommandFactory, ResourceUri.Append(AccountsSegment).Append(accountId));
}
