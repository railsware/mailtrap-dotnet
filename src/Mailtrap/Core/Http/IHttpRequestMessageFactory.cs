// -----------------------------------------------------------------------
// <copyright file="IHttpRequestMessageFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http;


/// <summary>
/// Factory to spawn <see cref="HttpRequestMessage"/> instances.
/// </summary>
internal interface IHttpRequestMessageFactory
{
    /// <summary>
    /// Creates a new <see cref="HttpRequestMessage"/> instance, using provided method and URI.
    /// </summary>
    /// 
    /// <returns>
    /// New <see cref="HttpRequestMessage"/> instance.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    /// When any of provided <paramref name="method"/> or <paramref name="uri"/> is <see langword="null"/>.
    /// </exception>
    public HttpRequestMessage Create(HttpMethod method, Uri uri);

    /// <summary>
    /// Creates a new <see cref="HttpRequestMessage"/> instance, using provided method, URI and content.
    /// </summary>
    /// 
    /// <returns>
    /// New <see cref="HttpRequestMessage"/> instance.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    /// When any of provided <paramref name="method"/>, <paramref name="uri"/>
    /// or <paramref name="content"/> is <see langword="null"/>.
    /// </exception>
    public HttpRequestMessage CreateWithContent<T>(HttpMethod method, Uri uri, T content) where T : class;
}
