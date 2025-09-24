using Mailtrap;
using Mailtrap.Accounts;
using Mailtrap.Contacts;
using Mailtrap.Contacts.Models;
using Mailtrap.Contacts.Requests;
using Mailtrap.Contacts.Responses;
using Mailtrap.ContactEvents;
using Mailtrap.ContactEvents.Models;
using Mailtrap.ContactEvents.Requests;
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

    // Get all contacts for account
    IList<Contact> contacts = await contactsResource.GetAll();

    Contact? contact = contacts.Count > 0 ? contacts[0] : null;
    if (contact is null)
    {
        logger.LogWarning("No contact found. Creating.");

        // Create contact
        var createContactRequest = new CreateContactRequest("email@example.com");
        createContactRequest.Fields.Add("first_name", "John");
        createContactRequest.Fields.Add("last_name", "Doe");
        CreateContactResponse createContactResponse = await contactsResource.Create(createContactRequest);
        contact = createContactResponse.Contact;
    }
    else
    {
        logger.LogInformation("Contact found with Id {ContactId} and Email {ContactEmail}.", contact.Id, contact.Email);
    }

    // Get resource for contact events collection
    IContactsEventCollectionResource contactsEventsResource = contactsResource.Events(contact.Id);

    // Create contacts event
    var createContactsEventRequest = new CreateContactsEventRequest("MyFirstContactsEvent");
    createContactsEventRequest.Params.Add("user_id", 101);
    createContactsEventRequest.Params.Add("user_name", "John Smith");
    createContactsEventRequest.Params.Add("is_active", true);
    createContactsEventRequest.Params.Add("last_seen", null);
    ContactsEvent contactsEvent = await contactsEventsResource.Create(createContactsEventRequest);

    logger.LogInformation("Contacts Event created: {Name}", contactsEvent.Name);
    logger.LogInformation("ID: {ContactId}", contactsEvent.ContactId);
    logger.LogInformation("Created At: {ContactEmail}", contactsEvent.ContactEmail);
    foreach (KeyValuePair<string, object?> param in contactsEvent.Params)
    {
        logger.LogInformation("Param: {ParamKey} = {ParamValue}", param.Key, param.Value);
    }
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred during API call.");
    Environment.ExitCode = 1;
    return;
}
