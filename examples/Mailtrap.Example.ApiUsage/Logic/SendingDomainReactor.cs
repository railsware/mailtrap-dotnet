// -----------------------------------------------------------------------
// <copyright file="SendingDomainReactor.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Example.ApiUsage.Logic;


internal sealed class SendingDomainReactor : Reactor
{
    public SendingDomainReactor(IMailtrapClient mailtrapClient, ILogger<SendingDomainReactor> logger)
        : base(mailtrapClient, logger) { }


    public async Task Process(long accountId)
    {
        IAccountResource accountResource = _mailtrapClient.Account(accountId);

        var domainName = "demomailtrap.com";

        // Get resource for domains collection
        ISendingDomainCollectionResource domainsResource = accountResource.SendingDomains();

        // Get all sending domains for account
        IList<SendingDomain> domains = await domainsResource.GetAll();

        SendingDomain? domain = domains
            .FirstOrDefault(d => string.Equals(d.DomainName, domainName, StringComparison.OrdinalIgnoreCase));

        if (domain is null)
        {
            _logger.LogWarning("No sending domain found. Creating.");

            // Create sending domain
            var createDomainRequest = new CreateSendingDomainRequest(domainName);
            domain = await domainsResource.Create(createDomainRequest);
        }
        else
        {
            _logger.LogInformation("Sending domain found.");
        }

        // Get resource for specific sending domain
        ISendingDomainResource domainResource = accountResource.SendingDomain(domain.Id);

        // Get details
        domain = await domainResource.GetDetails();
        _logger.LogInformation("Sending Domain: {SendingDomain}", domain);

        // Sending domain instructions
        var instructionsRequest = new SendingDomainInstructionsRequest("admin@demomailtrap.com");
        await domainResource.SendInstructions(instructionsRequest);
    }
}
