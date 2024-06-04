// -----------------------------------------------------------------------
// <copyright file="IHttpClientLifetime.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Contracts;


internal interface IHttpClientLifetimeAdapter : IDisposable
{
    HttpClient GetHttpClient();
}
