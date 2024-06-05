// -----------------------------------------------------------------------
// <copyright file="IHttpRequestMessageConfigurationPolicy.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


internal interface IHttpRequestMessageConfigurationPolicy
{
    Task ApplyPolicyAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken = default);
}
