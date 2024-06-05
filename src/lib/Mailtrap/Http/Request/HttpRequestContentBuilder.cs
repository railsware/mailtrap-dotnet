// -----------------------------------------------------------------------
// <copyright file="HttpRequestContentBuilder.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


internal sealed class HttpRequestContentBuilder : IHttpRequestContentBuilder
{
    public Task<StringContent> BuildAsync(string content)
    {
        var httpRequestContent = new StringContent(content).ApplyJsonContentTypeHeader();

        return Task.FromResult(httpRequestContent);
    }
}
