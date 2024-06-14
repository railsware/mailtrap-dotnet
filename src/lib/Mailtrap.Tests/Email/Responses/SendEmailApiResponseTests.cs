// -----------------------------------------------------------------------
// <copyright file="SendEmailApiResponseTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Responses;


[TestFixture]
internal sealed class SendEmailApiResponseTests
{
    [Test]
    public void ShouldDeserializeSuccessResponseWithoutErrors()
    {
        var responseText =
            "{" +
                "\"success\":true," +
                "\"message_ids\":[" +
                    "\"test_message_id\"" +
                "]" +
            "}";

        var response = JsonSerializer.Deserialize<SendEmailApiResponse>(responseText, GlobalJsonSerializerOptions.NotIndented);

        response.Should().NotBeNull();
        response!.IsSuccess.Should().BeTrue();
        response!.MessageIds.Should()
            .NotBeNull().And
            .HaveCount(1);
        response!.MessageIds!.First().ToString().Should().Be("test_message_id");
    }
}
