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
    /// Adds required Mailtrap API client services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// 
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> instance to configure.
    /// </param>
    /// 
    /// <returns>
    /// Updated <see cref="IServiceCollection"/> instance so additional calls can be chained.
    /// </returns>
    internal static IServiceCollection AddMailtrapServices(this IServiceCollection services)
    {
        Ensure.NotNull(services, nameof(services));

        services.AddOptions();

        services.TryAddSingleton<IHttpRequestMessageFactory, HttpRequestMessageFactory>();
        services.TryAddSingleton<IHttpRequestContentFactory, HttpRequestContentFactory>();

        services.TryAddTransient<IMailtrapClient, MailtrapClient>();
        services.TryAddTransient<IEmailClient>(services => services.GetRequiredService<IMailtrapClient>());

        return services;
    }

    /// <summary>
    /// Adds Mailtrap API client services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// 
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> instance to configure.
    /// </param>
    /// 
    /// <returns>
    /// The <see cref="IHttpClientBuilder"/> instance for configured <see cref="HttpClient"/>,
    /// so additional configuration calls can be chained.
    /// </returns>
    public static IHttpClientBuilder AddMailtrapClient(this IServiceCollection services)
    {
        Ensure.NotNull(services, nameof(services));

        return services
            .AddMailtrapServices()
            .AddHttpClient<MailtrapClient>();
    }

    /// <summary>
    /// Adds Mailtrap API client services to the <see cref="IServiceCollection"/>
    /// and configures them using configuration section.
    /// </summary>
    /// 
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> instance to configure.
    /// </param>
    /// 
    /// <param name="configuration"
    /// ><see cref="IConfiguration" /> to configure <see cref="MailtrapClient"/>.
    /// </param>
    /// 
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
    /// 
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> instance to configure.
    /// </param>
    /// 
    /// <param name="configureMailtrap">
    /// Delegate to configure <see cref="MailtrapClient"/>.
    /// </param>
    /// 
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
    /// 
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> instance to configure.
    /// </param>
    /// 
    /// <param name="mailtrapClientOptions">
    /// Options to configure <see cref="MailtrapClient"/>.
    /// </param>
    /// 
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
}
