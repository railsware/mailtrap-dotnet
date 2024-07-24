// -----------------------------------------------------------------------
// <copyright file="IHttpRequestContentFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


/// <summary>
/// Factory to spawn <see cref="HttpContent"/> instances.
/// </summary>
internal interface IHttpRequestContentFactory
{
    /// <summary>
    /// Asynchronously creates a new <see cref="StringContent"/> instance, using provided string.
    /// </summary>
    /// <param name="content"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>New <see cref="StringContent"/> instance.</returns>
    Task<StringContent> CreateStringContentAsync(string content, CancellationToken cancellationToken = default);
}
