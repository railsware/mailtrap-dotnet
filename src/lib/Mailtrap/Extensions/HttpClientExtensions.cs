// -----------------------------------------------------------------------
// <copyright file="HttpClientExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Extensions;


/// <summary>
/// A set of helpers for <see cref="HttpClient"/> configuration.
/// </summary>
internal static class HttpClientExtensions
{
    internal static HttpClient WithJsonAcceptHeader(this HttpClient httpClient)
    {
        Ensure.NotNull(httpClient, nameof(httpClient));

        var acceptHeader = httpClient.DefaultRequestHeaders.Accept;

        acceptHeader.Clear();
        acceptHeader.Add(new("application/json"));

        return httpClient;
    }

    internal static HttpClient WithApiAuthenticationHeader(this HttpClient httpClient, string apiKey)
    {
        Ensure.NotNull(httpClient, nameof(httpClient));

        var headers = httpClient.DefaultRequestHeaders;

        headers.Add(ApiHeaderNames.ApiKeyHeader, apiKey);

        return httpClient;
    }

    internal static HttpClient WithBaseAddress(this HttpClient httpClient, Uri? baseAddress, bool force = false)
    {
        Ensure.NotNull(httpClient, nameof(httpClient));

        if (force || httpClient.BaseAddress is null)
        {
            httpClient.BaseAddress = baseAddress;
        }

        return httpClient;
    }
}
