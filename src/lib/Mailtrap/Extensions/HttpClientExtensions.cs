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
    public static HttpClient ConfigureAcceptHeader(this HttpClient httpClient)
    {
        var acceptHeader = httpClient.DefaultRequestHeaders.Accept;

        acceptHeader.Clear();
        acceptHeader.Add(new("application/json"));

        return httpClient;
    }

    public static HttpClient ConfigureApiAuthenticationHeader(this HttpClient httpClient, string apiKey)
    {
        var headers = httpClient.DefaultRequestHeaders;

        headers.Add(ApiHeaderNames.ApiKeyHeader, apiKey);

        return httpClient;
    }
}
