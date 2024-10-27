// -----------------------------------------------------------------------
// <copyright file="EmailClientEndpointProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email;


/// <summary>
/// <see cref="IEmailClientEndpointProvider"/> implementation.
/// </summary>
internal sealed class EmailClientEndpointProvider : IEmailClientEndpointProvider
{
    public Uri GetSendRequestUri(bool isBulk, long? inboxId)
    {
        var rootUrl = inboxId switch
        {
            null => isBulk ? Endpoints.BulkDefaultUrl : Endpoints.SendDefaultUrl,
            _ => Endpoints.TestDefaultUrl,
        };

        var result = rootUrl.Append(UrlSegments.ApiRootSegment, UrlSegments.SendEmailSegment);

        return inboxId is null ? result : result.Append(inboxId.Value);
    }
}
