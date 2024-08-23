// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System.Diagnostics.CodeAnalysis;
using System.Net;
using Mailtrap;
using Mailtrap.Email;
using Mailtrap.Email.Requests;
using Mailtrap.Email.Responses;
using Microsoft.Extensions.DependencyInjection;


/// <summary>
/// Example demonstrating usage of factory to create  and consume MailtrapClient instances.
/// </summary>
[SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Example")]
internal sealed class Program
{
    private static async Task Main()
    {
        try
        {
            // For sure you should not hardcode apiKey for security reasons,
            // and use environment variables or configuration files instead.
            // But for the sake of simplicity, we will use hardcoded value in this example.
            var apiKey = "<API_KEY>";

            // Instance of MailtrapClientFactory should be used as singleton -
            // since it is using HttpClientFactory under the hood to create
            // transient HttpClient instances and pass them to MailtrapClient instances.
            // Recreating it each time when MailtrapClient instance is needed
            // can be resource consuming.

            // Instances of MailtrapClient, produced by the factory,
            // can be freely used in any manner, long-living, unit-of-work, etc.
            // Meanwhile, they are not thread-safe and are not intended for multithreaded use,
            // thus singletons should be used with caution.

            using MailtrapClientFactory factory = BasicUsage(apiKey);

            IMailtrapClient client = factory.CreateClient();

            var inboxId = 3322;
            ISendClient sendClient = client.Test(inboxId);

            SendEmailRequest request = SendEmailRequest
                .Create()
                .From("john.doe@demomailtrap.com", "John Doe")
                .To("hero.bill@galaxy.net")
                .Subject("Invitation to Earth")
                .Text("Dear Bill,\n\nIt will be a great pleasure to see you on our blue planet next weekend.\n\nBest regards, John.");

            SendEmailResponse? response = await sendClient.SendEmail(request).ConfigureAwait(false);

            Console.WriteLine("Email has been sent successfully. MessageId: {0}", response?.MessageIds?.FirstOrDefault());
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while sending email:\n{0}", ex);
            Environment.FailFast(ex.Message);
            throw;
        }
    }


    /// <summary>
    /// Simplest case
    /// </summary>
    private static MailtrapClientFactory BasicUsage(string apiKey)
    {
        return new MailtrapClientFactory(apiKey);
    }


    /// <summary>
    /// Case with external standalone HttpClient instance
    /// </summary>
    private static MailtrapClientFactory StandaloneHttpClient(string apiKey)
    {
        using var httpMessageHandler = new HttpClientHandler()
        {
            Proxy = new WebProxy("10.0.0.1", 8080),
            CheckCertificateRevocationList = true
        };

        using var httpClient = new HttpClient(httpMessageHandler);

        return new MailtrapClientFactory(apiKey, httpClient);
    }

    /// <summary>
    /// Case with advanced HttpClient configuration
    /// </summary>
    private static MailtrapClientFactory AdvancedHttpClientConfiguration(string apiKey)
    {
        return new MailtrapClientFactory(apiKey, builder =>
        {
            builder.ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler()
                {
                    Proxy = new WebProxy("proxy.mailtrap.io", 8080),
                    CheckCertificateRevocationList = true
                };
            });

            builder.AddDefaultLogger();
        });
    }
}
