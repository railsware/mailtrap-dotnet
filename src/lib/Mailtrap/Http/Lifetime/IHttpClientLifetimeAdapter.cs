// -----------------------------------------------------------------------
// <copyright file="IHttpClientLifetimeAdapter.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Lifetime;


public interface IHttpClientLifetimeAdapter : IDisposable
{
    HttpClient HttpClient { get; }
}
