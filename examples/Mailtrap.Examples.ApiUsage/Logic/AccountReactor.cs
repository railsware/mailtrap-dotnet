// -----------------------------------------------------------------------
// <copyright file="AccountReactor.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Examples.ApiUsage.Logic;


internal sealed class AccountReactor : Reactor
{
    private readonly BillingReactor _billingReactor;
    private readonly AccountAccessReactor _accountAccessReactor;
    private readonly PermissionsReactor _permissionsReactor;
    private readonly ProjectReactor _projectReactor;


    public AccountReactor(
        BillingReactor billingReactor,
        AccountAccessReactor accountAccessReactor,
        PermissionsReactor permissionsReactor,
        ProjectReactor projectReactor,
        IMailtrapClient mailtrapClient,
        ILogger<AccountReactor> logger)
        : base(mailtrapClient, logger)
    {
        _billingReactor = billingReactor;
        _accountAccessReactor = accountAccessReactor;
        _permissionsReactor = permissionsReactor;
        _projectReactor = projectReactor;
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
        // await _accountAccessReactor.Process(accountId); // available for payed account only
        await _permissionsReactor.Process(accountId);
        await _projectReactor.Process(accountId);
    }
}
