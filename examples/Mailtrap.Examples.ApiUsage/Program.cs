// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Mailtrap;
using Mailtrap.Accounts;
using Mailtrap.Accounts.Models;
using Mailtrap.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


/// <summary>
/// Various examples of the Mailtrap API usage
/// </summary>
internal sealed class Program
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private static IMailtrapClient s_mailtrapClient;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.


    private static async Task Main(string[] args)
    {
        HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);

        IConfigurationSection config = hostBuilder.Configuration.GetSection("Mailtrap");

        hostBuilder.Services.AddMailtrapClient(config);

        using IHost host = hostBuilder.Build();

        ILogger logger = host.Services.GetRequiredService<ILogger<Program>>();

        try
        {
            s_mailtrapClient = host.Services.GetRequiredService<IMailtrapClient>();

            IAccountCollectionResource accountCollectionResource = s_mailtrapClient.Accounts();

            // Get all accounts available for the token
            IList<Account> accounts = await accountCollectionResource.GetAll();

            var accountId = 1917378;
            Account? account = accounts.FirstOrDefault(a => a.Id == accountId);

            if (account is null)
            {
                logger.LogWarning("No account found.");

                return;
            }

            logger.LogInformation("Account: {Account}", account);

            // Get resource for specific account
            IAccountResource accountResource = s_mailtrapClient.Account(account.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred during API call.");
            Environment.FailFast(ex.Message);
            throw;
        }
    }
}
