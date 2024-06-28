// -----------------------------------------------------------------------
// <copyright file="HttpRequestContentFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


internal sealed class HttpRequestContentFactory : IHttpRequestContentFactory
{
    public Task<StringContent> CreateAsync(string content, CancellationToken _ = default)
    {
        Ensure.NotNull(content, nameof(content));

        var httpRequestContent = new StringContent(content).ApplyJsonContentTypeHeader();

        return Task.FromResult(httpRequestContent);
    }
}
