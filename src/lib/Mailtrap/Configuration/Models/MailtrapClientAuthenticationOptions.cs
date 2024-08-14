// -----------------------------------------------------------------------
// <copyright file="MailtrapClientAuthenticationOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


/// <summary>
/// A set of options to configure authentication settings for Mailtrap API client.
/// </summary>
public record MailtrapClientAuthenticationOptions
{
    /// <summary>
    /// Default empty configuration.
    /// </summary>
    ///
    /// <remarks>
    /// Returns new object every time, thus it's safe to mutate returned value.
    /// </remarks>
    public static MailtrapClientAuthenticationOptions Empty => new(string.Empty);


    /// <summary>
    /// API Authentication token.
    /// </summary>
    /// <remarks>
    /// Required.
    /// </remarks>
    public string ApiToken { get; set; }


    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="apiToken">Required.</param>
    /// <exception cref="ArgumentNullException">When <paramref name="apiToken"/> is <see langword="null"/></exception>
    public MailtrapClientAuthenticationOptions(string apiToken)
    {
        Ensure.NotNull(apiToken, nameof(apiToken));

        ApiToken = apiToken;
    }
}
