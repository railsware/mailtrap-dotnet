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
    internal static HttpRequestMessage ConfigureAcceptHeader(this HttpRequestMessage request)
    {
        Ensure.NotNull(request, nameof(request));

        var acceptHeader = request.Headers.Accept;

        acceptHeader.Clear();
        acceptHeader.Add(new(MimeTypes.Application.Json));

        return request;
    }

    internal static HttpRequestMessage ConfigureApiAuthenticationHeader(this HttpRequestMessage request, string apiKey)
    {
        Ensure.NotNull(request, nameof(request));

        request.Headers.Add(ApiHeaderNames.ApiKeyHeader, apiKey);

        return request;
    }
}
