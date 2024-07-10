// -----------------------------------------------------------------------
// <copyright file="IAccessTokenProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Authentication;


/// <summary>
/// Provides access token to be used for API authentication.
/// </summary>
internal interface IAccessTokenProvider
{
    /// <summary>
    /// Asynchronously returns API access token.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// <see cref="Task"/>, that returns <see langword="string"/> containing API token, upon completion.
    /// </returns>
    Task<string> GetAccessTokenAsync(CancellationToken cancellationToken = default);
}
