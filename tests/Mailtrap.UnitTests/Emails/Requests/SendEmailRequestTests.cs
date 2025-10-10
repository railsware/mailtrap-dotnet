namespace Mailtrap.UnitTests.Emails.Requests;


[TestFixture]
internal sealed class SendEmailRequestTests
{
    [Test]
    public void Create_Should_ReturnNewInstance_WhenCalled()
    {
        var result = SendEmailRequest.Create();

        result.Should()
            .NotBeNull().And
            .BeOfType<SendEmailRequest>();
    }

    [Test]
    public void Should_SerializeAndDeserializeCorrectly()
    {
        var request = CreateValidRequest();

        var serialized = JsonSerializer.Serialize(request, MailtrapJsonSerializerOptions.NotIndented);

        var deserialized = JsonSerializer.Deserialize<SendEmailRequest>(serialized, MailtrapJsonSerializerOptions.NotIndented);

        deserialized.Should().BeEquivalentTo(request);
    }

    [Test]
    [Ignore("Flaky JSON comparison")]
    public void Should_SerializeAndDeserializeCorrectly_2()
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
    public void Validate_Should_Fail_WhenRequestIsInvalid()
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
    public void Validate_Should_Fail_WhenNoRecipients()
    {
        var req = SendEmailRequest.Create();
        req.From = new EmailAddress("from@example.com");
        req.Subject = "Test";
        req.TextBody = "Body";

        var result = req.Validate();

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.Contains("recipient"));
    }

    [Test]
    public void Validate_Should_Fail_WhenRequestIsValid()
    {
        var request = CreateValidRequest();

        var result = request.Validate();

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    [Test]
    public void Validate_Should_Pass_WhenValidRecipients()
    {
        var req = SendEmailRequest.Create();
        req.From = new EmailAddress("from@example.com");
        req.Subject = "Test";
        req.TextBody = "Body";
        req.To.Add(new EmailAddress("to@example.com"));

        var result = req.Validate();

        result.IsValid.Should().BeTrue();
    }

    [TestCase(1001, 0, 0, "To")]
    [TestCase(0, 1001, 0, "Cc")]
    [TestCase(0, 0, 1001, "Bcc")]
    public void Validate_Should_Fail_WhenRecipientsIsNotValid(int toCount, int ccCount, int bccCount, string invalidRecipientType)
    {
        var request = SendEmailRequest.Create();
        request.From = new EmailAddress("from@example.com");
        request.Subject = "Test";
        request.TextBody = "Body";

        request.To = Enumerable.Repeat(new EmailAddress("to@example.com"), toCount).ToList();
        request.Cc = Enumerable.Repeat(new EmailAddress("cc@example.com"), ccCount).ToList();
        request.Bcc = Enumerable.Repeat(new EmailAddress("bcc@example.com"), bccCount).ToList();

        var result = request.Validate();

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.Contains(invalidRecipientType));
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
