// -----------------------------------------------------------------------
// <copyright file="IHttpRequestMessageAuthenticationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Http.Request;


/// <summary>
/// Applies authentication to the <see cref="HttpRequestMessage"/>.
/// </summary>
internal interface IHttpRequestMessageAuthenticationProvider
{
    /// <summary>
    /// Authenticates provided <paramref name="request"/>.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AuthenticateAsync(HttpRequestMessage request, CancellationToken cancellationToken = default);
}
