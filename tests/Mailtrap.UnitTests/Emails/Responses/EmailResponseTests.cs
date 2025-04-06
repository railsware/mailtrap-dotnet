namespace Mailtrap.UnitTests.Emails.Responses;


[TestFixture]
internal sealed class EmailResponseTests
{
    [Test]
    public void CreateFailure_ShouldInitializeFieldsCorrectly_WhenNoErrorDataProvided()
    {
        var response = EmailResponse.CreateFailure();

        response.Success.Should().BeFalse();
        response.ErrorData.Should().BeEmpty();
    }

    [Test]
    public void CreateFailure_ShouldInitializeFieldsCorrectly_WhenErrorDataProvided()
    {
        string[] errors = ["error 1", "error 2"];

        var response = EmailResponse.CreateFailure(errors);

        response.Success.Should().BeFalse();
        response.ErrorData.Should().BeEquivalentTo(errors);
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

        var response = JsonSerializer.Deserialize<EmailResponse>(responseText, MailtrapJsonSerializerOptions.NotIndented);

        response.Should().NotBeNull();
        response!.Success.Should().BeFalse();
        response!.ErrorData.Should()
            .NotBeNull().And
            .HaveCount(3).And
            .ContainInOrder("error 1", "error 2", "error 3");
    }
}
