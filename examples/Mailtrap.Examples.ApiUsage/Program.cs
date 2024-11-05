// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System.Net.Mime;
using Mailtrap;
using Mailtrap.AccountAccesses;
using Mailtrap.AccountAccesses.Models;
using Mailtrap.Accounts;
using Mailtrap.Accounts.Models;
using Mailtrap.Attachments;
using Mailtrap.Attachments.Models;
using Mailtrap.Billing.Models;
using Mailtrap.Email;
using Mailtrap.Email.Requests;
using Mailtrap.Emails;
using Mailtrap.Emails.Models;
using Mailtrap.Emails.Requests;
using Mailtrap.Extensions.DependencyInjection;
using Mailtrap.Inboxes;
using Mailtrap.Inboxes.Models;
using Mailtrap.Inboxes.Requests;
using Mailtrap.Models;
using Mailtrap.Permissions.Models;
using Mailtrap.Projects;
using Mailtrap.Projects.Models;
using Mailtrap.Projects.Requests;
using Mailtrap.SendingDomains;
using Mailtrap.SendingDomains.Models;
using Mailtrap.SendingDomains.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


/// <summary>
/// Various examples of the Mailtrap API usage
/// </summary>
internal sealed class Program
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private static IMailtrapClient s_mailtrapClient;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.


    private static async Task Main(string[] args)
    {
        HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);

        IConfigurationSection config = hostBuilder.Configuration.GetSection("Mailtrap");

        hostBuilder.Services.AddMailtrapClient(config);

        using IHost host = hostBuilder.Build();

        ILogger logger = host.Services.GetRequiredService<ILogger<Program>>();

        try
        {
            s_mailtrapClient = host.Services.GetRequiredService<IMailtrapClient>();

            // Get all accounts available for the token
            IList<Account> accounts = await s_mailtrapClient
                .Accounts()
                .GetAll();

            var accountId = 1917378;
            Account? account = accounts.FirstOrDefault(a => a.Id == accountId);

            if (account is null)
            {
                logger.LogWarning("No account found.");

                return;
            }
            else
            {
                logger.LogInformation("Account: {Account}", account);

                // Get resource for specific account
                IAccountResource accountResource = s_mailtrapClient.Account(account.Id);

                await ProcessAccount(accountResource, logger);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred during API call.");
            Environment.FailFast(ex.Message);
            throw;
        }
    }

    private static async Task ProcessAccount(IAccountResource accountResource, ILogger logger)
    {
        // await ProcessAccess(accountResource, logger);

        await ProcessPermissions(accountResource, logger);

        await ProcessBilling(accountResource, logger);

        await ProcessDomains(accountResource, logger);

        await ProcessProjects(accountResource, logger);
    }

    private static async Task ProcessAccess(IAccountResource accountResource, ILogger logger)
    {
        // Paid account needed for some operations

        var filter = new AccountAccessFilter();
        var inboxId = 2854500;
        filter.InboxIds.Add(inboxId);

        // Fetch accesses
        IList<AccountAccess> accesses = await accountResource
            .Accesses()
            .Fetch(filter);

        var userId = 4322;

        AccountAccess? userAccess = accesses.FirstOrDefault(a =>
            SpecifierType.User.Equals(a.SpecifierType) &&
            a.Specifier?.Id == userId);

        if (userAccess is null)
        {
            logger.LogWarning("No access for user with ID {UserID}.", userId);
            return;
        }

        logger.LogInformation("User Access: {UserAccess}", userAccess);

        // Get resource for specific account access
        IAccountAccessResource userAccessResource = accountResource.Access(userAccess.Id);

        // var updateRequest = new UpdatePermissionsRequest();
        //updateRequest.Permissions.Add(new UpdatePermissionsRequestDetails
        //{
        //    Id = access.Id,
        //    Type = "account",
        //    AccessLevel = AccessLevel.Admin
        //});
    }

    private static async Task ProcessPermissions(IAccountResource accountResource, ILogger logger)
    {
        // Get resource permissions for account
        IList<ResourcePermissions> permissions = await accountResource
            .Permissions()
            .GetForResources();

        logger.LogInformation("Resource Permissions: {ResourcePermissions}", permissions);
    }

    private static async Task ProcessBilling(IAccountResource accountResource, ILogger logger)
    {
        // Get billing usage for account
        BillingUsage billing = await accountResource
            .Billing()
            .GetUsage();

        logger.LogInformation("Billing Usage: {BillingUsage}", billing);
    }

    private static async Task ProcessDomains(IAccountResource accountResource, ILogger logger)
    {
        var domainName = "demomailtrap.com";

        // Get resource for domains collection
        ISendingDomainCollectionResource domainsResource = accountResource.SendingDomains();

        // Get all sending domains for account
        IList<SendingDomain> domains = await domainsResource.GetAll();

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

    private static async Task ProcessProjects(IAccountResource accountResource, ILogger logger)
    {
        var projectName = "My Test Project";

        // Get resource for projects collection
        IProjectCollectionResource projectsResource = accountResource.Projects();

        // Get all projects for account
        IList<Project> projects = await projectsResource.GetAll();

        Project? project = projects
            .FirstOrDefault(p => string.Equals(p.Name, projectName, StringComparison.OrdinalIgnoreCase));

        if (project is null)
        {
            logger.LogWarning("No project found. Creating.");

            // Create project
            var createProjectRequest = new CreateProjectRequest(projectName);
            project = await projectsResource.Create(createProjectRequest);
        }
        else
        {
            logger.LogInformation("Project found.");
        }

        // Get resource for specific project
        IProjectResource projectResource = accountResource.Project(project.Id);

        // Get details
        project = await projectResource.GetDetails();
        logger.LogInformation("Project: {Project}", project);

        // Process inboxes
        await ProcessInboxes(accountResource, logger, project.Id);

        // Update project details
        var updateProjectRequest = new UpdateProjectRequest("Updated Project Name");
        Project updatedProject = await projectResource.Update(updateProjectRequest);
        logger.LogInformation("Updated Project: {Project}", updatedProject);

        // Delete project
        // Beware that project resource becomes invalid after deletion and should not be used anymore
        DeletedProject deletedProject = await projectResource.Delete();
        logger.LogInformation("Deleted Project: {Project}", deletedProject);
    }

    private static async Task ProcessInboxes(IAccountResource accountResource, ILogger logger, long projectId)
    {
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

        // Toggle email for inbox
        // Inbox updatedInbox = await inboxResource.ToggleEmailAddress();
        Inbox updatedInbox = inbox;

        // Process messages
        await ProcessMessages(inboxResource, logger);

        // Mark all messages in the inbox as read
        updatedInbox = await inboxResource.MarkAsRead();

        // Update inbox details
        var updateInboxRequest = new UpdateInboxRequest
        {
            Name = "Updated Inbox Name"
        };
        updatedInbox = await inboxResource.Update(updateInboxRequest);

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

    private static async Task ProcessMessages(IInboxResource inboxResource, ILogger logger)
    {
        await Send(inboxResource);

        // Get resource for message collection
        IEmailCollectionResource messagesResource = inboxResource.Messages();

        // Fetch messages from the inbox
        var messageFilter = new EmailMessageFilter
        {
            SearchFilter = "Supervision request"
        };
        IList<EmailMessage> messages = await messagesResource.Fetch(messageFilter);

        IEmailResource messageResource;

        EmailMessage? message = messages.FirstOrDefault();
        if (message is not null)
        {
            // Get resource for message
            messageResource = inboxResource.Message(message.Id);

            // Get message details
            message = await messageResource.GetDetails();
            logger.LogInformation("Message: {Message}", message);

            // Processing message attachments
            await ProcessAttachments(messageResource, logger);
        }

        // Fetch messages from the inbox
        messageFilter = new EmailMessageFilter
        {
            SearchFilter = "Greetings"
        };
        messages = await messagesResource.Fetch(messageFilter);

        if (messages.Count == 0)
        {
            logger.LogWarning("No greetings messages found.");
        }
        else
        {
            logger.LogInformation("Found {Count} greetings messages.", messages.Count);
        }

        // Another fetch
        messageFilter = new EmailMessageFilter
        {
            SearchFilter = "hero.bill"
        };
        messages = await messagesResource.Fetch(messageFilter);

        message = messages.FirstOrDefault();

        if (message is null)
        {
            logger.LogWarning("No messages found.");
            return;
        }

        // Get resource for message
        messageResource = inboxResource.Message(message.Id);

        // Get message details
        message = await messageResource.GetDetails();
        logger.LogInformation("Message: {Message}", message);

        // Get message headers
        EmailMessageHeaders headers = await messageResource.GetHeaders();
        logger.LogInformation("Message headers: {Headers}", headers.Headers);

        // Get raw message content
        string rawMessageContent = await messageResource.AsRaw();
        logger.LogInformation("Raw message:\n{Message}", rawMessageContent);

        // Get EML message content
        string emlMessageContent = await messageResource.AsEml();
        logger.LogInformation("EML message:\n{Message}", emlMessageContent);

        if (message.TextBodySize > 0)
        {
            // Get plain text message body
            string textMessageBody = await messageResource.GetTextBody();
            logger.LogInformation("Plain text message body:\n{Message}", textMessageBody);
        }

        if (message.HtmlBodySize > 0)
        {
            // Get HTML message body
            string htmlMessageBody = await messageResource.GetHtmlBody();
            logger.LogInformation("HTML message body:\n{Message}", htmlMessageBody);

            // Get HTML message source
            string htmlMessageSource = await messageResource.GetHtmlSource();
            logger.LogInformation("HTML message source:\n{Message}", htmlMessageSource);

            // Get HTML analysis report for message 
            EmailMessageHtmlReport htmlReport = await messageResource.GetHtmlAnalysisReport();
            logger.LogInformation("HTML analysis report: {Report}", htmlReport.Report);
        }

        // Get spam report for message 
        EmailMessageSpamReport spamReport = await messageResource.GetSpamReport();
        logger.LogInformation("Spam report: {Report}", spamReport.Report);

        // Update message details
        var updateMessageRequest = new UpdateEmailMessageRequest(true);
        EmailMessage updatedMessage = await messageResource.Update(updateMessageRequest);
        logger.LogInformation("Updated Message: {Message}", updatedMessage);

        // // Forward message - available for paid accounts only
        // var forwardMessageRequest = new ForwardEmailMessageRequest("forward@domain.com");
        // ForwardedEmailMessage forwardedMessage = await messageResource.Forward(forwardMessageRequest);
        // logger.LogInformation("Message forwarded: {Forward}", forwardedMessage.Message);

        // Delete message
        // Beware that resource becomes invalid after deletion and should not be used anymore
        EmailMessage deletedMessage = await messageResource.Delete();
        logger.LogInformation("Deleted Message: {Message}", deletedMessage);
    }

    private static async Task Send(IInboxResource inboxResource)
    {
        Inbox inbox = await inboxResource.GetDetails();

        IEmailClient emailClient = s_mailtrapClient.Test(inbox.Id);

        SendEmailRequest sendEmailRequest = SendEmailRequest
            .Create()
            .From("john.doe@demomailtrap.com", "John Doe")
            .To("hero.bill@galaxy.net")
            .To("star.lord@galaxy.net")
            .Subject("Greetings")
            .Text("Hi guys,\n\nWelcome to our Milky Way Galaxy.\n\nBest regards, John.");

        await emailClient.Send(sendEmailRequest);

        sendEmailRequest = SendEmailRequest
            .Create()
            .From("john.doe@demomailtrap.com", "John Doe")
            .To("hero.bill@galaxy.net")
            .Cc("star.lord@galaxy.net")
            .Subject("Invitation to Earth")
            .Html("<h3>Dear Bill</h3>,<p>It will be a great pleasure to see you on our blue planet next weekend.</p><p>Best regards, <b>John.</b></p>");

        await emailClient.Send(sendEmailRequest);

        sendEmailRequest = SendEmailRequest
            .Create()
            .From("john.doe@demomailtrap.com", "John Doe")
            .To("fury.nicolas@avengers.gov")
            .Subject("Supervision request")
            .Text("Dear Mr. Fury,\n\nKindly assist with supervision on few new guests that are arriving to Earth next weekend.\n\nBest regards, John.");

        var file = "Attachment.txt";
        var bytes = await File.ReadAllBytesAsync(file);
        var fileContent = Convert.ToBase64String(bytes);

        sendEmailRequest.Attach(
            content: fileContent,
            fileName: file,
            disposition: DispositionType.Attachment,
            mimeType: MediaTypeNames.Text.Plain);

        await emailClient.Send(sendEmailRequest);
    }

    private static async Task ProcessAttachments(IEmailResource messageResource, ILogger logger)
    {
        // Get resource for attachments collection
        IAttachmentCollectionResource attachmentsResource = messageResource.Attachments();

        var attachmentFilter = new EmailAttachmentFilter
        {
            Disposition = DispositionType.Attachment
        };

        IList<EmailAttachment> attachments = await attachmentsResource.Fetch(attachmentFilter);

        EmailAttachment? attachment = attachments.FirstOrDefault();

        if (attachment is null)
        {
            logger.LogWarning("No attachments found.");
            return;
        }

        // Get resource for specific attachment
        IAttachmentResource attachmentResource = messageResource.Attachment(attachment.Id);

        // Get attachment details
        attachment = await attachmentResource.GetDetails();
        logger.LogInformation("Attachment: {Attachment}", attachment);
    }
}
