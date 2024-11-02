// -----------------------------------------------------------------------
// <copyright file="InboxRequestExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Inboxes.Requests;


internal static class InboxRequestExtensions
{
    public static CreateInboxRequestDto ToDto(this CreateInboxRequest request)
    {
        return new CreateInboxRequestDto
        {
            Inbox = request
        };
    }

    public static UpdateInboxRequestDto ToDto(this UpdateInboxRequest request)
    {
        return new UpdateInboxRequestDto
        {
            Inbox = request
        };
    }
}
