// -----------------------------------------------------------------------
// <copyright file="RegularSendEmailApiRequestTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture]
internal sealed class RegularSendEmailApiRequestTests
{
    private readonly EmailParty _sender = new("sender@domain.com", "Sender");
    private readonly EmailParty _recipient1 = new("recipient1@domain.com", "Recipient 1");
    //private readonly EmailParty _recipient2 = new("recipient2@domain.com", "Recipient 2");
    private readonly string _subject = "Email Subject";


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenSubjectIsNull()
    {
        var act = () => new RegularSendEmailApiRequest(_sender, _recipient1, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenSubjectIsEmpty()
    {
        var act = () => new RegularSendEmailApiRequest(_sender, _recipient1, string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldAssignFieldsCorrectly()
    {
        var request = new RegularSendEmailApiRequest(_sender, _recipient1, _subject);

        request.Sender.Should().BeSameAs(_sender);
        request.Subject.Should().BeSameAs(_subject);

        request.Recipients.Should()
            .ContainSingle().And
            .Contain(_recipient1);

        request.Attachments.Should().BeEmpty();
        request.BlindCarbonCopies.Should().BeEmpty();
        request.CarbonCopies.Should().BeEmpty();
        request.Category.Should().BeNull();
        request.CustomVariables.Should().BeEmpty();
        request.Headers.Should().BeEmpty();
        request.HtmlBody.Should().BeNull();
        request.TextBody.Should().BeNull();
    }

    [Test]
    public void ShouldSerializeCorrectly()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithSender("john.doe@demomailtrap.com", "John Doe")
            .WithSubject("Invitation to Earth")
            .WithRecipient("bill.hero@galaxy.com")
            .WithTextBody("Dear Bill, It will be a great pleasure to see you on our blue planet next weekend. Best regards, John.");

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
                "\"subject\":\"Invitation to Earth\"," +
                "\"text\":\"Dear Bill, It will be a great pleasure to see you on our blue planet next weekend. Best regards, John.\"" +
            "}");

        var deserialized = JsonSerializer.Deserialize<RegularSendEmailApiRequest>(serialized, GlobalJsonSerializerOptions.NotIndented);

        deserialized.Should().BeEquivalentTo(request);
    }
}
