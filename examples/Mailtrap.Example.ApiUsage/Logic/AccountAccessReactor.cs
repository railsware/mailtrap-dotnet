// -----------------------------------------------------------------------
// <copyright file="AccountAccessReactor.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Example.ApiUsage.Logic;


internal sealed class AccountAccessReactor : Reactor
{
    public AccountAccessReactor(IMailtrapClient mailtrapClient, ILogger<AccountAccessReactor> logger)
        : base(mailtrapClient, logger) { }


    public async Task Process(long accountId)
    {
        IAccountResource accountResource = _mailtrapClient.Account(accountId);

        // Paid account needed for some operations

        var filter = new AccountAccessFilter();
        var inboxId = 2854500;
        filter.InboxIds.Add(inboxId);

        // Fetch accesses
        IList<AccountAccess> accesses = await accountResource
            .Accesses()
            .Fetch(filter);

        var userId = 4322;

        AccountAccess? userAccess = accesses.FirstOrDefault(a =>
            SpecifierType.User.Equals(a.SpecifierType) &&
            a.Specifier?.Id == userId);

        if (userAccess is null)
        {
            _logger.LogWarning("No access for user with ID {UserID}.", userId);
            return;
        }

        _logger.LogInformation("User Access: {UserAccess}", userAccess);

        // Get resource for specific account access
        IAccountAccessResource userAccessResource = accountResource.Access(userAccess.Id);

        // var updateRequest = new UpdatePermissionsRequest();
        //updateRequest.Permissions.Add(new UpdatePermissionsRequestDetails
        //{
        //    Id = access.Id,
        //    Type = "account",
        //    AccessLevel = AccessLevel.Admin
        //});
    }
}
