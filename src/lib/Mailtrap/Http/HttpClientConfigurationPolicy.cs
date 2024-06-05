// -----------------------------------------------------------------------
// <copyright file="HttpClientConfigurationPolicy.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http;


internal sealed class HttpClientConfigurationPolicy : IHttpClientConfigurationPolicy
{
    public Task ApplyPolicyAsync(HttpClient httpClient, CancellationToken cancellationToken = default)
    {
        httpClient.WithJsonAcceptHeader();

        return Task.CompletedTask;
    }
}
