// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System.Net;
using Mailtrap;
using Mailtrap.Email.Requests;
using Mailtrap.Email.Responses;
using Microsoft.Extensions.DependencyInjection;


try
{
    // For sure you should not hardcode apiKey for security reasons, and use environment variables or configuration files instead.
    // But for the sake of simplicity, we will use hardcoded value in this example.
    var apiKey = "<API_KEY>";

    SendEmailRequest request = SendEmailRequestBuilder
        .Email()
        .From("john.doe@demomailtrap.com", "John Doe")
        .To("hero.bill@galaxy.net")
        .Subject("Invitation to Earth")
        .Text("Dear Bill,\nIt will be a great pleasure to see you on our blue planet next weekend.\nBest regards, John.");

    await BasicUsage(apiKey, request).ConfigureAwait(false);

    await CustomHttpClient(apiKey, request).ConfigureAwait(false);

    await CustomHttpClientConfiguration(apiKey, request).ConfigureAwait(false);
}
catch (Exception ex)
{
    Console.WriteLine("Error during send: {0}", ex);
    throw;
}


static async Task BasicUsage(string apiKey, SendEmailRequest request)
{
    using var client = new MailtrapClient(apiKey);

    SendEmailResponse? response = await client.SendAsync(request).ConfigureAwait(false);

    Console.WriteLine("Email has been sent successfully. MessageId: {0}", response?.MessageIds?.FirstOrDefault());
}

static async Task CustomHttpClient(string apiKey, SendEmailRequest request)
{
    using var httpMessageHandler = new HttpClientHandler()
    {
        Proxy = new WebProxy("10.0.0.1", 8080),
        CheckCertificateRevocationList = true
    };

    using var httpClient = new HttpClient(httpMessageHandler);

    using var client = new MailtrapClient(apiKey, httpClient);

    SendEmailResponse? response = await client.SendAsync(request).ConfigureAwait(false);

    Console.WriteLine("Email has been sent successfully. MessageId: {0}", response?.MessageIds?.FirstOrDefault());
}

static async Task CustomHttpClientConfiguration(string apiKey, SendEmailRequest request)
{
    using var client = new MailtrapClient(apiKey, builder =>
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

    SendEmailResponse? response = await client.SendAsync(request).ConfigureAwait(false);

    Console.WriteLine("Email has been sent successfully. MessageId: {0}", response?.MessageIds?.FirstOrDefault());
}
