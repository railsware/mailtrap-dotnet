// -----------------------------------------------------------------------
// <copyright file="SendingDomain.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Mailtrap;
using Mailtrap.Accounts;
using Mailtrap.SendingDomains;
using Mailtrap.SendingDomains.Models;
using Mailtrap.SendingDomains.Requests;
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

    // Get resource for domains collection
    ISendingDomainCollectionResource domainsResource = accountResource.SendingDomains();

    // Get all sending domains for account
    IList<SendingDomain> domains = await domainsResource.GetAll();

    var domainName = "demomailtrap.com";
    SendingDomain? domain = domains
        .FirstOrDefault(d => string.Equals(d.DomainName, domainName, StringComparison.OrdinalIgnoreCase));

    if (domain is null)
    {
        logger.LogWarning("No sending domain found. Creating.");

        // Create sending domain
        var createDomainRequest = new CreateSendingDomainRequest(domainName);
        domain = await domainsResource.Create(createDomainRequest);
    }
    else
    {
        logger.LogInformation("Sending domain found.");
    }

    // Get resource for specific sending domain
    ISendingDomainResource domainResource = accountResource.SendingDomain(domain.Id);

    // Get details
    domain = await domainResource.GetDetails();
    logger.LogInformation("Sending Domain: {SendingDomain}", domain);

    // Sending domain instructions
    var instructionsRequest = new SendingDomainInstructionsRequest("admin@demomailtrap.com");
    await domainResource.SendInstructions(instructionsRequest);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred during API call.");
    Environment.FailFast(ex.Message);
    throw;
}
