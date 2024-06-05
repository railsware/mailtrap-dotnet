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
    public static IServiceCollection AddMailtrapClient(this IServiceCollection services, Action<IHttpClientBuilder> configure)
    {
        ExceptionHelpers.ThrowIfNull(services, nameof(services));
        ExceptionHelpers.ThrowIfNull(configure, nameof(configure));

        return services
            .AddMailtrapServices()
            .ConfigureHttpClientDefaults(configure);
    }

    public static IHttpClientBuilder AddMailtrapClient(this IServiceCollection services, string httpClientName)
    {
        ExceptionHelpers.ThrowIfNull(services, nameof(services));

        return services
            .AddMailtrapServices()
            .AddHttpClient(httpClientName);
    }

    private static IServiceCollection AddMailtrapServices(this IServiceCollection services)
    {
        ExceptionHelpers.ThrowIfNull(services, nameof(services));

        services.TryAddTransient<IMailtrapApiClient, MailtrapApiClient>();

        return services;
    }
}
