// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System.Net;
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

var host = hostBuilder.Build();

await host.RunAsync().ConfigureAwait(false);
