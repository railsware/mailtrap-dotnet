// -----------------------------------------------------------------------
// <copyright file="HttpContentExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Extensions;


/// <summary>
/// A set of helpers for <see cref="HttpContent"/> configuration.
/// </summary>
internal static class HttpContentExtensions
{
    /// <summary>
    /// Applies JSON content type header to the provided <paramref name="content"/> instance.
    /// </summary>
    /// 
    /// <typeparam name="T">
    /// Type of the content.
    /// </typeparam>
    /// 
    /// <param name="content">
    /// Content instance to apply header to.
    /// </param>
    /// 
    /// <returns>
    /// Updated content instance, so calls can be chained.
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="content"/> is <see langword="null"/>.
    /// </exception>
    internal static T ApplyJsonContentTypeHeader<T>(this T content) where T : HttpContent
    {
        Ensure.NotNull(content, nameof(content));

        content.Headers.ContentType = new(MimeTypes.Application.Json);

        return content;
    }
}
