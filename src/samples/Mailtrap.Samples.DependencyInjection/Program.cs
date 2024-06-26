// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System.Net;
using Mailtrap;
using Mailtrap.Email.Requests;
using Mailtrap.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var hostBuilder = Host.CreateApplicationBuilder();

hostBuilder.Services.AddMailtrapClient(builder =>
{
    builder.ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new HttpClientHandler()
        {
            Proxy = new WebProxy("proxy.mailtrap.io", 8080)
        };
    });
});

using var host = hostBuilder.Build();

var request = SendEmailRequestBuilder
    .Email()
    .From("john.doe@demomailtrap.com", "John Doe")
    .To("hero.bill@galaxy.net")
    .Subject("Invitation to Earth")
    .Text("Dear Bill,\nIt will be a great pleasure to see you on our blue planet next weekend.\nBest regards, John.");

var mailtrapClient = host.Services.GetRequiredService<IMailtrapClient>();

await mailtrapClient.SendAsync(request).ConfigureAwait(false);

