// -----------------------------------------------------------------------
// <copyright file="IAuthenticationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Authentication;


internal interface IAuthenticationProvider
{
    Task AuthenticateRequestAsync(HttpClient httpClient, CancellationToken cancellationToken = default);
}
