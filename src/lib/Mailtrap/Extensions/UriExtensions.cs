// -----------------------------------------------------------------------
// <copyright file="UriExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Extensions;


/// <summary>
/// A set of helpers for <see cref="Uri"/>
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
    /// When provided <paramref name="baseUrl"/> or <paramref name="segments"/> is <see langword="null"/>.
    /// </exception>
    internal static Uri Append(this Uri baseUrl, params string[] segments)
    {
        Ensure.NotNull(baseUrl, nameof(baseUrl));
        Ensure.NotNull(segments, nameof(segments));

        var url = baseUrl.AbsoluteUri + string.Join("/", segments);
        return url.ToAbsoluteUri();
    }
}
