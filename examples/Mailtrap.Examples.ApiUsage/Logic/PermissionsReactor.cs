// -----------------------------------------------------------------------
// <copyright file="PermissionsReactor.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Examples.ApiUsage.Logic;


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
            .GetForResources();

        _logger.LogInformation("Resource Permissions: {ResourcePermissions}", permissions);
    }
}
