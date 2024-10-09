// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Mailtrap;
using Mailtrap.AccountAccesses;
using Mailtrap.AccountAccesses.Models;
using Mailtrap.Accounts;
using Mailtrap.Accounts.Models;
using Mailtrap.Billing.Models;

// using Mailtrap.Extensions.DependencyInjection;
using Mailtrap.Core.Responses;
using Mailtrap.Email.Models;
using Mailtrap.Emails;
using Mailtrap.Emails.Models;
using Mailtrap.Emails.Requests;
using Mailtrap.Inboxes;
using Mailtrap.Inboxes.Models;
using Mailtrap.Inboxes.Requests;
using Mailtrap.MessageAttachments;
using Mailtrap.MessageAttachments.Models;
using Mailtrap.Projects;
using Mailtrap.Projects.Models;
using Mailtrap.Projects.Requests;
using Mailtrap.SendingDomains;
using Mailtrap.SendingDomains.Models;
using Mailtrap.SendingDomains.Requests;

// using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


/// <summary>
/// Various examples of the Mailtrap API usage
/// </summary>
internal sealed class Program
{
    private static async Task Main(string[] args)
    {
        HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);

        // IConfigurationSection config = hostBuilder.Configuration.GetSection("Mailtrap");

        // hostBuilder.Services.AddMailtrapClient(config);

        using IHost host = hostBuilder.Build();

        ILogger logger = host.Services.GetRequiredService<ILogger<Program>>();

        try
        {
            IMailtrapClient mailtrapClient = host.Services.GetRequiredService<IMailtrapClient>();

            // Get all accounts available for the token
            CollectionResponse<Account> accounts = await mailtrapClient
                .Accounts()
                .GetAll()
                .ConfigureAwait(false);

            var accountId = 123;
            Account? account = accounts.Data.FirstOrDefault(a => a.Id == accountId);

            if (account is null)
            {
                logger.LogWarning("No account found.");

                return;
            }
            else
            {
                logger.LogInformation("Account: {Account}", account);

                // Get resource for specific account
                IAccountResource accountResource = mailtrapClient.Account(account.Id);

                await ProcessAccount(accountResource, logger).ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while sending email.");
            Environment.FailFast(ex.Message);
            throw;
        }
    }

    private static async Task ProcessAccount(IAccountResource accountResource, ILogger logger)
    {
        await ProcessAccess(accountResource, logger).ConfigureAwait(false);

        await ProcessBilling(accountResource, logger).ConfigureAwait(false);

        await ProcessDomains(accountResource, logger).ConfigureAwait(false);

        await ProcessProjects(accountResource, logger).ConfigureAwait(false);
    }

    private static async Task ProcessAccess(IAccountResource accountResource, ILogger logger)
    {
        // Get accesses
        var domainId = 123;
        var filter = new AccountAccessFilter();
        filter.DomainIds.Add(domainId);

        CollectionResponse<AccountAccess> accesses = await accountResource
            .Accesses()
            .Fetch(filter)
            .ConfigureAwait(false);

        var userId = 4322;

        AccountAccess? userAccess = accesses.Data.FirstOrDefault(a =>
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

    private static async Task ProcessBilling(IAccountResource accountResource, ILogger logger)
    {
        // Get billing usage for account
        Response<BillingUsage> billing = await accountResource
            .Billing()
            .GetUsage()
            .ConfigureAwait(false);

        logger.LogInformation("Billing Usage: {BillingUsage}", billing.Data);
    }

    private static async Task ProcessDomains(IAccountResource accountResource, ILogger logger)
    {
        var domainName = "example.com";

        // Get resource for domains collection
        ISendingDomainCollectionResource domainsResource = accountResource.SendingDomains();

        // Get all sending domains for account
        CollectionResponse<SendingDomain> domains = await domainsResource
            .GetAll()
            .ConfigureAwait(false);

        SendingDomain? domain = domains.Data
            .FirstOrDefault(d => string.Equals(d.DomainName, domainName, StringComparison.OrdinalIgnoreCase));

        if (domain is null)
        {
            logger.LogWarning("No sending domain found. Creating.");

            // Create sending domain
            var createDomainRequest = new CreateSendingDomainRequest
            {
                Domain = new CreateSendingDomainRequestDetails
                {
                    DomainName = domainName
                }
            };
            Response<SendingDomain> createdDomain = await domainsResource
                .Create(createDomainRequest)
                .ConfigureAwait(false);

            domain = createdDomain.Data;
        }
        else
        {
            logger.LogInformation("Sending domain found.");
        }

        logger.LogInformation("Sending Domain: {SendingDomain}", domain);

        // Get resource for specific sending domain
        ISendingDomainResource domainResource = accountResource.SendingDomain(domain.Id);

        // Sending domain instructions
        var instructionsRrequest = new SendingDomainInstructionsRequest("admin@domain.com");
        await domainResource
            .SendInstructions(instructionsRrequest)
            .ConfigureAwait(false);
    }

    private static async Task ProcessProjects(IAccountResource accountResource, ILogger logger)
    {
        var projectName = "Sample Project";

        // Get resource for projects collection
        IProjectCollectionResource projectsResource = accountResource.Projects();

        // Get all projects for account
        CollectionResponse<Project> projects = await projectsResource
            .GetAll()
            .ConfigureAwait(false);

        Project? project = projects.Data
            .FirstOrDefault(p => string.Equals(p.Name, projectName, StringComparison.OrdinalIgnoreCase));

        if (project is null)
        {
            logger.LogWarning("No project found. Creating.");

            // Create project
            var createProjectRequest = new CreateProjectRequest
            {
                Project = new CreateProjectRequestDetails
                {
                    Name = projectName
                }
            };
            Response<Project> createdProject = await projectsResource
                .Create(createProjectRequest)
                .ConfigureAwait(false);

            project = createdProject.Data;
        }
        else
        {
            logger.LogInformation("Project found.");
        }

        logger.LogInformation("Project: {Project}", project);

        await ProcessInboxes(accountResource, logger, project.Id).ConfigureAwait(false);

        // Get resource for specific project
        IProjectResource projectResource = accountResource.Project(project.Id);

        // Update project details
        var updateProjectRequest = new UpdateProjectRequest
        {
            Project = new UpdateProjectRequestDetails
            {
                Name = "Updated Project Name"
            }
        };
        Response<Project> updatedProject = await projectResource
            .Update(updateProjectRequest)
            .ConfigureAwait(false);

        // Get project details
        // Just for demo purposes, response from the update already contains updated info
        updatedProject = await projectResource
            .GetDetails()
            .ConfigureAwait(false);

        // Delete project
        // Beware that project resource becomes invalid after deletion and should not be used anymore
        Response<DeletedProject> deletedProject = await projectResource
            .Delete()
            .ConfigureAwait(false);

        logger.LogInformation("Deleted Project: {Deleted Project}", deletedProject.Data);
    }

    private static async Task ProcessInboxes(IAccountResource accountResource, ILogger logger, long projectId)
    {
        var inboxName = "Sample Inbox";

        // Get resource for inbox collection
        IInboxCollectionResource inboxesResource = accountResource.Inboxes();

        // Get all inboxes for account
        CollectionResponse<Inbox> inboxes = await inboxesResource
            .GetAll()
            .ConfigureAwait(false);

        Inbox? inbox = inboxes.Data
            .FirstOrDefault(i => string.Equals(i.Name, inboxName, StringComparison.OrdinalIgnoreCase));

        if (inbox is null)
        {
            logger.LogWarning("No inbox found. Creating.");

            // Create inbox
            var createInboxRequest = new CreateInboxRequest(projectId)
            {
                Inbox = new CreateInboxRequestDetails
                {
                    Name = inboxName
                }
            };
            Response<Inbox> createdInbox = await inboxesResource
                .Create(createInboxRequest)
                .ConfigureAwait(false);

            inbox = createdInbox.Data;
        }
        else
        {
            logger.LogInformation("Inbox found.");
        }

        logger.LogInformation("Inbox: {Inbox}", inbox);

        // Get resource for specific inbox
        IInboxResource inboxResource = accountResource.Inbox(inbox.Id);

        // Toggle email for inbox
        Response<Inbox> updatedInbox = await inboxResource
            .ToggleEmailAddress()
            .ConfigureAwait(false);

        await ProcessMessages(inboxResource, logger).ConfigureAwait(false);

        // Mark all messages in the inbox as read
        updatedInbox = await inboxResource
            .MarkAsRead()
            .ConfigureAwait(false);

        // Update inbox details
        var updateInboxRequest = new UpdateInboxRequest
        {
            Inbox = new UpdateInboxRequestDetails
            {
                Name = "Updated Inbox Name"
            }
        };
        updatedInbox = await inboxResource
            .Update(updateInboxRequest)
            .ConfigureAwait(false);

        // Get inbox details
        // Just for demo purposes, response from the update already contains updated info
        updatedInbox = await inboxResource
            .GetDetails()
            .ConfigureAwait(false);

        // Reset email address for inbox
        updatedInbox = await inboxResource
            .ResetEmailAddress()
            .ConfigureAwait(false);

        // Reset credentials for inbox
        updatedInbox = await inboxResource
            .ResetCredentials()
            .ConfigureAwait(false);

        // Delete inbox
        // Beware that resource becomes invalid after deletion and should not be used anymore
        updatedInbox = await inboxResource
            .Delete()
            .ConfigureAwait(false);
    }

    private static async Task ProcessMessages(IInboxResource inboxResource, ILogger logger)
    {
        // Get resource for message collection
        IEmailMessageCollectionResource messagesResource = inboxResource.Messages();

        // Fetch messages from the inbox
        var messageFilter = new EmailMessageFilter
        {
            SearchFilter = "Greetings"
        };

        CollectionResponse<EmailMessage> messages = await messagesResource
            .Fetch(messageFilter)
            .ConfigureAwait(false);

        EmailMessage? message = messages.Data.FirstOrDefault();

        if (message is null)
        {
            logger.LogWarning("No messages found.");
            return;
        }

        logger.LogInformation("Message: {Message}", message);

        // Get resource for message
        IEmailMessageResource messageResource = inboxResource.Message(message.Id);

        // Get message headers
        Response<EmailMessageHeaders> headers = await messageResource
            .GetHeaders()
            .ConfigureAwait(false);
        logger.LogInformation("Message headers: {Headers}", headers.Data.Headers);

        // Get raw message content
        Response<EmailMessageRaw> rawMessageContent = await messageResource
            .AsRaw()
            .ConfigureAwait(false);
        logger.LogInformation("Raw message: {Message}", rawMessageContent.Data.Raw);

        // Get EML message content
        Response<EmailMessageEml> emlMessageContent = await messageResource
            .AsEml()
            .ConfigureAwait(false);
        logger.LogInformation("EML message: {Message}", emlMessageContent.Data.Eml);

        // Get plain text message body
        Response<EmailMessageTextBody> textMessageBody = await messageResource
            .GetTextBody()
            .ConfigureAwait(false);
        logger.LogInformation("Plain text message body: {Message}", textMessageBody.Data.TextBody);

        // Get HTML message body
        Response<EmailMessageHtmlBody> htmlMessageBody = await messageResource
            .GetHtmlBody()
            .ConfigureAwait(false);
        logger.LogInformation("HTML message body: {Message}", htmlMessageBody.Data.HtmlBody);

        // Get HTML message source
        Response<EmailMessageHtmlSource> htmlMessageSource = await messageResource
            .GetHtmlSource()
            .ConfigureAwait(false);
        logger.LogInformation("HTML message source: {Message}", htmlMessageSource.Data.HtmlSource);

        // Get HTML analysis report for message 
        Response<EmailMessageHtmlReport> htmlReport = await messageResource
            .GetHtmlAnalysisReport()
            .ConfigureAwait(false);
        logger.LogInformation("HTML analysis report: {Report}", htmlReport.Data.Report);

        // Get spam report for message 
        Response<EmailMessageSpamReport> spamReport = await messageResource
            .GetSpamReport()
            .ConfigureAwait(false);
        logger.LogInformation("Spam report: {Report}", spamReport.Data.Report);

        // Processing message attachments
        await ProcessAttachments(messageResource, logger).ConfigureAwait(false);

        // Update message details
        var updateMessageRequest = new UpdateEmailMessageRequest
        {
            Message = new UpdateEmailMessageRequestDetails
            {
                IsRead = true
            }
        };
        Response<EmailMessage> updatedMessage = await messageResource
            .Update(updateMessageRequest)
            .ConfigureAwait(false);
        logger.LogInformation("Updated Message: {Message}", updatedMessage.Data);

        // Forward message
        var forwardMessageRequest = new ForwardEmailMessageRequest()
        {
            Email = "forward@domain.com"
        };
        Response<ForwardedEmailMessage> forwardedMessage = await messageResource
            .Forward(forwardMessageRequest)
            .ConfigureAwait(false);
        logger.LogInformation("Message forwarded: {Forward}", forwardedMessage.Data.Message);

        // Get message details
        updatedMessage = await messageResource
            .GetDetails()
            .ConfigureAwait(false);
        logger.LogInformation("Message after forward: {Message}", updatedMessage.Data);

        // Delete message
        // Beware that resource becomes invalid after deletion and should not be used anymore
        _ = await messageResource
            .Delete()
            .ConfigureAwait(false);
    }

    private static async Task ProcessAttachments(IEmailMessageResource messageResource, ILogger logger)
    {
        // Get resource for attachments collection
        IAttachmentCollectionResource attachmentsResource = messageResource.Attachments();

        var attachmentFilter = new MessageAttachmentFilter
        {
            Disposition = DispositionType.Attachment
        };

        CollectionResponse<MessageAttachment> attachments = await attachmentsResource
            .Fetch(attachmentFilter)
            .ConfigureAwait(false);

        MessageAttachment? attachment = attachments.Data.FirstOrDefault();

        if (attachment is null)
        {
            logger.LogWarning("No attachments found.");
        }
        else
        {
            logger.LogInformation("Attachment: {Attachment}", attachment);

            // Get resource for specific attachment
            IAttachmentResource attachmentResource = messageResource.Attachment(attachment.Id);

            // Get attachment details
            Response<MessageAttachment> attachmentDetails = await attachmentResource
                .GetDetails()
                .ConfigureAwait(false);

            logger.LogInformation("Attachment: {Attachment}", attachmentDetails.Data);
        }
    }
}
