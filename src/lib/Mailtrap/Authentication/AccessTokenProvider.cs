// -----------------------------------------------------------------------
// <copyright file="AccessTokenProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Authentication;


/// <summary>
/// Default implementation for <see cref="IAccessTokenProvider"/>. <br />
/// Provides authentication token from <see cref="IOptions{MailtrapClientOptions}"/>.
/// </summary>
internal class AccessTokenProvider : IAccessTokenProvider
{
    private readonly string _token;

    public AccessTokenProvider(IOptions<MailtrapClientOptions> options)
    {
        Ensure.NotNull(options, nameof(options));
        Ensure.NotNullOrEmpty(options.Value.Authentication.ApiToken, nameof(options));

        _token = options.Value.Authentication.ApiToken;
    }

    public Task<string> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(_token);
}
