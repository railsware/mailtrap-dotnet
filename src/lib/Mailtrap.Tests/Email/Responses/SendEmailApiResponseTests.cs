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
    public void Constructor_ShouldDefaultFieldsCorrectly_WhenNotSpecified()
    {
        var response = new SendEmailApiResponse(true);

        response.IsSuccess.Should().BeTrue();
        response.MessageIds.Should().BeEmpty();
        response.ErrorData.Should().BeEmpty();
    }

    [Test]
    public void Constructor_ShouldAssignFieldsCorrectly()
    {
        var messageIds = new List<MessageId> { new("1"), new("2") };
        var errorData = new List<string> { "Error 1", "Error 2" };
        var response = new SendEmailApiResponse(true, messageIds, errorData);

        // Assert
        response.IsSuccess.Should().BeTrue();

        response.MessageIds.Should()
            .NotBeNull().And
            .HaveCount(2).And
            .Contain(messageIds);

        response.ErrorData.Should()
            .NotBeEmpty().And
            .HaveCount(2).And
            .Contain(errorData);
    }

    [Test]
    public void ShouldDeserializeResponse_WhenSuccess()
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
        response!.ErrorData.Should().BeEmpty();
        response!.MessageIds.Should()
            .NotBeNull().And
            .HaveCount(1);
        response!.MessageIds!.First().ToString().Should().Be("test_message_id");
    }

    [Test]
    public void ShouldDeserializeResponse_WhenErrors()
    {
        var responseText =
            "{" +
                "\"success\":false," +
                "\"errors\":[" +
                    "\"error 1\"," +
                    "\"error 2\"," +
                    "\"error 3\"" +
                "]" +
            "}";

        var response = JsonSerializer.Deserialize<SendEmailApiResponse>(responseText, GlobalJsonSerializerOptions.NotIndented);

        response.Should().NotBeNull();
        response!.IsSuccess.Should().BeFalse();
        response!.MessageIds.Should().BeEmpty();
        response!.ErrorData.Should()
            .NotBeNull().And
            .HaveCount(3).And
            .ContainInOrder("error 1", "error 2", "error 3");
    }
}
