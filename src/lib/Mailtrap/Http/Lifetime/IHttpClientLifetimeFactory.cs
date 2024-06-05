// -----------------------------------------------------------------------
// <copyright file="IHttpClientLifetimeFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Lifetime;


public interface IHttpClientLifetimeFactory
{
    Task<IHttpClientLifetimeAdapter> GetClientAsync(MailtrapApiClientEndpointOptions endpointConfiguration, CancellationToken cancellationToken = default);
}
