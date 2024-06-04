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
    public static IHttpClientBuilder AddMailtrapClient(this IServiceCollection services)
    {
        services.TryAddTransient<IMailtrapEmailApiClient, MailtrapEmailApiClient>();

        return services.AddHttpClient(MailtrapEmailApiClient.HttpClientName);
    }
}
