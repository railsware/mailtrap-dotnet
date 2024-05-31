// -----------------------------------------------------------------------
// <copyright file="StaticAccessTokenProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Behaviors;


/// <summary>
/// Provides static predefined token instance
/// </summary>
internal class StaticAccessTokenProvider : IAccessTokenProvider
{
    private readonly string _token;

    internal StaticAccessTokenProvider(string token)
    {
        ExceptionHelpers.ThrowIfNullOrEmpty(token, nameof(token));

        _token = token;
    }

    public Task<string> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(_token);
}
