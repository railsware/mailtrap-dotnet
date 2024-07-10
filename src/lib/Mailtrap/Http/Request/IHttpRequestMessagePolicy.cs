// -----------------------------------------------------------------------
// <copyright file="IHttpRequestMessagePolicy.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


/// <summary>
/// Policy definition for <see cref="HttpRequestMessage"/>.
/// </summary>
internal interface IHttpRequestMessagePolicy
{
    /// <summary>
    /// Asynchronously applies policy to the provided <see cref="HttpRequestMessage"/> instance.
    /// </summary>
    /// <param name="request"><see cref="HttpRequestMessage"/> instance to apply policy to.</param>
    /// <param name="cancellationToken"></param>
    /// <returns><see cref="Task"/>, which completes when policy has been applied to <paramref name="request"/>.</returns>
    Task ApplyPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken = default);
}
