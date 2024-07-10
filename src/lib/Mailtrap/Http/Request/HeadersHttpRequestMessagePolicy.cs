// -----------------------------------------------------------------------
// <copyright file="HeadersHttpRequestMessagePolicy.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


/// <summary>
/// <see cref="IHttpRequestMessagePolicy"/> implementation that applies headers to the request,
/// required by Mailtrap API.
/// </summary>
internal sealed class HeadersHttpRequestMessagePolicy : IHttpRequestMessagePolicy
{
    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    public Task ApplyPolicyAsync(HttpRequestMessage request, CancellationToken _ = default)
    {
        Ensure.NotNull(request, nameof(request));

        request.ConfigureAcceptHeader();

        return Task.CompletedTask;
    }
}
