// -----------------------------------------------------------------------
// <copyright file="IHttpRequestContentFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http;


/// <summary>
/// Factory to spawn <see cref="HttpContent"/> instances.
/// </summary>
internal interface IHttpRequestContentFactory
{
    /// <summary>
    /// Asynchronously creates a new <see cref="StringContent"/> instance, using provided string.
    /// </summary>
    /// 
    /// <param name="content">
    /// </param>
    /// 
    /// <returns>
    /// New <see cref="StringContent"/> instance.
    /// </returns>    
    public StringContent CreateStringContent(string content);
}
