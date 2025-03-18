using Mailtrap;
using Mailtrap.Accounts;
using Mailtrap.Inboxes;
using Mailtrap.Inboxes.Models;
using Mailtrap.Inboxes.Requests;
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
    var projectId = 54321;
    IAccountResource accountResource = mailtrapClient.Account(accountId);

    var inboxName = "My Test Inbox";

    // Get resource for inbox collection
    IInboxCollectionResource inboxesResource = accountResource.Inboxes();

    // Get all inboxes for account
    IList<Inbox> inboxes = await inboxesResource.GetAll();

    Inbox? inbox = inboxes
        .FirstOrDefault(i => string.Equals(i.Name, inboxName, StringComparison.OrdinalIgnoreCase));

    if (inbox is null)
    {
        logger.LogWarning("No inbox found. Creating.");

        // Create inbox
        var createInboxRequest = new CreateInboxRequest(projectId, inboxName);
        inbox = await inboxesResource.Create(createInboxRequest);
    }
    else
    {
        logger.LogInformation("Inbox found.");
    }

    // Get resource for specific inbox
    IInboxResource inboxResource = accountResource.Inbox(inbox.Id);

    // Get Details
    inbox = await inboxResource.GetDetails();
    logger.LogInformation("Inbox: {Inbox}", inbox);

    // Mark all messages in the inbox as read
    Inbox updatedInbox = await inboxResource.MarkAsRead();

    // Update inbox details
    var updateInboxRequest = new UpdateInboxRequest
    {
        Name = "Updated Inbox Name"
    };
    updatedInbox = await inboxResource.Update(updateInboxRequest);

    // Toggle email for inbox
    // updatedInbox = await inboxResource.ToggleEmailAddress();

    // Reset email address for inbox
    updatedInbox = await inboxResource.ResetEmailAddress();

    // Reset credentials for inbox
    updatedInbox = await inboxResource.ResetCredentials();

    logger.LogInformation("Updated Inbox: {Inbox}", updatedInbox);

    // Delete inbox
    // Beware that resource becomes invalid after deletion and should not be used anymore
    Inbox deletedInbox = await inboxResource.Delete();
    logger.LogInformation("Deleted Inbox: {Inbox}", deletedInbox);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred during API call.");
    Environment.FailFast(ex.Message);
    throw;
}
