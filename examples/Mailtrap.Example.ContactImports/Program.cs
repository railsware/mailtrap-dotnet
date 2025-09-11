using Mailtrap;
using Mailtrap.Accounts;
using Mailtrap.Contacts;
using Mailtrap.Contacts.Requests;
using Mailtrap.ContactImports;
using Mailtrap.ContactImports.Models;
using Mailtrap.ContactImports.Requests;
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
    IContactsImportCollectionResource contactsImportsResource = contactsResource.Imports();

    // Prepare list of contacts to import
    var contactImportList = new List<ContactImportRequest>
    {
        new("alice@mailtrap.io"),
        new("bob@mailtrap.io"),
        new("charlie@mailtrap.io"),
    };

    // Create contacts import request
    var importRequest = new ContactsImportRequest(contactImportList);

    // Import contacts in bulk
    ContactsImport importResponse = await contactsImportsResource.Create(importRequest);
    logger.LogInformation("Created contact import: {Import}", importResponse);

    // Get resource for specific contact import
    IContactsImportResource contactsImportResource = contactsResource.Import(importResponse.Id);

    // Get details of specific contact import
    ContactsImport contactsImportDetails = await contactsImportResource.GetDetails();
    logger.LogInformation("Contacts Import Details: {Details}", contactsImportDetails);

    if (contactsImportDetails.Status == ContactsImportStatus.Failed)
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
