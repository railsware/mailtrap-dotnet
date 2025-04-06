namespace Mailtrap.Emails;


/// <summary>
/// Factory to spawn instances of <see cref="ISendEmailClient"/>.
/// </summary>
internal interface IEmailClientFactory
{
    public ISendEmailClient CreateSend(bool isBulk = false, long? inboxId = default);

    public ISendEmailClient CreateDefaultSend();
    public ISendEmailClient CreateTransactional();
    public ISendEmailClient CreateBulk();
    public ISendEmailClient CreateTest(long inboxId);

    public IBatchEmailClient CreateDefaultBatch();
    public IBatchEmailClient CreateBatch(long inboxId);
}
