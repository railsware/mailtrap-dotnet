// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System.Diagnostics.CodeAnalysis;
using Mailtrap;
using Mailtrap.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;



/// <summary>
/// Various examples of the Mailtrap API usage
/// </summary>
[SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Example")]
internal sealed class Program
{
    private static async Task Main(string[] args)
    {
        HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);

        IConfigurationSection config = hostBuilder.Configuration.GetSection("Mailtrap");

        hostBuilder.Services.AddMailtrapClient(config);

        using IHost host = hostBuilder.Build();

        ILogger logger = host.Services.GetRequiredService<ILogger<Program>>();

        try
        {
            IMailtrapClient mailtrapClient = host.Services.GetRequiredService<IMailtrapClient>();

            // var attachment = mailtrapClient
            
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while sending email.");
            Environment.FailFast(ex.Message);
            throw;
        }
    }
}
