// -----------------------------------------------------------------------
// <copyright file="IHttpRequestMessageAuthenticationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Authentication;


internal interface IHttpRequestMessageAuthenticationProvider
{
    Task AuthenticateAsync(HttpRequestMessage request, CancellationToken cancellationToken = default);
}
