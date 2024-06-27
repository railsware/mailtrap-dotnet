// -----------------------------------------------------------------------
// <copyright file="ServiceCollectionExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Microsoft.Extensions.DependencyInjection.Extensions;


namespace Mailtrap.Extensions.DependencyInjection;


/// <summary>
/// A set of extension methods to configure Mailtrap API client services in <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures Mailtrap API client configuration options using provided configuration delegate.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure</param>
    /// <param name="configure">Delegate to configure options</param>
    /// <returns>The <see cref="IServiceCollection"/> so additional calls can be chained</returns>
    public static IServiceCollection ConfigureMailtrapClient(this IServiceCollection services, Action<MailtrapClientOptions> configure)
    {
        Ensure.NotNull(services, nameof(services));
        Ensure.NotNull(configure, nameof(configure));

        return services.Configure(configure);
    }

    /// <summary>
    /// Adds Mailtrap API client services with default <see cref="HttpClient"/> configuration.
    /// <para>
    /// Requires <see cref="ConfigureMailtrapClient(IServiceCollection, Action{MailtrapClientOptions})"/> or
    /// <see cref="OptionsServiceCollectionExtensions.Configure{TOptions}(IServiceCollection, Action{TOptions})"/> to be called
    /// to setup proper configuration to the client.
    /// </para>
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure</param>
    /// <returns>The <see cref="IServiceCollection"/> so additional calls can be chained</returns>
    public static IServiceCollection AddMailtrapClient(this IServiceCollection services)
    {
        Ensure.NotNull(services, nameof(services));

        services.TryAddSingleton<IHttpClientLifetimeFactory, TransientHttpClientLifetimeFactory>();

        return services
            .AddMailtrapServices<TransientHttpClientLifetimeFactory>()
            .AddHttpClient();
    }

    /// <summary>
    /// Adds Mailtrap API client services with custom <see cref="HttpClient"/> configuration
    /// provided by <paramref name="configure"/> delegate.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure</param>
    /// <param name="configure">Delegate to configure <see cref="HttpClient"/></param>
    /// <returns>The <see cref="IServiceCollection"/> so additional calls can be chained</returns>
    public static IServiceCollection AddMailtrapClient(this IServiceCollection services, Action<IHttpClientBuilder>? configure = null)
    {
        Ensure.NotNull(services, nameof(services));

        services.TryAddSingleton<IHttpClientLifetimeFactory, TransientHttpClientLifetimeFactory>();

        services.AddMailtrapServices<TransientHttpClientLifetimeFactory>();

        if (configure is not null)
        {
            services.ConfigureHttpClientDefaults(configure);
        }

        return services;
    }

    /// <summary>
    /// Adds Mailtrap API client services with custom named <see cref="HttpClient"/> configuration
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure</param>
    /// <param name="httpClientName"></param>
    /// <returns></returns>
    public static IHttpClientBuilder AddMailtrapClient(this IServiceCollection services, string httpClientName)
    {
        Ensure.NotNull(services, nameof(services));

        return services
            .AddMailtrapServices<TransientHttpClientLifetimeFactory>()
            .AddHttpClient(httpClientName);
    }


    /// <summary>
    /// Adds required Mailtrap API client services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure</param>
    /// <returns>The <see cref="IServiceCollection"/> so additional calls can be chained</returns>
    public static IServiceCollection AddMailtrapServices<T>(this IServiceCollection services)
        where T : class, IHttpClientLifetimeFactory
    {
        Ensure.NotNull(services, nameof(services));

        services.AddOptions();

        services.TryAddSingleton<IMailtrapClientConfigurationProvider, MailtrapClientConfigurationProvider>();
        services.TryAddSingleton<IAccessTokenProvider, AccessTokenProvider>();
        services.TryAddSingleton<IHttpRequestMessageAuthenticationProvider, ApiKeyHttpRequestMessageAuthenticationProvider>();

        services.TryAddSingleton<IHttpRequestContentFactory, HttpRequestContentFactory>();
        services.TryAddSingleton<IHttpRequestMessageFactory, HttpRequestMessageFactory>();
        services.TryAddSingleton<IHttpRequestMessageConfigurationPolicy, HttpRequestMessageConfigurationPolicy>();

        services.TryAddSingleton<IHttpClientLifetimeFactory, T>();

        services.TryAddTransient<IMailtrapClient, MailtrapClient>();

        return services;
    }
}
