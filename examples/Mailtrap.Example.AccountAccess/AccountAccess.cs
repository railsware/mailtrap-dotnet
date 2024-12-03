// -----------------------------------------------------------------------
// <copyright file="AccountAccess.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Mailtrap;
using Mailtrap.AccountAccesses;
using Mailtrap.AccountAccesses.Models;
using Mailtrap.AccountAccesses.Requests;
using Mailtrap.Accounts;
using Mailtrap.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);

IConfigurationSection config = hostBuilder.Configuration.GetSection("Mailtrap");

hostBuilder.Services.AddMailtrapClient(config);

using IHost host = hostBuilder.Build();

ILogger<Program> logger = host.Services.GetRequiredService<ILogger<Program>>();
IMailtrapClient mailtrapClient = host.Services.GetRequiredService<IMailtrapClient>();

try
{
    var accountId = 12345;
    IAccountResource accountResource = mailtrapClient.Account(accountId);

    // Fetch accesses
    var filter = new AccountAccessFilter();
    var inboxId = 45345;
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
        logger.LogWarning("No access for user with ID {UserID}.", userId);
        return;
    }

    logger.LogInformation("User Access: {UserAccess}", userAccess);

    // Get resource for specific account access
    IAccountAccessResource userAccessResource = accountResource.Access(userAccess.Id);

    // Update access level for specific resource(s)
    var updateRequest = new UpdatePermissionsRequest(
        new UpdatePermissionsRequestItem(inboxId, ResourceType.Inbox, AccessLevel.Admin));
    await userAccessResource.UpdatePermissions(updateRequest);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred during API call.");
    Environment.FailFast(ex.Message);
    throw;
}
