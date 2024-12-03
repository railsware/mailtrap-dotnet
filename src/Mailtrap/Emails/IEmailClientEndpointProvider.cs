// -----------------------------------------------------------------------
// <copyright file="IEmailClientEndpointProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails;


/// <summary>
/// Provider to get request URIs for <see cref="IEmailClient"/>.
/// </summary>
internal interface IEmailClientEndpointProvider
{
    public Uri GetSendRequestUri(bool isBulk, long? inboxId);
}
