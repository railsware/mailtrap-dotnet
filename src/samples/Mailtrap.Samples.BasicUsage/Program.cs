// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System.Net;
using Mailtrap;
using Mailtrap.Email.Requests;


try
{
    // For sure you should not hardcode apiKey for security reasons, and use environment variables or configuration files instead.
    // But for the sake of simplicity, we will use hardcoded value in this example.
    var apiKey = "<API_KEY>";

    var request = SendEmailRequestBuilder
        .Email()
        .From("john.doe@demomailtrap.com", "John Doe")
        .To("hero.bill@galaxy.net")
        .Subject("Invitation to Earth")
        .Text("Dear Bill,\nIt will be a great pleasure to see you on our blue planet next weekend.\nBest regards, John.");

    await BasicUsage(apiKey, request).ConfigureAwait(false);

    await CustomBaseUrl(apiKey, request).ConfigureAwait(false);

    await CustomHttpClient(apiKey, request).ConfigureAwait(false);
}
catch (Exception ex)
{
    Console.WriteLine("Error during send: {0}", ex);
    throw;
}


static async Task BasicUsage(string apiKey, SendEmailRequest request)
{
    using var client = new MailtrapClient(apiKey);

    var response = await client.SendAsync(request).ConfigureAwait(false);

    Console.WriteLine("Email has been sent successfully. MessageId: {0}", response?.MessageIds?.FirstOrDefault());
}

static async Task CustomBaseUrl(string apiKey, SendEmailRequest request)
{
    using var client = new MailtrapClient(apiKey, "https://mock.mailtrap.io/");

    var response = await client.SendAsync(request).ConfigureAwait(false);

    Console.WriteLine("Email has been sent successfully to the mock endpoint. MessageId: {0}", response?.MessageIds?.FirstOrDefault());
}

static async Task CustomHttpClient(string apiKey, SendEmailRequest request)
{
    using var httpMessageHandler = new HttpClientHandler()
    {
        Proxy = new WebProxy("10.0.0.1", 8080)
    };

    using var httpClient = new HttpClient();

    using var client = new MailtrapClient(apiKey, httpClient);

    var response = await client.SendAsync(request).ConfigureAwait(false);

    Console.WriteLine("Email has been sent successfully to the mock endpoint. MessageId: {0}", response?.MessageIds?.FirstOrDefault());
}
