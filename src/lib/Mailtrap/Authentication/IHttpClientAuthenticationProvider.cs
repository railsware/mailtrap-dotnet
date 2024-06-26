// -----------------------------------------------------------------------
// <copyright file="IHttpClientAuthenticationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Authentication;


internal interface IHttpClientAuthenticationProvider
{
    Task AuthenticateAsync(HttpClient httpClient, CancellationToken cancellationToken = default);
}
