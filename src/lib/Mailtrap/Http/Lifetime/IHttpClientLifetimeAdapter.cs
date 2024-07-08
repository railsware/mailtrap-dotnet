// -----------------------------------------------------------------------
// <copyright file="IHttpClientLifetimeAdapter.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Lifetime;


/// <summary>
/// <see cref="HttpClient"/> adapter to add disposal flexibility.
/// </summary>
public interface IHttpClientLifetimeAdapter : IDisposable
{
    /// <summary>
    /// Returns wrapped <see cref="HttpClient"/> instance.
    /// </summary>
    HttpClient Client { get; }
}
