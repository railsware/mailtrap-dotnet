// -----------------------------------------------------------------------
// <copyright file="IHttpClientProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Contracts;


internal interface IHttpClientProvider
{
    Task<HttpClient> GetClientAsync(CancellationToken cancellationToken = default);
}
