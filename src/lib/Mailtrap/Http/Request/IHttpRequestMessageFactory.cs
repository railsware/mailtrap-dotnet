// -----------------------------------------------------------------------
// <copyright file="IHttpRequestMessageFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


/// <summary>
/// Factory to spawn <see cref="HttpRequestMessage"/> instances.
/// </summary>
internal interface IHttpRequestMessageFactory
{
    /// <summary>
    /// Asynchronously creates a new <see cref="HttpRequestMessage"/> instance, using provided method, URI and content.
    /// </summary>
    /// <param name="method"></param>
    /// <param name="uri"></param>
    /// <param name="content"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>New <see cref="HttpRequestMessage"/> instance.</returns>
    Task<HttpRequestMessage> CreateAsync(HttpMethod method, Uri uri, HttpContent content, CancellationToken cancellationToken = default);
}
