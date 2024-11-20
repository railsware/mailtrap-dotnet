// -----------------------------------------------------------------------
// <copyright file="EmailMessageRequestExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Requests;


internal static class EmailMessageRequestExtensions
{
    public static UpdateEmailMessageRequestDto ToDto(this UpdateEmailMessageRequest request)
    {
        return new UpdateEmailMessageRequestDto
        {
            Message = request
        };
    }
}
