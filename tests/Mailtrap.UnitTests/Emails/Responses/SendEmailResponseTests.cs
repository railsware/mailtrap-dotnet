namespace Mailtrap.UnitTests.Emails.Responses;


[TestFixture]
internal sealed class SendEmailResponseTests
{
    [Test]
    public void Constructor_ShouldDefaultFieldsCorrectly_WhenNotSpecified()
    {
        var response = new SendEmailResponse(true);

        response.Success.Should().BeTrue();
        response.MessageIds.Should().BeEmpty();
        response.ErrorData.Should().BeEmpty();
    }

    [Test]
    public void Constructor_ShouldAssignFieldsCorrectly()
    {
        var messageIds = new List<string>
        {
            TestContext.CurrentContext.Random.NextGuid().ToString(),
            TestContext.CurrentContext.Random.NextGuid().ToString()
        };
        var errorData = new List<string> { "Error 1", "Error 2" };
        var response = new SendEmailResponse(true, messageIds, errorData);

        // Assert
        response.Success.Should().BeTrue();

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
    public void Empty_ShouldContainCorrectDefaults()
    {
        var response = SendEmailResponse.Empty;

        response.Success.Should().BeFalse();
        response.MessageIds.Should().BeEmpty();
        response.ErrorData.Should()
            .ContainSingle(s => string.Equals(s, "Empty response.", StringComparison.OrdinalIgnoreCase));
    }

    [Test]
    public void Empty_ShouldReturnSameStaticInstance_WhenCalledMultipleTimes()
    {
        var response1 = SendEmailResponse.Empty;
        var response2 = SendEmailResponse.Empty;

        response2.Should().BeSameAs(response1);
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
