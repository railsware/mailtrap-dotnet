// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Requests;


[TestFixture]
internal sealed class SendEmailRequestTests
{
    [Test]
    public void ShouldSerializeCorrectly()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .From("john.doe@demomailtrap.com", "John Doe")
            .To("bill.hero@galaxy.com")
            .Subject("Invitation to Earth")
            .Text("Dear Bill, It will be a great pleasure to see you on our blue planet next weekend. Best regards, John.");

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
                "\"subject\":\"Invitation to Earth\"," +
                "\"text\":\"Dear Bill, It will be a great pleasure to see you on our blue planet next weekend. Best regards, John.\"" +
            "}");

        var deserialized = JsonSerializer.Deserialize<SendEmailRequest>(serialized, MailtrapJsonSerializerOptions.NotIndented);

        deserialized.Should().BeEquivalentTo(request);
    }

    [Test]
    public void ShouldSerializeCorrectly_2()
    {
        var request = SendEmailRequestBuilder
            .Email()
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
                "\"template_variables\":{\"Var1\":\"First Name\",\"Var2\":\"Last Name\"}" +
            "}");


        // Below would not work, considering weakly-typed nature of the template variables property.
        //var deserialized = JsonSerializer.Deserialize<TemplatedEmailRequest>(serialized, MailtrapJsonSerializerOptions.NotIndented);
        //deserialized.Should().BeEquivalentTo(request);
    }
}
