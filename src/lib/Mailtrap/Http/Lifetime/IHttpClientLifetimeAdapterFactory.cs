// -----------------------------------------------------------------------
// <copyright file="IHttpClientLifetimeAdapterFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Lifetime;


/// <summary>
/// Factory to produce <see cref="IHttpClientLifetimeAdapter"/> instances.
/// </summary>
public interface IHttpClientLifetimeAdapterFactory
{
    /// <summary>
    /// Asynchronously produces <see cref="IHttpClientLifetimeAdapter"/> instances,
    /// using the <paramref name="endpointConfiguration"/> provided.
    /// </summary>
    /// <param name="endpointConfiguration">Particular endpoint configuration.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>New <see cref="IHttpClientLifetimeAdapter"/> instance.</returns>
    Task<IHttpClientLifetimeAdapter> CreateAsync(MailtrapClientEndpointOptions endpointConfiguration, CancellationToken cancellationToken = default);
}
