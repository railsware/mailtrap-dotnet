// -----------------------------------------------------------------------
// <copyright file="TransientHttpClientLifetimeAdapter.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Lifetime;


/// <summary>
/// Implementation of <see cref="IHttpClientLifetimeAdapter"/> that disposes
/// captured <see cref="HttpClient"/> instance, assuming it is transient.
/// </summary>
internal sealed class TransientHttpClientLifetimeAdapter : HttpClientLifetimeAdapter
{
    /// <inheritdoc/>
    public TransientHttpClientLifetimeAdapter(HttpClient httpClient) : base(httpClient) { }

    /// <summary>
    /// Disposes captured <see cref="HttpClient"/> instance.
    /// </summary>
    public override void Dispose() => Client.Dispose();
}
