// -----------------------------------------------------------------------
// <copyright file="StaticHttpClientProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Http;


/// <summary>
/// A simple <see cref="IHttpClientProvider"/> implementation,
/// which returns a static <see cref="HttpClient"/> instance.
/// </summary>
internal sealed class StaticHttpClientProvider : IHttpClientProvider
{
    public HttpClient Client { get; }


    public StaticHttpClientProvider(HttpClient httpClient)
    {
        Ensure.NotNull(httpClient, nameof(httpClient));

        Client = httpClient;
    }
}
