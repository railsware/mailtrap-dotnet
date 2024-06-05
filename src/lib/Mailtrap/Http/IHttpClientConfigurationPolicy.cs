// -----------------------------------------------------------------------
// <copyright file="IHttpClientConfigurationPolicy.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http;


internal interface IHttpClientConfigurationPolicy
{
    Task ApplyPolicyAsync(HttpClient httpClient, CancellationToken cancellationToken = default);
}
