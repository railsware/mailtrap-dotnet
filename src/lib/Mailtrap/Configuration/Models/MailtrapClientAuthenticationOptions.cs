// -----------------------------------------------------------------------
// <copyright file="MailtrapClientAuthenticationOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


/// <summary>
/// A set of parameters to configure authentication settings for Mailtrap API client.
/// </summary>
public record MailtrapClientAuthenticationOptions
{
    /// <summary>
    /// Gets default empty configuration.
    /// </summary>
    ///
    /// <value>
    /// Static instance, containing empty authentication configuration.
    /// </value>
    public static MailtrapClientAuthenticationOptions Empty { get; } = new(string.Empty);


    /// <summary>
    /// Gets or sets API authentication token.
    /// <para>
    /// Required. Must be non-empty string.
    /// </para>
    /// </summary>
    /// 
    /// <value>
    /// Contains API authentication token.
    /// </value>
    public string ApiToken { get; set; }


    /// <summary>
    /// Default instance constructor.
    /// </summary>
    /// 
    /// <param name="apiToken">
    /// API authentication token.
    /// <para>
    /// Required. Must be non-empty string.
    /// </para>
    /// </param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="apiToken"/> is <see langword="null"/>.
    /// </exception>
    public MailtrapClientAuthenticationOptions(string apiToken)
    {
        Ensure.NotNull(apiToken, nameof(apiToken));

        ApiToken = apiToken;
    }
}
