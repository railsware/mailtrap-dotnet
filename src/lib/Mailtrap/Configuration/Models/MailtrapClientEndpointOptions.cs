// -----------------------------------------------------------------------
// <copyright file="MailtrapClientEndpointOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


/// <summary>
/// A set of options to configure endpoint settings for Mailtrap API client.
/// </summary>
public record MailtrapClientEndpointOptions
{
    /// <summary>
    /// Default send endpoint.
    /// </summary>
    public static MailtrapClientEndpointOptions SendDefault { get; } = new(Endpoints.SendDefaultUrl);

    /// <summary>
    /// Default bulk endpoint.
    /// </summary>
    public static MailtrapClientEndpointOptions BulkDefault { get; } = new(Endpoints.BulkDefaultUrl);

    /// <summary>
    /// Default test endpoint.
    /// </summary>
    public static MailtrapClientEndpointOptions TestDefault { get; } = new(Endpoints.TestDefaultUrl);


    /// <summary>
    /// Endpoint base URL, e.g. https://send.api.mailtrap.io
    /// </summary>
    /// <remarks>
    /// Required. Should be absolute URL.
    /// </remarks>
    public Uri BaseUrl { get; set; }


    /// <summary>
    /// Primary constructor with required parameters.
    /// </summary>
    /// <param name="baseUrl">Required. Should be absolute URL.</param>
    /// <exception cref="ArgumentNullException">When <paramref name="baseUrl"/> is <see langword="null"/></exception>
    public MailtrapClientEndpointOptions(Uri baseUrl)
    {
        Ensure.NotNull(baseUrl, nameof(baseUrl));

        BaseUrl = baseUrl.EnsureAbsoluteUri();
    }

    /// <summary>
    /// Constructor overload taking <paramref name="baseUrl"/> parameter in <see langword="string"/> format.
    /// </summary>
    /// <param name="baseUrl">Required. Should be absolute URL.</param>
    /// <exception cref="ArgumentNullException">When <paramref name="baseUrl"/> is <see langword="null"/></exception>
    /// <exception cref="ArgumentException">When <paramref name="baseUrl"/> isn't a valid absolute URI</exception>
    public MailtrapClientEndpointOptions(string baseUrl)
        : this(baseUrl.ToAbsoluteUri()) { }
}
