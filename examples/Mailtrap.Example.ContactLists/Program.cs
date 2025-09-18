using Mailtrap;
using Mailtrap.Accounts;
using Mailtrap.Contacts;
using Mailtrap.ContactLists;
using Mailtrap.ContactLists.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mailtrap.ContactLists.Requests;


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

    // Get resource for contact lists collection
    IContactsListCollectionResource contactsListsResource = contactsResource.Lists();

    // Get all contacts lists for account
    IList<ContactsList> contactsLists = await contactsListsResource.GetAll();

    ContactsList? contactsList = contactsLists.Count > 0 ? contactsLists[0] : null;

    if (contactsList is null)
    {
        logger.LogWarning("No contacts list found. Creating.");

        // Create contacts list
        var createContactsListRequest = new ContactsListRequest("MyFirstContactsList");
        contactsList = await contactsListsResource.Create(createContactsListRequest);
    }
    else
    {
        logger.LogInformation("Contacts List {Name} found.", contactsList.Name);
    }

    // Get resource for specific contacts list
    IContactsListResource contactsListResource = contactsResource.List(contactsList.Id);

    // Get details
    ContactsList contactsListResponse = await contactsListResource.GetDetails();
    logger.LogInformation("Contacts List from resource: {Name}", contactsListResponse.Name);

    // Update contacts list details
    var updateContactsListRequest = new ContactsListRequest("updatedContactsList");
    ContactsList updateContactsListResponse = await contactsListResource.Update(updateContactsListRequest);
    logger.LogInformation("Updated Contacts List: Name={Name}, Id={Id}", updateContactsListResponse.Name, updateContactsListResponse.Id);

    // Delete contacts List
    // Beware that contacts list resource becomes invalid after deletion and should not be used anymore
    await contactsListResource.Delete();
    logger.LogInformation("Contacts List Deleted.");
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred during API call.");
    Environment.ExitCode = 1;
    return;
}
