// -----------------------------------------------------------------------
// <copyright file="StaticHttpClientLifetimeAdapter.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Lifetime;


/// <summary>
/// Implementation of <see cref="IHttpClientLifetimeAdapter"/> that does not dispose
/// captured <see cref="HttpClient"/> instance, assuming it is externally owned.
/// </summary>
internal sealed class StaticHttpClientLifetimeAdapter : HttpClientLifetimeAdapter
{
    /// <inheritdoc/>
    public StaticHttpClientLifetimeAdapter(HttpClient httpClient) : base(httpClient) { }

    /// <summary>
    /// No-op disposal method, since <see cref="HttpClient"/> is externally owned.
    /// </summary>
    public override void Dispose() { /* NOOP */ }
}
