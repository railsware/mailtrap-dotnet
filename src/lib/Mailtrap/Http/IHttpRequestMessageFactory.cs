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
    /// Creates a new <see cref="HttpRequestMessage"/> instance, using provided method, URI and optional content.
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
    /// Creates a new <see cref="HttpRequestMessage"/> instance for GET request.
    /// </summary>
    /// 
    /// <returns>
    /// New <see cref="HttpRequestMessage"/> instance for GET request.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="uri"/> is <see langword="null"/>.
    /// </exception>
    public HttpRequestMessage CreateGet(Uri uri);

    /// <summary>
    /// Creates a new <see cref="HttpRequestMessage"/> instance for PATCH request.
    /// </summary>
    /// 
    /// <returns>
    /// New <see cref="HttpRequestMessage"/> instance for PATCH request.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="uri"/> is <see langword="null"/>.    
    /// </exception>
    public HttpRequestMessage CreatePatch(Uri uri);

    /// <summary>
    /// Creates a new <see cref="HttpRequestMessage"/> instance for DELETE request.
    /// </summary>
    /// 
    /// <returns>
    /// New <see cref="HttpRequestMessage"/> instance for DELETE request.
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="uri"/> is <see langword="null"/>.
    /// </exception>
    public HttpRequestMessage CreateDelete(Uri uri);

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

    /// <summary>
    /// Creates a new <see cref="HttpRequestMessage"/> instance for POST request.
    /// </summary>
    /// 
    /// <returns>
    /// New <see cref="HttpRequestMessage"/> instance for POST request.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="uri"/> or <paramref name="content"/> is <see langword="null"/>.    
    /// </exception>
    public HttpRequestMessage CreatePost<T>(Uri uri, T content) where T : class;

    /// <summary>
    /// Creates a new <see cref="HttpRequestMessage"/> instance for PUT request.
    /// </summary>
    /// 
    /// <returns>
    /// New <see cref="HttpRequestMessage"/> instance for PUT request.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="uri"/> or <paramref name="content"/> is <see langword="null"/>.    
    /// </exception>
    public HttpRequestMessage CreatePut<T>(Uri uri, T content) where T : class;

    /// <summary>
    /// Creates a new <see cref="HttpRequestMessage"/> instance for PATCH request.
    /// </summary>
    /// 
    /// <returns>
    /// New <see cref="HttpRequestMessage"/> instance for PATCH request.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="uri"/> or <paramref name="content"/> is <see langword="null"/>.    
    /// </exception>
    public HttpRequestMessage CreatePatchWithContent<T>(Uri uri, T content) where T : class;
}
