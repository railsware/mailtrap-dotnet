// -----------------------------------------------------------------------
// <copyright file="ServiceCollectionExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;


namespace Mailtrap.Extensions.DependencyInjection;


public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Mailtrap API client services with default <see cref="HttpClient"/> configuration.<br />
    /// Requires <see cref="ConfigureMailtrapClientOptions(IServiceCollection)"/> or
    /// <see cref="OptionsServiceCollectionExtensions.Configure(MailtrapApiClientOptions)"/> to be called
    /// to setup proper configuration to the client.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure</param>
    /// <returns>The <see cref="IServiceCollection"/> so additional calls can be chained</returns>
    public static IServiceCollection AddMailtrapClient(this IServiceCollection services)
    {
        Ensure.NotNull(services, nameof(services));

        return services
            .AddMailtrapServices()
            .AddHttpClient();
    }

    public static IServiceCollection AddMailtrapClient(this IServiceCollection services, Action<IHttpClientBuilder> configure)
    {
        Ensure.NotNull(services, nameof(services));
        Ensure.NotNull(configure, nameof(configure));

        return services
            .AddMailtrapServices()
            .ConfigureHttpClientDefaults(configure);
    }

    public static IHttpClientBuilder AddMailtrapClient(this IServiceCollection services, string httpClientName)
    {
        Ensure.NotNull(services, nameof(services));

        return services
            .AddMailtrapServices()
            .AddHttpClient(httpClientName);
    }

    public static OptionsBuilder<MailtrapApiClientOptions> ConfigureMailtrapClientOptions(this IServiceCollection services)
    {
        Ensure.NotNull(services, nameof(services));

        return services.AddOptions<MailtrapApiClientOptions>();
    }


    public static IServiceCollection AddMailtrapServices(this IServiceCollection services)
    {
        Ensure.NotNull(services, nameof(services));

        services.AddOptions();

        services.TryAddSingleton<IMailtrapApiClientConfigurationProvider, OptionsMailtrapApiClientConfigurationProvider>();
        services.TryAddSingleton<IAccessTokenProvider, OptionsAccessTokenProvider>();
        services.TryAddSingleton<IHttpRequestMessageAuthenticationProvider, ApiKeyHttpRequestMessageAuthenticationProvider>();

        services.TryAddSingleton<IHttpRequestContentFactory, HttpRequestContentFactory>();
        services.TryAddSingleton<IHttpRequestMessageFactory, HttpRequestMessageFactory>();
        services.TryAddSingleton<IHttpRequestMessageConfigurationPolicy, HttpRequestMessageConfigurationPolicy>();

        services.TryAddSingleton<IHttpClientLifetimeFactory, HttpClientLifetimeFactory>();
        services.TryAddSingleton<IHttpClientConfigurationPolicy, HttpClientConfigurationPolicy>();

        services.TryAddTransient<IMailtrapApiClient, MailtrapApiClient>();

        return services;
    }
}
