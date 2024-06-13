// -----------------------------------------------------------------------
// <copyright file="EmailSendApiRequestTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Tests.Email.Requests;


[TestFixture]
internal sealed class EmailSendApiRequestTests
{
    private static readonly JsonSerializerOptions s_serializerOptions = new()
    {
        WriteIndented = false // Override indentation to ensure desired output for tests
    };

    [Test]
    public void ShouldSerializeCorrectly()
    {
        var request = SendEmailApiRequestBuilder
            .Create<RegularSendEmailApiRequest>()
            .WithSender("john.doe@demomailtrap.com", "John Doe")
            .WithSubject("Invitation to Earth")
            .WithRecipient("bill.hero@galaxy.com")
            .WithTextBody("Dear Bill, It will be a great pleasure to see you on our blue planet next weekend. Best regards, John.");

        var serialized = JsonSerializer.Serialize(request, s_serializerOptions);

        serialized.Should().Be(
            "{" +
                "\"from\":{\"email\":\"john.doe@demomailtrap.com\",\"name\":\"John Doe\"}," +
                "\"to\":[{\"email\":\"bill.hero@galaxy.com\",\"name\":null}]," +
                "\"subject\":\"Invitation to Earth\"," +
                "\"text\":\"Dear Bill, It will be a great pleasure to see you on our blue planet next weekend. Best regards, John.\"," +
                "\"html\":null," +
                "\"attachments\":[]" +
            "}");
    }
}
