// -----------------------------------------------------------------------
// <copyright file="IHttpRequestMessageFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http;


/// <summary>
/// Factory to spawn <see cref="HttpRequestMessage"/> instances.
/// </summary>
public interface IHttpRequestMessageFactory
{
    /// <summary>
    /// Creates a new <see cref="HttpRequestMessage"/> instance, using provided method, URI and content.
    /// </summary>
    /// 
    /// <param name="method">
    /// </param>
    /// 
    /// <param name="uri">
    /// </param>
    /// 
    /// <param name="content">
    /// </param>
    /// 
    /// <returns>
    /// New <see cref="HttpRequestMessage"/> instance.
    /// </returns>
    HttpRequestMessage Create(HttpMethod method, Uri uri, HttpContent content);
}
