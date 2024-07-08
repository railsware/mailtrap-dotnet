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
    /// Returns API access token.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns><see langword="string"/> containing API token.</returns>
    Task<string> GetAccessTokenAsync(CancellationToken cancellationToken = default);
}
