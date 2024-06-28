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
    internal static HttpClient WithBaseAddress(this HttpClient httpClient, Uri? baseAddress)
    {
        Ensure.NotNull(httpClient, nameof(httpClient));

        httpClient.BaseAddress = baseAddress;

        return httpClient;
    }
}
