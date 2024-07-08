// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System.Diagnostics.CodeAnalysis;
using System.Net;
using Mailtrap;
using Mailtrap.Email.Requests;
using Mailtrap.Email.Responses;
using Microsoft.Extensions.DependencyInjection;


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
            // Recreating it each time when MailtrapClient insatnce is needed can be resource consuming.

            // Meanwile, instances of MailtrapClient, produced by the factory,
            // can be freely used in any manner, long-living, unit-of-work, etc.

            using MailtrapClientFactory factory = AdvancedHttpClientConfiguration(apiKey);

            IMailtrapClient client = factory.CreateClient();

            SendEmailRequest request = SendEmailRequestBuilder
                .Email()
                .From("john.doe@demomailtrap.com", "John Doe")
                .To("hero.bill@galaxy.net")
                .Subject("Invitation to Earth")
                .Text("Dear Bill,\nIt will be a great pleasure to see you on our blue planet next weekend.\nBest regards, John.");

            SendEmailResponse? response = await client.SendAsync(request).ConfigureAwait(false);

            Console.WriteLine("Email has been sent successfully. MessageId: {0}", response?.MessageIds?.FirstOrDefault());
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while sending email:\n{0}", ex);
            Environment.FailFast(ex.Message);
            throw;
        }
    }


    private static MailtrapClientFactory BasicUsage(string apiKey)
    {
        return new MailtrapClientFactory(apiKey);
    }

    private static MailtrapClientFactory CustomHttpClient(string apiKey)
    {
        using var httpMessageHandler = new HttpClientHandler()
        {
            Proxy = new WebProxy("10.0.0.1", 8080),
            CheckCertificateRevocationList = true
        };

        using var httpClient = new HttpClient(httpMessageHandler);

        return new MailtrapClientFactory(apiKey, httpClient);
    }

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
