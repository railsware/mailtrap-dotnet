// -----------------------------------------------------------------------
// <copyright file="HttpClientLifetimeAdapter.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Lifetime;


/// <summary>
/// Default abstract implementation of <see cref="IHttpClientLifetimeAdapter"/>.
/// </summary>
internal abstract class HttpClientLifetimeAdapter : IHttpClientLifetimeAdapter
{
    public HttpClient HttpClient { get; }


    public HttpClientLifetimeAdapter(HttpClient httpClient)
    {
        Ensure.NotNull(httpClient, nameof(httpClient));

        HttpClient = httpClient;
    }


    public abstract void Dispose();
}
