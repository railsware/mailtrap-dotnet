// -----------------------------------------------------------------------
// <copyright file="TestingMessageRequestExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.TestingMessages.Requests;


internal static class TestingMessageRequestExtensions
{
    public static UpdateTestingMessageRequestDto ToDto(this UpdateTestingMessageRequest request)
    {
        return new UpdateTestingMessageRequestDto
        {
            Message = request
        };
    }
}
