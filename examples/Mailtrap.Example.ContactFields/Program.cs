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
    IContactFieldCollectionResource contactFieldsResource = contactsResource.Fields();

    // Get all contact fields for account
    IList<ContactField> contactFields = await contactFieldsResource.GetAll();

    ContactField? contactField = contactFields.Count > 0 ? contactFields[0] : null;

    if (contactField is null)
    {
        logger.LogWarning("No contact field found. Creating.");

        // Create contact field
        var createContactFieldRequest = new CreateContactFieldRequest("MyFirstContactField", "TestMergeTag", ContactFieldDataType.Text);
        contactField = await contactFieldsResource.Create(createContactFieldRequest);
    }
    else
    {
        logger.LogInformation("Contact Field {Name} found.", contactField.Name);
    }

    // Get resource for specific contact field
    IContactFieldResource contactFieldResource = contactsResource.Field(contactField.Id);

    // Get details
    ContactField contactFieldDetails = await contactFieldResource.GetDetails();
    logger.LogInformation("Contact Field from resource: {Name}", contactFieldDetails.Name);

    // Update contacts field details
    var updateContactFieldRequest = new UpdateContactFieldRequest("UpdatedContactField", "UpdatedMergeTag");
    ContactField updateContactFieldResponse = await contactFieldResource.Update(updateContactFieldRequest);
    logger.LogInformation("Updated Contact Field: Name={Name}, Id={Id}", updateContactFieldResponse.Name, updateContactFieldResponse.Id);

    // Delete contact Field
    // Beware that contact Field resource becomes invalid after deletion and should not be used anymore
    await contactFieldResource.Delete();
    logger.LogInformation("Contact Field Deleted.");
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred during API call.");
    Environment.ExitCode = 1;
    return;
}
