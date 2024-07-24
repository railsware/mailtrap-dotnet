// -----------------------------------------------------------------------
// <copyright file="MailtrapClientEndpointOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


/// <summary>
/// A set of parameters to configure endpoint settings for Mailtrap API client.
/// </summary>
public record MailtrapClientEndpointOptions
{
    /// <summary>
    /// Gets default endpoint settings for transactional send.
    /// </summary>
    /// 
    /// <value>
    /// Static instance, containing default endpoint settings for transactional send.
    /// </value>
    public static MailtrapClientEndpointOptions SendDefaultEndpointOptions { get; } = new(Endpoints.SendDefaultUrl);

    /// <summary>
    /// Gets default endpoint settings for bulk send.
    /// </summary>
    /// 
    /// <value>
    /// Static instance, instance containing default endpoint settings for bulk send.
    /// </value>
    public static MailtrapClientEndpointOptions BulkDefaultEndpointOptions { get; } = new(Endpoints.BulkDefaultUrl);

    /// <summary>
    /// Gets default endpoint settings for test send.
    /// </summary>
    /// 
    /// <value>
    /// Static instance, instance containing default endpoint settings for test send.
    /// </value>
    public static MailtrapClientEndpointOptions TestDefaultEndpointOptions { get; } = new(Endpoints.TestDefaultUrl);


    /// <summary>
    /// Gets or sets endpoint base URL.
    /// <para>
    /// Required. Must be absolute URL.
    /// </para>
    /// </summary>
    ///
    /// <value>
    /// Contains endpoint base URL.<br/>
    /// E.g. https://send.api.mailtrap.io
    /// </value>
    public Uri BaseUrl { get; set; }

    /// <summary>
    /// Gets or sets <see cref="HttpClient"/> instance configuration name to use for requests routed to this endpoint.
    /// <para>
    /// Optional.
    /// </para>
    /// </summary>
    ///
    /// <value>
    /// Contains <see cref="HttpClient" /> configuration name.
    /// </value>
    ///
    /// <remarks>
    /// Different endpoints can use same or different named <see cref="HttpClient"/> configurations.<br/>
    /// Endpoint will use default <see cref="HttpClient"/> configuration, if unset.
    /// </remarks>
    public string? HttpClientName { get; set; }


    /// <summary>
    /// Instance constructor overload taking <see cref="Uri"/> as <paramref name="baseUrl"/> parameter.
    /// </summary>
    /// 
    /// <param name="baseUrl">
    /// Base URL of the endpoint.
    /// <para>
    /// Required. Must be absolute URL. 
    /// </para>
    /// </param>
    /// 
    /// <param name="httpClientName">
    /// Optional name of <see cref="HttpClient"/> instance configuration to use with endpoint.
    /// </param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="baseUrl"/> is <see langword="null"/>.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    /// When <paramref name="baseUrl"/> isn't an absolute URI.
    /// </exception>
    public MailtrapClientEndpointOptions(Uri baseUrl, string? httpClientName = default)
    {
        Ensure.NotNull(baseUrl, nameof(baseUrl));

        baseUrl.EnsureAbsoluteUri();

        BaseUrl = baseUrl;
        HttpClientName = httpClientName;
    }

    /// <summary>
    /// Instance constructor overload taking <see langword="string"/> as <paramref name="baseUrl"/> parameter.
    /// </summary>
    /// 
    /// <param name="baseUrl">
    /// Base URL of the endpoint.
    /// <para>
    /// Required. Must be absolute URL. 
    /// </para>
    /// </param>
    /// 
    /// <param name="httpClientName">
    /// Optional name of <see cref="HttpClient"/> instance configuration to use with endpoint.
    /// </param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="baseUrl"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <exception cref="ArgumentException">
    /// When <paramref name="baseUrl"/> isn't a valid absolute URI.
    /// </exception>
    public MailtrapClientEndpointOptions(string baseUrl, string? httpClientName = default)
        : this(baseUrl.ToAbsoluteUri(), httpClientName) { }
}
