// -----------------------------------------------------------------------
// <copyright file="InboxReactor.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Example.ApiUsage.Logic;


internal sealed class InboxReactor : Reactor
{
    private readonly MessageReactor _messageReactor;


    public InboxReactor(
        MessageReactor messageReactor,
        IMailtrapClient mailtrapClient,
        ILogger<InboxReactor> logger)
        : base(mailtrapClient, logger)
    {
        _messageReactor = messageReactor;
    }


    public async Task Process(long accountId, long projectId)
    {
        IAccountResource accountResource = _mailtrapClient.Account(accountId);

        var inboxName = "My Test Inbox";

        // Get resource for inbox collection
        IInboxCollectionResource inboxesResource = accountResource.Inboxes();

        // Get all inboxes for account
        IList<Inbox> inboxes = await inboxesResource.GetAll();

        Inbox? inbox = inboxes
            .FirstOrDefault(i => string.Equals(i.Name, inboxName, StringComparison.OrdinalIgnoreCase));

        if (inbox is null)
        {
            _logger.LogWarning("No inbox found. Creating.");

            // Create inbox
            var createInboxRequest = new CreateInboxRequest(projectId, inboxName);
            inbox = await inboxesResource.Create(createInboxRequest);
        }
        else
        {
            _logger.LogInformation("Inbox found.");
        }

        // Get resource for specific inbox
        IInboxResource inboxResource = accountResource.Inbox(inbox.Id);

        // Get Details
        inbox = await inboxResource.GetDetails();
        _logger.LogInformation("Inbox: {Inbox}", inbox);

        // Process messages
        await _messageReactor.Process(accountId, inbox.Id);

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

        _logger.LogInformation("Updated Inbox: {Inbox}", updatedInbox);

        // Delete inbox
        // Beware that resource becomes invalid after deletion and should not be used anymore
        Inbox deletedInbox = await inboxResource.Delete();
        _logger.LogInformation("Deleted Inbox: {Inbox}", deletedInbox);
    }
}
