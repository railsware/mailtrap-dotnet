// -----------------------------------------------------------------------
// <copyright file="IHttpRequestContentFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


public interface IHttpRequestContentFactory
{
    Task<StringContent> CreateAsync(string content);
}
