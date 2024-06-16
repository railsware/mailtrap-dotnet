// -----------------------------------------------------------------------
// <copyright file="TemplatedSendEmailApiRequestTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture]
internal sealed class TemplatedSendEmailApiRequestTests
{
    private readonly EmailParty _sender = new("sender@domain.com", "Sender");
    private readonly EmailParty _recipient1 = new("recipient1@domain.com", "Recipient 1");
    //private readonly EmailParty _recipient2 = new("recipient2@domain.com", "Recipient 2");
    private readonly string _templateId = "ID";


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenTemplateIdIsNull()
    {
        var act = () => new TemplatedSendEmailApiRequest(_sender, _recipient1, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenTemplateIdIsEmpty()
    {
        var act = () => new TemplatedSendEmailApiRequest(_sender, _recipient1, string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldAssignFieldsCorrectly()
    {
        var request = new TemplatedSendEmailApiRequest(_sender, _recipient1, _templateId);

        request.Sender.Should().BeSameAs(_sender);
        request.TemplateId.Should().BeSameAs(_templateId);

        request.Recipients.Should()
            .ContainSingle().And
            .Contain(_recipient1);

        request.Attachments.Should().BeEmpty();
        request.BlindCarbonCopies.Should().BeEmpty();
        request.CarbonCopies.Should().BeEmpty();
        request.CustomVariables.Should().BeEmpty();
        request.Headers.Should().BeEmpty();
        request.TemplateVariables.Should().BeNull();
    }

    [Test]
    public void ShouldSerializeCorrectly()
    {
        var request = SendEmailApiRequestBuilder
            .Create<TemplatedSendEmailApiRequest>()
            .WithSender("john.doe@demomailtrap.com", "John Doe")
            .WithRecipient("bill.hero@galaxy.com")
            .WithTemplate("ID");

        var serialized = JsonSerializer.Serialize(request, GlobalJsonSerializerOptions.NotIndented);

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
                "\"template_uuid\":\"ID\"" +
            "}");

        var deserialized = JsonSerializer.Deserialize<TemplatedSendEmailApiRequest>(serialized, GlobalJsonSerializerOptions.NotIndented);

        deserialized.Should().BeEquivalentTo(request);
    }
}
