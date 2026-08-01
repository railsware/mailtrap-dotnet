namespace Mailtrap.UnitTests.EmailLogs;


[TestFixture]
internal sealed class EmailLogMessageThreadingFieldsTests
{
    [Test]
    public void Deserialize_MapsThreadingFields()
    {
        var json = """
        {
          "message_id": "abc",
          "status": "delivered",
          "subject": "Hi",
          "rfc_message_id": "<a@b>",
          "in_reply_to": "<c@d>",
          "references": ["<c@d>"],
          "thread_id": "thr_1"
        }
        """;

        var message = JsonSerializer.Deserialize<EmailLogMessage>(json, MailtrapJsonSerializerOptions.Default);

        message.Should().NotBeNull();
        message!.RfcMessageId.Should().Be("<a@b>");
        message.InReplyTo.Should().Be("<c@d>");
        message.References.Should().ContainSingle().Which.Should().Be("<c@d>");
        message.ThreadId.Should().Be("thr_1");
    }
}
