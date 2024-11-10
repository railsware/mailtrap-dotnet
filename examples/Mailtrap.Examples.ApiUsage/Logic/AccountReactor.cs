// -----------------------------------------------------------------------
// <copyright file="AccountReactor.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Examples.ApiUsage.Logic;


internal sealed class AccountReactor : Reactor
{
    private readonly BillingReactor _billingReactor;


    public AccountReactor(
        BillingReactor billingReactor,
        IMailtrapClient mailtrapClient,
        ILogger<AccountReactor> logger)
        : base(mailtrapClient, logger)
    {
        _billingReactor = billingReactor;
    }


    public async Task Process(long accountId)
    {
        // Get all accounts available for the token
        IList<Account> accounts = await _mailtrapClient
            .Accounts()
            .GetAll();

        Account? account = accounts.FirstOrDefault(a => a.Id == accountId);

        if (account is null)
        {
            _logger.LogWarning("No account found.");

            return;
        }

        _logger.LogInformation("Account: {Account}", account);

        await _billingReactor.Process(accountId);
    }
}
