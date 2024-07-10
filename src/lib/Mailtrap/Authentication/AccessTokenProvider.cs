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


    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="options"><see cref="IOptions{TOptions}"/> instance containing token.</param>
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="options"/> is <see langword="null"/> or API token is empty.
    /// </exception>
    public AccessTokenProvider(IOptions<MailtrapClientOptions> options)
    {
        Ensure.NotNull(options, nameof(options));
        Ensure.NotNullOrEmpty(options.Value.Authentication.ApiToken, nameof(MailtrapClientOptions.Authentication.ApiToken));

        _token = options.Value.Authentication.ApiToken;
    }


    /// <inheritdoc/>
    public Task<string> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(_token);
}
