// -----------------------------------------------------------------------
// <copyright file="HttpContentExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Extensions;


/// <summary>
/// A set of helpers for <see cref="HttpContent"/> configuration.
/// </summary>
internal static class HttpContentExtensions
{
    /// <summary>
    /// Applies JSON content type header to the provided <paramref name="content"/> instance.
    /// </summary>
    /// <typeparam name="T">Type of the content.</typeparam>
    /// <param name="content"></param>
    /// <returns><see cref="HttpContent"/> instance, so calls can be chained.</returns>
    internal static T ApplyJsonContentTypeHeader<T>(this T content) where T : HttpContent
    {
        Ensure.NotNull(content, nameof(content));

        content.Headers.ContentType = new(MimeTypes.Application.Json);

        return content;
    }
}
