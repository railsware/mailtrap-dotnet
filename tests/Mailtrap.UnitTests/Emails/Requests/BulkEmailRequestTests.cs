namespace Mailtrap.UnitTests.Emails.Requests;


[TestFixture]
internal sealed class BulkEmailRequestTests
{
    [Test]
    public void ShouldSerializeCorrectly()
    {
        var request = CreateValidRequest();

        var serialized = JsonSerializer.Serialize(request, MailtrapJsonSerializerOptions.NotIndented);

        var deserialized = JsonSerializer.Deserialize<BulkEmailRequest>(serialized, MailtrapJsonSerializerOptions.NotIndented);

        deserialized.Should().BeEquivalentTo(request);
    }

    [Test]
    public void Validate_ShouldReturnInvalidResult_WhenRequestIsInvalid()
    {
        var request = new BulkEmailRequest();

        var result = request.Validate();

        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .NotBeEmpty().And
            .Contain("'From' must not be empty.").And
            .Contain("'Subject' must not be empty.").And
            .Contain("'Text Body' must not be empty.").And
            .Contain("'Html Body' must not be empty.").And
            .Contain("'Requests' must not be empty.");
    }

    [Test]
    public void Validate_ShouldReturnValidResult_WhenRequestIsValid()
    {
        var request = CreateValidRequest();

        var result = request.Validate();

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }


    private static BulkEmailRequest CreateValidRequest()
    {
        var request = SendEmailRequest
            .Create()
            .From("john.doe@demomailtrap.com", "John Doe")
            .Subject("Invitation to Earth")
            .Text("Dear Bill, It will be a great pleasure to see you on our blue planet next weekend. Best regards, John.");

        return new BulkEmailRequest
        {
            Requests = [request]
        };
    }
}
