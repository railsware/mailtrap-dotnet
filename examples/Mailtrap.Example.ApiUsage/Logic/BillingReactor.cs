namespace Mailtrap.Example.ApiUsage.Logic;


internal sealed class BillingReactor : Reactor
{
    public BillingReactor(IMailtrapClient mailtrapClient, ILogger<BillingReactor> logger)
        : base(mailtrapClient, logger) { }


    public async Task Process(long accountId)
    {
        IAccountResource accountResource = _mailtrapClient.Account(accountId);

        // Get billing usage for account
        BillingUsage billing = await accountResource
            .Billing()
            .GetUsage();

        _logger.LogInformation("Billing Usage: {BillingUsage}", billing);
    }
}
