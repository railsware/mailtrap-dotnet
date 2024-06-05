// -----------------------------------------------------------------------
// <copyright file="TransientHttpClientLifetimeAdapter.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Lifetime;


internal sealed class TransientHttpClientLifetimeAdapter : HttpClientLifetimeAdapter
{
    public TransientHttpClientLifetimeAdapter(HttpClient httpClient) : base(httpClient) { }

    public override void Dispose() => HttpClient.Dispose();
}
