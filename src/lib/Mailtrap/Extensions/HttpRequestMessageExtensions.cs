// -----------------------------------------------------------------------
// <copyright file="HttpRequestMessageExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Extensions;


/// <summary>
/// A set of helpers for <see cref="HttpRequestMessage"/> configuration.
/// </summary>
internal static class HttpRequestMessageExtensions
{
    /// <summary>
    /// Replaces the contents of the 'Accept' header in provided <see cref="HttpRequestMessage"/> instance
    /// with a single JSON content type.
    /// </summary>
    /// <param name="request"></param>
    /// <returns><see cref="HttpRequestMessage"/> instance so calls can be chained.</returns>
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    internal static HttpRequestMessage ConfigureAcceptHeader(this HttpRequestMessage request)
    {
        Ensure.NotNull(request, nameof(request));

        var acceptHeader = request.Headers.Accept;

        acceptHeader.Clear();
        acceptHeader.Add(new(MimeTypes.Application.Json));

        return request;
    }

    /// <summary>
    /// Adds the API key to the request headers.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="apiKey"></param>
    /// <returns><see cref="HttpRequestMessage"/> instance so calls can be chained.</returns>
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    internal static HttpRequestMessage ConfigureApiAuthenticationHeader(this HttpRequestMessage request, string apiKey)
    {
        Ensure.NotNull(request, nameof(request));

        request.Headers.Add(HeaderNames.ApiKeyHeader, apiKey);

        return request;
    }
}
