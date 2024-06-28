// -----------------------------------------------------------------------
// <copyright file="IHttpRequestContentFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


/// <summary>
/// Factory to create <see cref="HttpContent"/> instances.
/// </summary>
public interface IHttpRequestContentFactory
{
    /// <summary>
    /// Asynchronously creates a new <see cref="HttpContent"/> instance, using provided string.
    /// </summary>
    /// <param name="content"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<StringContent> CreateAsync(string content, CancellationToken cancellationToken = default);
}
