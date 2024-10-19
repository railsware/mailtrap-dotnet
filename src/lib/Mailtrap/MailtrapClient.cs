// -----------------------------------------------------------------------
// <copyright file="MailtrapClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Mailtrap.Accounts;

namespace Mailtrap;


/// <summary>
/// <see cref="IMailtrapClient"/> implementation.
/// </summary>
internal sealed class MailtrapClient : IMailtrapClient
{
    private readonly IEmailClientFactory _emailClientFactory;
    private readonly IEmailClient _defaultEmailClient;


    /// <summary>
    /// Default instance constructor.
    /// </summary>
    ///
    /// <param name="emailClientFactory"></param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="emailClientFactory"/> is <see langword="null"/>.
    /// </exception>
    public MailtrapClient(IEmailClientFactory emailClientFactory)
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


    public IAccountCollectionResource Accounts() => throw new NotImplementedException();

    public IAccountResource Account(long accountId) => throw new NotImplementedException();
}
