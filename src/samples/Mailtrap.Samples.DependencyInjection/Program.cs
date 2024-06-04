// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Mailtrap.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var hostBuilder = Host.CreateApplicationBuilder();

hostBuilder.Services.AddMailtrapClient();

var host = hostBuilder.Build();

await host.RunAsync().ConfigureAwait(false);
