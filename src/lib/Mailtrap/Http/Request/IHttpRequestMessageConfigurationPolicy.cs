// -----------------------------------------------------------------------
// <copyright file="IHttpRequestMessageConfigurationPolicy.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


/// <summary>
/// Configuration policy definition for <see cref="HttpRequestMessage"/>.
/// </summary>
internal interface IHttpRequestMessageConfigurationPolicy
{
    /// <summary>
    /// Applies configuration policy to the provided <paramref name="request"/>.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task ApplyPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken = default);
}
