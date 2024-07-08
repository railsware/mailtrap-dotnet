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
    /// Adds Mailtrap API client services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure</param>
    /// <returns>
    /// The <see cref="IHttpClientBuilder"/> instance for configured <see cref="HttpClient"/>,
    /// so additional configuration calls can be chained.
    /// </returns>
    public static IHttpClientBuilder AddMailtrapClient(this IServiceCollection services)
    {
        Ensure.NotNull(services, nameof(services));

        return services
            .AddMailtrapServices()
            .AddHttpClient(Options.DefaultName);
    }

    /// <summary>
    /// Adds Mailtrap API client services to the <see cref="IServiceCollection"/>
    /// and configures them using configuration section.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure.</param>
    /// <param name="configuration"><see cref="IConfiguration" /> to configure <see cref="MailtrapClient"/>.</param>
    /// <returns>
    /// The <see cref="IHttpClientBuilder"/> instance for configured <see cref="HttpClient"/>,
    /// so additional configuration calls can be chained.
    /// </returns>
    public static IHttpClientBuilder AddMailtrapClient(this IServiceCollection services, IConfiguration configuration)
    {
        Ensure.NotNull(services, nameof(services));
        Ensure.NotNull(configuration, nameof(configuration));

        services.Configure<MailtrapClientOptions>(configuration);

        return services.AddMailtrapClient();
    }

    /// <summary>
    /// Adds Mailtrap API client services to the <see cref="IServiceCollection"/>
    /// and configures them using configuration delegate.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure.</param>
    /// <param name="configureMailtrap">Delegate to configure <see cref="MailtrapClient"/>.</param>
    /// <returns>
    /// The <see cref="IHttpClientBuilder"/> instance for configured <see cref="HttpClient"/>,
    /// so additional configuration calls can be chained.
    /// </returns>
    public static IHttpClientBuilder AddMailtrapClient(this IServiceCollection services, Action<MailtrapClientOptions> configureMailtrap)
    {
        Ensure.NotNull(services, nameof(services));
        Ensure.NotNull(configureMailtrap, nameof(configureMailtrap));

        services.Configure(configureMailtrap);

        return services.AddMailtrapClient();
    }

    /// <summary>
    /// Adds Mailtrap API client services with provided <see cref="MailtrapClientOptions"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure.</param>
    /// <param name="mailtrapClientOptions">Options to configure <see cref="MailtrapClient"/>.</param>
    /// <returns>
    /// The <see cref="IHttpClientBuilder"/> instance for configured <see cref="HttpClient"/>,
    /// so additional configuration calls can be chained.
    /// </returns>
    public static IHttpClientBuilder AddMailtrapClient(this IServiceCollection services, MailtrapClientOptions mailtrapClientOptions)
    {
        Ensure.NotNull(services, nameof(services));
        Ensure.NotNull(mailtrapClientOptions, nameof(mailtrapClientOptions));

        return services.AddMailtrapClient(options => options.Init(mailtrapClientOptions));
    }

    /// <summary>
    /// Adds required Mailtrap API client services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure</param>
    /// <returns>The <see cref="IServiceCollection"/> so additional calls can be chained</returns>
    public static IServiceCollection AddMailtrapServices(this IServiceCollection services)
    {
        return services.AddMailtrapServices<TransientHttpClientLifetimeAdapterFactory>();
    }

    /// <summary>
    /// Adds required Mailtrap API client services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure</param>
    /// <returns>The <see cref="IServiceCollection"/> so additional calls can be chained</returns>
    internal static IServiceCollection AddMailtrapServices<T>(this IServiceCollection services)
        where T : class, IHttpClientLifetimeAdapterFactory
    {
        Ensure.NotNull(services, nameof(services));

        services.AddOptions();

        services.TryAddSingleton<IMailtrapClientConfigurationProvider, MailtrapClientConfigurationProvider>();
        services.TryAddSingleton<IAccessTokenProvider, AccessTokenProvider>();

        services.TryAddSingleton<IHttpRequestMessageFactory, HttpRequestMessageFactory>();
        services.TryAddSingleton<IHttpRequestContentFactory, HttpRequestContentFactory>();

        services.TryAddEnumerable(new ServiceDescriptor(
            typeof(IHttpRequestMessagePolicy),
            typeof(ApiKeyAuthenticationHttpRequestMessagePolicy),
            ServiceLifetime.Singleton));
        services.TryAddEnumerable(new ServiceDescriptor(
            typeof(IHttpRequestMessagePolicy),
            typeof(HeadersHttpRequestMessagePolicy),
            ServiceLifetime.Singleton));

        services.TryAddSingleton<IHttpClientLifetimeAdapterFactory, T>();

        services.TryAddTransient<IMailtrapClient, MailtrapClient>();

        return services;
    }
}
