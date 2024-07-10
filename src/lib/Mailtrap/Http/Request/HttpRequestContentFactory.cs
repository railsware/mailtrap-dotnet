// -----------------------------------------------------------------------
// <copyright file="HttpRequestContentFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


/// <summary>
/// <see cref="IHttpRequestContentFactory"/> default implementation.
/// </summary>
internal sealed class HttpRequestContentFactory : IHttpRequestContentFactory
{
    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="content"/> is <see langword="null"/>.
    /// </exception>
    public Task<StringContent> CreateStringContentAsync(string content, CancellationToken _ = default)
    {
        Ensure.NotNull(content, nameof(content));

        var httpRequestContent = new StringContent(content).ApplyJsonContentTypeHeader();

        return Task.FromResult(httpRequestContent);
    }
}
