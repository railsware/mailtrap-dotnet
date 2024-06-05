// -----------------------------------------------------------------------
// <copyright file="IHttpRequestContentBuilder.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


public interface IHttpRequestContentBuilder
{
    Task<StringContent> BuildAsync(string content);
}
