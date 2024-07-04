// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System.Net;
using Mailtrap;
using Mailtrap.Email.Requests;
using Mailtrap.Email.Responses;
using Mailtrap.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


internal sealed class Program
{
    private static async Task Main(string[] args)
    {
        // Default host builder helper loads configuration from appsettings.json,
        // appsettings.{Environment}.json, environment variables, user secrets and command-line arguments.
        // Alternatively, you could provide in-memory configuration using hostBuilder.Configuration.AddInMemoryCollection().

        HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);

        hostBuilder.Services.AddMailtrapClient(
            hostBuilder.Configuration.GetSection("Mailtrap"),
            httpClientbuilder =>
            {
                httpClientbuilder.ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler()
                    {
                        Proxy = new WebProxy("proxy.mailtrap.io", 8080),
                        CheckCertificateRevocationList = true
                    };
                });

                httpClientbuilder.AddDefaultLogger();
            });


        using IHost host = hostBuilder.Build();

        ILogger logger = host.Services.GetRequiredService<ILogger<Program>>();

        try
        {
            SendEmailRequest request = SendEmailRequestBuilder
                .Email()
                .From("john.doe@demomailtrap.com", "John Doe")
                .To("hero.bill@galaxy.net")
                .Subject("Invitation to Earth")
                .Text("Dear Bill,\nIt will be a great pleasure to see you on our blue planet next weekend.\nBest regards, John.");

            IMailtrapClient mailtrapClient = host.Services.GetRequiredService<IMailtrapClient>();

            SendEmailResponse? response = await mailtrapClient.SendAsync(request).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while sending email.");
            Environment.FailFast(ex.Message);
            throw;
        }
    }
}
