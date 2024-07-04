// -----------------------------------------------------------------------
// <copyright file="ServiceCollectionExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Extensions.DependencyInjection;


/// <summary>
/// A set of extension methods to configure Mailtrap API client services in <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Mailtrap API client services to the <see cref="IServiceCollection"/>.<br />
    /// Optionally configures <see cref="MailtrapClientOptions"/> and adds custom <see cref="HttpClient"/> configuration,
    /// if provided.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure.</param>
    /// <param name="configuration"><see cref="IConfiguration" /> to configure <see cref="MailtrapClient"/>.</param>
    /// <param name="configureHttpClient">Delegate to configure <see cref="HttpClient"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/> so additional calls can be chained.</returns>
    public static IServiceCollection AddMailtrapClient(this IServiceCollection services,
        IConfiguration? configuration = null,
        Action<IHttpClientBuilder>? configureHttpClient = null)
    {
        Ensure.NotNull(services, nameof(services));

        if (configuration is not null)
        {
            services.Configure<MailtrapClientOptions>(configuration);
        }

        services.AddMailtrapServices<TransientHttpClientLifetimeAdapterFactory>();

        if (configureHttpClient is null)
        {
            services.AddHttpClient();
        }
        else
        {
            services.ConfigureHttpClientDefaults(configureHttpClient);
        }

        return services;
    }

    /// <summary>
    /// Adds Mailtrap API client services to the <see cref="IServiceCollection"/>.<br />
    /// Optionally configures <see cref="MailtrapClientOptions"/> and adds custom <see cref="HttpClient"/> configuration,
    /// if provided.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure.</param>
    /// <param name="configureMailtrap">Delegate to configure <see cref="MailtrapClient"/>.</param>
    /// <param name="configureHttpClient">Delegate to configure <see cref="HttpClient"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/> so additional calls can be chained.</returns>
    public static IServiceCollection AddMailtrapClient(this IServiceCollection services,
        Action<MailtrapClientOptions> configureMailtrap,
        Action<IHttpClientBuilder>? configureHttpClient = null)
    {
        Ensure.NotNull(services, nameof(services));
        Ensure.NotNull(configureMailtrap, nameof(configureMailtrap));

        services.Configure(configureMailtrap);

        services.AddMailtrapServices<TransientHttpClientLifetimeAdapterFactory>();

        if (configureHttpClient is null)
        {
            services.AddHttpClient();
        }
        else
        {
            services.ConfigureHttpClientDefaults(configureHttpClient);
        }

        return services;
    }

    /// <summary>
    /// Adds Mailtrap API client services with provided <see cref="MailtrapClientOptions"/>.<br />
    /// Optionally adds custom <see cref="HttpClient"/> configuration, if
    /// provided by <paramref name="configureHttpClient"/> delegate.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure.</param>
    /// <param name="mailtrapClientOptions">Delegate to configure <see cref="MailtrapClient"/>.</param>
    /// <param name="configureHttpClient">Delegate to configure <see cref="HttpClient"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/> so additional calls can be chained.</returns>
    public static IServiceCollection AddMailtrapClient(this IServiceCollection services,
        MailtrapClientOptions mailtrapClientOptions,
        Action<IHttpClientBuilder>? configureHttpClient = null)
    {
        Ensure.NotNull(services, nameof(services));
        Ensure.NotNull(mailtrapClientOptions, nameof(mailtrapClientOptions));

        return services.AddMailtrapClient(options => options.Init(mailtrapClientOptions), configureHttpClient);
    }

    /// <summary>
    /// Adds Mailtrap API client services with custom named <see cref="HttpClient"/> configuration.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure</param>
    /// <param name="httpClientName"></param>
    /// <returns>The <see cref="IHttpClientBuilder"/> instance for the named <see cref="HttpClient"/>,
    /// so additional configuration calls can be chained.</returns>
    public static IHttpClientBuilder AddMailtrapClient(this IServiceCollection services, string httpClientName)
    {
        Ensure.NotNull(services, nameof(services));

        return services
            .AddMailtrapServices<TransientHttpClientLifetimeAdapterFactory>()
            .AddHttpClient(httpClientName);
    }


    /// <summary>
    /// Adds required Mailtrap API client services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure</param>
    /// <returns>The <see cref="IServiceCollection"/> so additional calls can be chained</returns>
    public static IServiceCollection AddMailtrapServices<T>(this IServiceCollection services)
        where T : class, IHttpClientLifetimeAdapterFactory
    {
        Ensure.NotNull(services, nameof(services));

        services.AddOptions();

        services.TryAddSingleton<IMailtrapClientConfigurationProvider, MailtrapClientConfigurationProvider>();
        services.TryAddSingleton<IAccessTokenProvider, AccessTokenProvider>();
        services.TryAddSingleton<IHttpRequestMessageAuthenticationProvider, ApiKeyHttpRequestMessageAuthenticationProvider>();

        services.TryAddSingleton<IHttpRequestContentFactory, HttpRequestContentFactory>();
        services.TryAddSingleton<IHttpRequestMessageFactory, HttpRequestMessageFactory>();
        services.TryAddSingleton<IHttpRequestMessageConfigurationPolicy, HttpRequestMessageConfigurationPolicy>();

        services.TryAddSingleton<IHttpClientLifetimeAdapterFactory, T>();

        services.TryAddTransient<IMailtrapClient, MailtrapClient>();

        return services;
    }
}
