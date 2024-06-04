// -----------------------------------------------------------------------
// <copyright file="StaticHttpClientLifetimeAdapter.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System.Diagnostics.CodeAnalysis;


namespace Mailtrap.Behaviors;


internal class StaticHttpClientLifetimeAdapter : IHttpClientLifetimeAdapter
{
    [SuppressMessage(
        "Usage",
        "CA2213:Disposable fields should be disposed",
        Justification =
        "We can't control lifetime of injected HttpClient instance " +
        "because we don't know how it was created.")]
    private readonly HttpClient _httpClient;


    public StaticHttpClientLifetimeAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient.ConfigureAcceptHeader();
    }


    public void Dispose() { /* NOOP*/ }

    public HttpClient GetHttpClient() => _httpClient;
}
