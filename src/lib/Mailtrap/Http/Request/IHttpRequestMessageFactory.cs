// -----------------------------------------------------------------------
// <copyright file="IHttpRequestMessageFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


public interface IHttpRequestMessageFactory
{
    Task<HttpRequestMessage> CreateAsync(HttpMethod method, Uri uri, HttpContent content);
}
