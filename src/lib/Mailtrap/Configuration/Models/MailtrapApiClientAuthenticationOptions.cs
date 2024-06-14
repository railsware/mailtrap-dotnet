// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClientAuthenticationOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


/// <summary>
/// A set of options to configure Mailtrap API client authentication.
/// </summary>
public record MailtrapApiClientAuthenticationOptions
{
    /// <summary>
    /// Default empty configuration.
    /// </summary>
    public static MailtrapApiClientAuthenticationOptions Empty { get; } = new(string.Empty);


    /// <summary>
    /// API Authentication token.
    /// </summary>
    public string ApiToken { get; }


    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="apiToken">Required.</param>
    public MailtrapApiClientAuthenticationOptions(string apiToken)
    {
        Ensure.NotNull(apiToken, nameof(apiToken));

        ApiToken = apiToken;
    }
}
