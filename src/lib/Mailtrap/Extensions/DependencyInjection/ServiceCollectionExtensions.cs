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
    public static IServiceCollection ConfigureMailtrapClientOptions(this IServiceCollection services, Action<MailtrapApiClientOptions> configure)
    {
        Ensure.NotNull(services, nameof(services));
        Ensure.NotNull(configure, nameof(configure));

        return services.Configure(configure);
    }

    /// <summary>
    /// Adds Mailtrap API client services with default <see cref="HttpClient"/> configuration.
    /// <para>
    /// Requires <see cref="ConfigureMailtrapClientOptions(IServiceCollection, Action{MailtrapApiClientOptions})"/> or
    /// <see cref="OptionsServiceCollectionExtensions.Configure{TOptions}(IServiceCollection, Action{TOptions})"/> to be called
    /// to setup proper configuration to the client.
    /// </para>
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

    /// <summary>
    /// Adds Mailtrap API client services with custom <see cref="HttpClient"/> configuration
    /// provided by <paramref name="configure"/> delegate.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure</param>
    /// <param name="configure">Delegate to configure <see cref="HttpClient"/></param>
    /// <returns>The <see cref="IServiceCollection"/> so additional calls can be chained</returns>
    public static IServiceCollection AddMailtrapClient(this IServiceCollection services, Action<IHttpClientBuilder> configure)
    {
        Ensure.NotNull(services, nameof(services));
        Ensure.NotNull(configure, nameof(configure));

        return services
            .AddMailtrapServices()
            .ConfigureHttpClientDefaults(configure);
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
            .AddMailtrapServices()
            .AddHttpClient(httpClientName);
    }


    /// <summary>
    /// Adds required Mailtrap API client services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to configure</param>
    /// <returns>The <see cref="IServiceCollection"/> so additional calls can be chained</returns>
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
