namespace Mailtrap.UnitTests.Emails.Responses;


[TestFixture]
internal sealed class BatchEmailResponseTests
{
    [Test]
    public void CreateSuccess_ShouldInitializeFieldsCorrectly_WhenNoMessageIdsPresent()
    {
        var response = BatchEmailResponse.CreateSuccess();

        response.Success.Should().BeTrue();
        response.Responses.Should().BeEmpty();
        response.ErrorData.Should().BeEmpty();
    }

    [Test]
    public void CreateSuccess_ShouldInitializeFieldsCorrectly_WhenMessageIdsProvided()
    {
        SendEmailResponse[] responses =
            [
                SendEmailResponse.CreateSuccess("id1", "id2"),
                SendEmailResponse.CreateSuccess("id3")
            ];

        var response = BatchEmailResponse.CreateSuccess(responses);

        response.Success.Should().BeTrue();
        response.Responses.Should().BeEquivalentTo(responses);
        response.ErrorData.Should().BeEmpty();
    }

    [Test]
    public void ShouldDeserializeResponse_WhenSuccess()
    {
        var messageId = TestContext.CurrentContext.Random.NextGuid().ToString();
        var responseText =
            "{" +
                "\"success\":true," +
                "\"responses\":[" +
                    "{" +
                        "\"success\":true," +
                        "\"message_ids\":[" +
                            messageId.AddDoubleQuote() +
                        "]" +
                    "}" +
                "]" +
            "}";

        var response = JsonSerializer.Deserialize<BatchEmailResponse>(responseText, MailtrapJsonSerializerOptions.NotIndented);

        response.Should().NotBeNull();
        response.Success.Should().BeTrue();
        response.ErrorData.Should().BeEmpty();
        response.Responses.Should()
            .NotBeNull().And
            .ContainSingle();

        var messageResponse = response.Responses.Single();

        messageResponse.Success.Should().BeTrue();
        messageResponse.ErrorData.Should().BeEmpty();
        messageResponse.MessageIds.Should()
            .NotBeNull().And
            .ContainSingle();

        messageResponse.MessageIds.Single().Should().Be(messageId);
    }
}
