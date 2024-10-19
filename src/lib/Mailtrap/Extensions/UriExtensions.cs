// -----------------------------------------------------------------------
// <copyright file="UriExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Extensions;


/// <summary>
/// A set of helpers for <see cref="Uri"/>.
/// </summary>
internal static class UriExtensions
{
    /// <exception cref = "ArgumentNullException" >
    /// When provided <paramref name="url"/> is <see langword="null"/>.
    /// </exception>
    internal static Uri ToUri(this string url)
    {
        Ensure.NotNullOrEmpty(url, nameof(url));

        return Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out var result)
            ? result
            : throw new ArgumentException("Invalid URL format", nameof(url));
    }

    /// <exception cref = "ArgumentNullException" >
    /// When provided <paramref name="url"/> is <see langword="null"/>.
    /// </exception>
    internal static Uri ToAbsoluteUri(this string url)
    {
        Ensure.NotNullOrEmpty(url, nameof(url));

        return Uri.TryCreate(url, UriKind.Absolute, out var result)
            ? result
            : throw new ArgumentException("Invalid URL format - absolute URL is expected", nameof(url));
    }

    /// <exception cref = "ArgumentNullException" >
    /// When provided <paramref name="url"/> is <see langword="null"/>.
    /// </exception>
    internal static Uri ToRelativeUri(this string url)
    {
        Ensure.NotNullOrEmpty(url, nameof(url));

        return Uri.TryCreate(url, UriKind.Relative, out var result)
            ? result
            : throw new ArgumentException("Invalid URL format - relative URL is expected", nameof(url));
    }

    /// <exception cref = "ArgumentNullException" >
    /// When provided <paramref name="baseUri"/> or <paramref name="segments"/> is <see langword="null"/>.
    /// </exception>
    internal static Uri Append(this Uri baseUri, params string[] segments)
    {
        Ensure.NotNull(baseUri, nameof(baseUri));
        Ensure.NotNull(segments, nameof(segments));

        var baseUrl = baseUri.AbsoluteUri;
        var delimiter = baseUrl.Last() == '/' ? string.Empty : "/";

        return $"{baseUrl}{delimiter}{string.Join("/", segments)}".ToAbsoluteUri();
    }

    /// <exception cref = "ArgumentNullException" >
    /// When provided <paramref name="url"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <exception cref = "ArgumentException" >
    /// When provided <paramref name="url"/> isn't a valid absolute URI.
    /// </exception>
    internal static Uri EnsureAbsoluteUri(this Uri url)
    {
        Ensure.NotNull(url, nameof(url));

        return
            url.IsAbsoluteUri
            ? url
            : throw new ArgumentException("Invalid URL format - absolute URL is expected", nameof(url));
    }
}
