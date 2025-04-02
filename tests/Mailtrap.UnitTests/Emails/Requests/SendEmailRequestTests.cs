namespace Mailtrap.UnitTests.Emails.Requests;


[TestFixture]
internal sealed class SendEmailRequestTests
{
    [Test]
    public void Create_ShouldReturnNewInstance_WhenCalled()
    {
        var result = SendEmailRequest.Create();

        result.Should()
            .NotBeNull().And
            .BeOfType<SendEmailRequest>();
    }

    [Test]
    public void ShouldSerializeCorrectly()
    {
        var request = CreateValidRequest();

        var serialized = JsonSerializer.Serialize(request, MailtrapJsonSerializerOptions.NotIndented);

        var deserialized = JsonSerializer.Deserialize<SendEmailRequest>(serialized, MailtrapJsonSerializerOptions.NotIndented);

        deserialized.Should().BeEquivalentTo(request);
    }

    [Test]
    [Ignore("Flaky JSON comparison")]
    public void ShouldSerializeCorrectly_2()
    {
        var request = SendEmailRequest
            .Create()
            .From("john.doe@demomailtrap.com", "John Doe")
            .To("bill.hero@galaxy.com")
            .Template("ID")
            .TemplateVariables(new { Var1 = "First Name", Var2 = "Last Name" });

        var serialized = JsonSerializer.Serialize(request, MailtrapJsonSerializerOptions.NotIndented);

        // TODO: Find more stable way to assert JSON serialization.
        serialized.Should().Be(
            "{" +
                "\"from\":{\"email\":\"john.doe@demomailtrap.com\",\"name\":\"John Doe\"}," +
                "\"to\":[{\"email\":\"bill.hero@galaxy.com\"}]," +
                "\"cc\":[]," +
                "\"bcc\":[]," +
                "\"attachments\":[]," +
                "\"headers\":{}," +
                "\"custom_variables\":{}," +
                "\"template_uuid\":\"ID\"," +
                "\"template_variables\":{\"var1\":\"First Name\",\"var2\":\"Last Name\"}" +
            "}");


        // Below would not work, considering weakly-typed nature of the template variables property.
        //var deserialized = JsonSerializer.Deserialize<TemplatedEmailRequest>(serialized, MailtrapJsonSerializerOptions.NotIndented);
        //deserialized.Should().BeEquivalentTo(request);
    }

    [Test]
    public void Validate_ShouldReturnInvalidResult_WhenRequestIsInvalid()
    {
        var request = SendEmailRequest.Create();

        var result = request.Validate();

        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .NotBeEmpty().And
            .Contain("'From' must not be empty.").And
            .Contain("'Subject' must not be empty.").And
            .Contain("'Text Body' must not be empty.").And
            .Contain("'Html Body' must not be empty.");
    }

    [Test]
    public void Validate_ShouldReturnValidResult_WhenRequestIsValid()
    {
        var request = CreateValidRequest();

        var result = request.Validate();

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }


    private static SendEmailRequest CreateValidRequest()
    {
        return SendEmailRequest
            .Create()
            .From("john.doe@demomailtrap.com", "John Doe")
            .To("bill.hero@galaxy.com")
            .Subject("Invitation to Earth")
            .Text("Dear Bill, It will be a great pleasure to see you on our blue planet next weekend. Best regards, John.");
    }
}
