using Mailtrap;
using Mailtrap.Accounts;
using Mailtrap.Contacts;
using Mailtrap.Contacts.Requests;
using Mailtrap.ContactImports;
using Mailtrap.ContactImports.Models;
using Mailtrap.ContactImports.Requests;
using Mailtrap.ContactImports.Responses;
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

    // Get resource for contacts collection
    IContactCollectionResource contactsResource = accountResource.Contacts();

    //Get resource for contact imports collection
    IContactsImportCollectionResource contactsImportResource = contactsResource.Imports();

    // Prepare list of contacts to import
    var contactsImportList = new List<ContactImportRequest>
    {
        new("alice@mailtrap.io"),
        new("bob@mailtrap.io"),
        new("charlie@mailtrap.io"),
    };

    // Create contacts import request
    var importRequest = new ContactsImportRequest(contactsImportList);

    // Import contacts in bulk
    ContactsImportResponse importResponse = await contactsImportResource.Create(importRequest);
    logger.LogInformation("Created contact import: {Import}", importResponse);

    // Get resource for specific contact import
    IContactsImportResource contactImportResource = contactsResource.Import(importResponse.Id);

    // Get details of specific contact import
    ContactsImport contactImportDetails = await contactImportResource.GetDetails();
    logger.LogInformation("Contacts Import Details: {Details}", contactImportDetails);

    if (contactImportDetails.Status == ContactsImportStatus.Failed)
    {
        logger.LogWarning("Import failed!");
    }
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred during API call.");
    Environment.FailFast(ex.Message);
    throw;
}
