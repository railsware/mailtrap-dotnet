// -----------------------------------------------------------------------
// <copyright file="OptionsAccessTokenProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Authentication;


/// <summary>
/// Provides static predefined token instance
/// </summary>
internal class OptionsAccessTokenProvider : IAccessTokenProvider
{
    private readonly string _token;

    internal OptionsAccessTokenProvider(IOptions<MailtrapApiClientOptions> options)
    {
        ExceptionHelpers.ThrowIfNull(options, nameof(options));

        _token = options.Value.Authentication.ApiToken;
    }

    public Task<string> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(_token);
}
