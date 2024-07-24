// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http.Headers;
using Mailtrap;
using Mailtrap.Configuration.Models;
using Mailtrap.Email.Requests;
using Mailtrap.Email.Responses;
using Mailtrap.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


/// <summary>
/// Example demonstrating how to use Mailtrap API client with application host (which can be WebApp host as well).
/// </summary>
[SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Example")]
internal sealed class Program
{
    private static async Task Main(string[] args)
    {
        // Default host builder helper loads configuration from appsettings.json,
        // appsettings.{Environment}.json, environment variables, user secrets and command-line arguments.
        // Alternatively, you could provide in-memory configuration using hostBuilder.Configuration.AddInMemoryCollection().

        HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);

        using IHost host = BuildHostWithConfigurationSection(hostBuilder);

        ILogger logger = host.Services.GetRequiredService<ILogger<Program>>();

        try
        {
            SendEmailRequest request = SendEmailRequest
                .Create()
                .From("john.doe@demomailtrap.com", "John Doe")
                .To("hero.bill@galaxy.net")
                .Subject("Invitation to Earth")
                .Text("Dear Bill,\n\nIt will be a great pleasure to see you on our blue planet next weekend.\n\nBest regards, John.");

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


    /// <summary>
    /// The simplest case, which uses configuration section from appsettings.json.
    /// </summary>
    private static IHost BuildHostWithConfigurationSection(HostApplicationBuilder hostBuilder)
    {
        // Loading config section, which can look like:
        //"Mailtrap": {
        //  "Authentication": {
        //    "ApiToken": "<API_KEY>"
        //  },
        //  "SendEndpoint": {
        //    "BaseUrl": "https://api.mailtrap.io/v1/send"
        //  },
        //  "Serialization": {
        //    "PrettyJson": true
        //  }
        //}
        IConfigurationSection config = hostBuilder.Configuration.GetSection("Mailtrap");

        // Adding Mailtrap API client services to the container
        hostBuilder.Services.AddMailtrapClient(config);

        return hostBuilder.Build();
    }

    /// <summary>
    /// Other simple one, which uses configuration delegate to configure Mailtrap API client.
    /// </summary>
    private static IHost BuildHostWithConfigurationDelegate(HostApplicationBuilder hostBuilder)
    {
        // For sure you should not hardcode APi token for security reasons, and use environment variables
        // or configuration files instead.
        // But in case when some non-standard configuration/secrets storage is used, this can be an option.
        var apiToken = "<API-TOKEN>";

        hostBuilder.Services.AddMailtrapClient(options =>
        {
            options.Authentication.ApiToken = apiToken;
            options.Serialization.PrettyJson = true;
        });

        return hostBuilder.Build();
    }

    /// <summary>
    /// Optionally, we can provide preconfigured MaitrapiClientOptions instance.
    /// </summary>
    private static IHost BuildHostWithExplicitConfiguration(HostApplicationBuilder hostBuilder)
    {
        var apiToken = "<API-TOKEN>";

        var settings = new MailtrapClientOptions(apiToken);
        settings.SendEndpoint.BaseUrl = new Uri("https://mock.mailtrap.io/v2/");

        hostBuilder.Services.AddMailtrapClient(settings);

        return hostBuilder.Build();
    }

    /// <summary>
    /// More advanced scenario, where HttpClient is configured with custom fine-grane settings.<br/>
    /// It can be used with any of configuration approaches (appsettings.json, delegate, explicit options).
    /// </summary>
    private static IHost BuildHostWithAdvancedHttpClientConfiguration(HostApplicationBuilder hostBuilder)
    {
        IConfigurationSection config = hostBuilder.Configuration.GetSection("Mailtrap");

        IHttpClientBuilder httpClientBuilder = hostBuilder.Services.AddMailtrapClient(config);

        // Adding resilience handler
        httpClientBuilder.AddStandardResilienceHandler();

        // Configuring HttpClient
        httpClientBuilder.ConfigureHttpClient(client =>
        {
            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
            {
                NoCache = true
            };
        });

        // Adding proxy
        httpClientBuilder.ConfigurePrimaryHttpMessageHandler(() =>
        {
            return new HttpClientHandler()
            {
                Proxy = new WebProxy("proxy.mailtrap.io", 8080),
                CheckCertificateRevocationList = true
            };
        });

        // Configure detailed HTTP request logging
        httpClientBuilder.AddExtendedHttpClientLogging();

        return hostBuilder.Build();
    }

    /// <summary>
    /// In case you need full control over client configuration pipeline, you can go even further.
    /// </summary>
    private static IHost BuildHostWithAdvancedClientConfigurations(HostApplicationBuilder hostBuilder)
    {
        var sendClientName = "SendClient";

        // Configuring Mailtrap API client
        hostBuilder.Services.Configure<MailtrapClientOptions>(options =>
        {
            options.Authentication.ApiToken = "<API-KEY>";

            // Providing HttpClient name in configuration allows to use differently configured
            // HttpClient instances for particular endpoint.
            options.SendEndpoint.HttpClientName = sendClientName;
            options.SendEndpoint.BaseUrl = new Uri("https://api.mailtrap.io/v3-alpha/");

            // When HttpClient name is not specified, default HttpClient instance is used.
            options.BulkEndpoint.BaseUrl = new Uri("https://bulk.mailtrap.io/");
        });


        // Adding Mailtrap API client services to the container
        hostBuilder.Services.AddMailtrapServices();

        // Configuring HttpClient defaults
        hostBuilder.Services.ConfigureHttpClientDefaults(builder =>
        {
            builder.AddStandardResilienceHandler();
        });

        // Configuring named HttpClient for send endpoint
        hostBuilder.Services
            .AddHttpClient(sendClientName)
            .ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler()
                {
                    Proxy = new WebProxy("proxy.mailtrap.io", 8080),
                    CheckCertificateRevocationList = true
                };
            })
            .AddExtendedHttpClientLogging();

        // Finally, building the host
        return hostBuilder.Build();
    }
}
