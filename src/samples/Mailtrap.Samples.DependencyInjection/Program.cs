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


HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder();

hostBuilder.Services.AddMailtrapClient(configureHttpClient: builder =>
{
    builder.ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new HttpClientHandler()
        {
            Proxy = new WebProxy("proxy.mailtrap.io", 8080)
        };
    });

    builder.AddDefaultLogger();
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
    logger.LogError(ex, "An error occurred while sending an email.");
    throw;
}

