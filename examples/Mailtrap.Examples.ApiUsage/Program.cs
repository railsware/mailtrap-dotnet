// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


/// <summary>
/// Various examples of the Mailtrap API usage
/// </summary>
internal sealed class Program
{
    public static async Task Main(string[] args)
    {
        HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);

        RegisterServices(hostBuilder);

        using IHost host = hostBuilder.Build();

        ILogger<Program> logger = host.Services.GetRequiredService<ILogger<Program>>();

        try
        {
            var accountId = 1917378;

            await host.Services
                .GetRequiredService<AccountReactor>()
                .Process(accountId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred during API call.");
            Environment.FailFast(ex.Message);
            throw;
        }
    }


    private static void RegisterServices(HostApplicationBuilder hostBuilder)
    {
        IConfigurationSection config = hostBuilder.Configuration.GetSection("Mailtrap");

        hostBuilder.Services.AddMailtrapClient(config);

        hostBuilder.Services.TryAddTransient<AccountReactor>();
        hostBuilder.Services.TryAddTransient<BillingReactor>();
        hostBuilder.Services.TryAddTransient<AccountAccessReactor>();
        hostBuilder.Services.TryAddTransient<PermissionsReactor>();
        hostBuilder.Services.TryAddTransient<SendingDomainReactor>();
        hostBuilder.Services.TryAddTransient<ProjectReactor>();
        hostBuilder.Services.TryAddTransient<InboxReactor>();
        hostBuilder.Services.TryAddTransient<MessageReactor>();
        hostBuilder.Services.TryAddTransient<AttachmentReactor>();
        hostBuilder.Services.TryAddTransient<TestSendReactor>();
    }
}
