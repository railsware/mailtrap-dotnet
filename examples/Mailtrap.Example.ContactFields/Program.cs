using Mailtrap;
using Mailtrap.Accounts;
using Mailtrap.Contacts;
using Mailtrap.ContactFields;
using Mailtrap.ContactFields.Models;
using Mailtrap.ContactFields.Requests;
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

    // Get resource for contact fields collection
    IContactsFieldCollectionResource contactsFieldsResource = contactsResource.Fields();

    // Get all contacts fields for account
    IList<ContactsField> contactsFields = await contactsFieldsResource.GetAll();

    ContactsField? contactsField = contactsFields.Count > 0 ? contactsFields[0] : null;

    if (contactsField is null)
    {
        logger.LogWarning("No contacts field found. Creating.");

        // Create contacts field
        var createContactsFieldRequest = new CreateContactsFieldRequest("MyFirstContactsField", "TestMergeTag", ContactsFieldDataType.Text);
        contactsField = await contactsFieldsResource.Create(createContactsFieldRequest);
    }
    else
    {
        logger.LogInformation("Contacts Field {Name} found.", contactsField.Name);
    }

    // Get resource for specific contacts field
    IContactsFieldResource contactsFieldResource = contactsResource.Field(contactsField.Id);

    // Get details
    ContactsField contactsFieldDetails = await contactsFieldResource.GetDetails();
    logger.LogInformation("Contacts Field from resource: {Name}", contactsFieldDetails.Name);

    // Update contacts field details
    var updateContactsFieldRequest = new UpdateContactsFieldRequest("UpdatedContactsField", "UpdatedMergeTag");
    ContactsField updateContactsFieldResponse = await contactsFieldResource.Update(updateContactsFieldRequest);
    logger.LogInformation("Updated Contacts Field: Name={Name}, Id={Id}", updateContactsFieldResponse.Name, updateContactsFieldResponse.Id);

    // Delete contacts Field
    // Beware that contacts Field resource becomes invalid after deletion and should not be used anymore
    await contactsFieldResource.Delete();
    logger.LogInformation("Contacts Field Deleted.");
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred during API call.");
    Environment.ExitCode = 1;
    return;
}
