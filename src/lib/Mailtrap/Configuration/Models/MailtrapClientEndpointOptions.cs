// -----------------------------------------------------------------------
// <copyright file="MailtrapClientEndpointOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


/// <summary>
/// API client endpoint configuration
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
    /// Base endpoint URL, e.g. https://api.mailtrap.io
    /// </summary>
    /// <remarks>
    /// Required.
    /// </remarks>
    public Uri BaseUrl { get; }

    /// <summary>
    /// <see cref="HttpClient"/> instanse name to use for requests sent to this endpoint.
    /// <para>
    /// Different endpoints can use same or different named <see cref="HttpClient"/> instances,
    /// preconfigured with one of the <see cref="HttpClientFactoryServiceCollectionExtensions.AddHttpClient(IServiceCollection, string)"/> overloads
    /// </para>
    /// </summary>
    /// <remarks>
    /// Optional.
    /// </remarks>
    public string? HttpClientName { get; }


    /// <summary>
    /// Primary constructor with required parameters.
    /// </summary>
    /// <param name="baseUrl"></param>
    /// <param name="httpClientName"></param>
    /// <exception cref="ArgumentNullException">When <paramref name="baseUrl"/> is <see langword="null"/></exception>
    public MailtrapClientEndpointOptions(Uri baseUrl, string? httpClientName = default)
    {
        Ensure.NotNull(baseUrl, nameof(baseUrl));

        BaseUrl = baseUrl;
        HttpClientName = httpClientName;
    }

    /// <summary>
    /// Constructor overload taking <paramref name="baseUrl"/> parameter in <see langword="string"/> format.
    /// </summary>
    /// <param name="baseUrl"></param>
    /// <param name="httpClientName"></param>
    /// <exception cref="ArgumentNullException">When <paramref name="baseUrl"/> is <see langword="null"/></exception>
    /// <exception cref="ArgumentException">When <paramref name="baseUrl"/> isn't a valid absolute URI</exception>
    public MailtrapClientEndpointOptions(string baseUrl, string? httpClientName = default)
        : this(baseUrl.ToAbsoluteUri(), httpClientName) { }
}
