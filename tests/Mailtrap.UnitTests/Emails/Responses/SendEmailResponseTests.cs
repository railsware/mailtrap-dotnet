namespace Mailtrap.UnitTests.Emails.Responses;


[TestFixture]
internal sealed class SendEmailResponseTests
{
    [Test]
    public void CreateSuccess_ShouldInitializeFieldsCorrectly_WhenNoMessageIdsPresent()
    {
        var response = SendEmailResponse.CreateSuccess();

        response.Success.Should().BeTrue();
        response.MessageIds.Should().BeEmpty();
        response.ErrorData.Should().BeEmpty();
    }

    [Test]
    public void CreateSuccess_ShouldInitializeFieldsCorrectly_WhenMessageIdsProvided()
    {
        string[] messageIds = ["id1", "id2"];

        var response = SendEmailResponse.CreateSuccess(messageIds);

        response.Success.Should().BeTrue();
        response.MessageIds.Should().BeEquivalentTo(messageIds);
        response.ErrorData.Should().BeEmpty();
    }

    [Test]
    public void CreateFailure_ShouldInitializeFieldsCorrectly_WhenNoErrorDataProvided()
    {
        var response = SendEmailResponse.CreateFailure();

        response.Success.Should().BeFalse();
        response.MessageIds.Should().BeEmpty();
        response.ErrorData.Should().BeEmpty();
    }

    [Test]
    public void CreateFailure_ShouldInitializeFieldsCorrectly_WhenErrorDataProvided()
    {
        string[] errors = ["error 1", "error 2"];

        var response = SendEmailResponse.CreateFailure(errors);

        response.Success.Should().BeFalse();
        response.MessageIds.Should().BeEmpty();
        response.ErrorData.Should().BeEquivalentTo(errors);
    }

    [Test]
    public void ShouldDeserializeResponse_WhenSuccess()
    {
        var messageId = TestContext.CurrentContext.Random.NextGuid().ToString();
        var responseText =
            "{" +
                "\"success\":true," +
                "\"message_ids\":[" +
                    messageId.AddDoubleQuote() +
                "]" +
            "}";

        var response = JsonSerializer.Deserialize<SendEmailResponse>(responseText, MailtrapJsonSerializerOptions.NotIndented);

        response.Should().NotBeNull();
        response!.Success.Should().BeTrue();
        response!.ErrorData.Should().BeEmpty();
        response!.MessageIds.Should()
            .NotBeNull().And
            .HaveCount(1);
        response!.MessageIds!.Single().Should().Be(messageId);
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

        var response = JsonSerializer.Deserialize<SendEmailResponse>(responseText, MailtrapJsonSerializerOptions.NotIndented);

        response.Should().NotBeNull();
        response!.Success.Should().BeFalse();
        response!.MessageIds.Should().BeEmpty();
        response!.ErrorData.Should()
            .NotBeNull().And
            .HaveCount(3).And
            .ContainInOrder("error 1", "error 2", "error 3");
    }
}
