namespace Mailtrap.Example.ApiUsage.Logic;


internal sealed class AccountAccessReactor : Reactor
{
    public AccountAccessReactor(IMailtrapClient mailtrapClient, ILogger<AccountAccessReactor> logger)
        : base(mailtrapClient, logger) { }


    public async Task Process(long accountId)
    {
        IAccountResource accountResource = _mailtrapClient.Account(accountId);

        // Fetch accesses
        var filter = new AccountAccessFilter();
        var inboxId = 654321;
        filter.InboxIds.Add(inboxId);

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

        // Update access level for specific resource(s)
        var updateRequest = new UpdatePermissionsRequest(
            new UpdatePermissionsRequestItem(inboxId, ResourceType.Inbox, AccessLevel.Admin));
        await userAccessResource.UpdatePermissions(updateRequest);
    }
}
