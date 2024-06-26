// -----------------------------------------------------------------------
// <copyright file="IHttpClientLifetimeFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Lifetime;


/// <summary>
/// Factory to produce <see cref="IHttpClientLifetimeAdapter"/> instances
/// </summary>
public interface IHttpClientLifetimeFactory
{
    /// <summary>
    /// Asynchronously produces <see cref="IHttpClientLifetimeAdapter"/> instances,
    /// using the <paramref name="endpointConfiguration"/> provided.
    /// </summary>
    /// <param name="endpointConfiguration"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IHttpClientLifetimeAdapter> GetClientAsync(MailtrapClientEndpointOptions endpointConfiguration, CancellationToken cancellationToken = default);
}
