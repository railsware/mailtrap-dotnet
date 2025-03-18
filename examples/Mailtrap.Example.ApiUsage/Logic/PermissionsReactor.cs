namespace Mailtrap.Example.ApiUsage.Logic;


internal sealed class PermissionsReactor : Reactor
{
    public PermissionsReactor(IMailtrapClient mailtrapClient, ILogger<PermissionsReactor> logger)
        : base(mailtrapClient, logger) { }


    public async Task Process(long accountId)
    {
        IAccountResource accountResource = _mailtrapClient.Account(accountId);

        // Get resource permissions for account
        IList<ResourcePermissions> permissions = await accountResource
            .Permissions()
            .GetAll();

        _logger.LogInformation("Resource Permissions: {ResourcePermissions}", permissions);
    }
}
