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
    public MailtrapClientEndpointOptions(string baseUrl, string? httpClientName = default)
        : this(baseUrl.ToAbsoluteUri(), httpClientName) { }
}
