// -----------------------------------------------------------------------
// <copyright file="IHttpRequestMessageBuilder.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


public interface IHttpRequestMessageBuilder
{
    Task<HttpRequestMessage> BuildAsync(HttpMethod method, Uri uri, HttpContent content);
}
