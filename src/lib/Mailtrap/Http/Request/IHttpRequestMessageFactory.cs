// -----------------------------------------------------------------------
// <copyright file="IHttpRequestMessageFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


/// <summary>
/// Factory to create <see cref="HttpRequestMessage"/> instances.
/// </summary>
public interface IHttpRequestMessageFactory
{
    /// <summary>
    /// Asynchronously creates a new <see cref="HttpRequestMessage"/> instance, using provided method, URI and content.
    /// </summary>
    /// <param name="method"></param>
    /// <param name="uri"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    Task<HttpRequestMessage> CreateAsync(HttpMethod method, Uri uri, HttpContent content);
}
