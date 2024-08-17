// -----------------------------------------------------------------------
// <copyright file="MailtrapClient.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------



namespace Mailtrap;


/// <summary>
/// <see cref="IMailtrapClient"/> implementation.
/// </summary>
internal sealed class MailtrapClient : IMailtrapClient
{
    private readonly ISendClientFactory _sendClientFactory;


    /// <summary>
    /// Default instance constructor.
    /// </summary>
    /// 
    /// <param name="sendClientFactory"></param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="sendClientFactory"/> is <see langword="null"/>.
    /// </exception>
    public MailtrapClient(ISendClientFactory sendClientFactory)
    {
        Ensure.NotNull(sendClientFactory, nameof(sendClientFactory));

        _sendClientFactory = sendClientFactory;
    }


    // TODO: Decide if we need to cache the clients and return the same instance for the every method call instead.
    // Caching test instances will be more complicated, because will require to store them in the dictionary with the inboxId as a key,
    // but still possible.

    public ISendClient Transactional() => _sendClientFactory.CreateTransactionalClient();

    public ISendClient Bulk() => _sendClientFactory.CreateBulkClient();

    public ISendClient Test(long inboxId) => _sendClientFactory.CreateTestClient(inboxId);
}
