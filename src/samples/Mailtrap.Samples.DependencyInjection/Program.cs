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


[SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Example")]
internal sealed class Program
{
    // This particular example demonstrates how to use Mailtrap API client with generic app host (which can be WebApp host as well).
    private static async Task Main(string[] args)
    {
        // Default host builder helper loads configuration from appsettings.json,
        // appsettings.{Environment}.json, environment variables, user secrets and command-line arguments.
        // Alternatively, you could provide in-memory configuration using hostBuilder.Configuration.AddInMemoryCollection().

        HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);

        using IHost host = BuildHostWithAdvancedHttpClientConfiguration(hostBuilder);

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
            logger.LogError(ex, "An error occurred while sending email.");
            Environment.FailFast(ex.Message);
            throw;
        }
    }


    // The simplest example, which uses configuration section from appsettings.json.
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

    // Other simple one, which uses configuration delegate to configure Mailtrap API client.
    private static IHost BuildHostWithConfigurationDelegate(HostApplicationBuilder hostBuilder)
    {
        // For sure you should not hardcode apiKey for security reasons, and use environment variables
        // or configuration files instead.
        // But in case when some non-standard configuration/secrets storage is used, this can be an option.
        var apiKey = "<API-KEY>";

        hostBuilder.Services.AddMailtrapClient(options =>
        {
            options.Authentication.ApiToken = apiKey;
            options.Serialization.PrettyJson = true;
        });

        return hostBuilder.Build();
    }

    // Optionally, we can provide preconfigured MaitrapiClientOptions instance.
    private static IHost BuildHostWithExplicitConfiguration(HostApplicationBuilder hostBuilder)
    {
        var apiKey = "<API-KEY>";

        var settings = new MailtrapClientOptions(apiKey);
        settings.SendEndpoint.BaseUrl = new Uri("https://mock.mailtrap.io/v2/");

        hostBuilder.Services.AddMailtrapClient(settings);

        return hostBuilder.Build();
    }

    // More advanced scenario, where HttpClient is configured with custom fine-grane settings.
    // It can be used with any of configuration approaches (appsettings.json, delegate, explicit options).
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

    // In case you need full control over client configuration pipeline, you can go even further.
    private static IHost BuildHostWithAdvancedClientConfigurations(HostApplicationBuilder hostBuilder)
    {
        // Configuring Mailtrap API client.
        hostBuilder.Services.Configure<MailtrapClientOptions>(options =>
        {
            options.Authentication.ApiToken = "<API-KEY>";

            // Providing HttpClient name in configuration allows to use differently configured
            // HttpClient instances for endpoints.                
            options.SendEndpoint.HttpClientName = "SendClient";
            options.SendEndpoint.BaseUrl = new Uri("https://api.mailtrap.io/v3-alpha/");

            // When HttpClient name is not specified, default HttpClient instance is used.
            options.BulkEndpoint.BaseUrl = new Uri("https://bulk.mailtrap.io/");
        });


        // Adding Mailtrap API client services to the container
        hostBuilder.Services.AddMailtrapServices();

        // Configuring default HttpClient
        hostBuilder.Services.ConfigureHttpClientDefaults(builder =>
        {
            builder.AddStandardResilienceHandler();

            builder.ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler()
                {
                    Proxy = new WebProxy("proxy.mailtrap.io", 8080),
                    CheckCertificateRevocationList = true
                };
            });
        });


        // Configuring HttpClient for send endpoint
        IHttpClientBuilder sendHttpClientBuilder = hostBuilder.Services
            .AddHttpClient(hostBuilder.Configuration["Mailtrap:SendEndpoint:HttpClientName"]!);

        sendHttpClientBuilder.AddStandardResilienceHandler();

        return hostBuilder.Build();
    }
}
