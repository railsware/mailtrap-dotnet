using Mailtrap.Webhooks.Models;
using Mailtrap.Webhooks.Requests;


namespace Mailtrap.UnitTests.Webhooks;


[TestFixture]
internal sealed class WebhookInboundFieldsTests
{
    [Test]
    public void Deserialize_InboundReceivingWebhook_MapsTypeAndInboxId()
    {
        var json = """
        {
          "id": 7,
          "url": "https://example.com/inbound",
          "active": true,
          "webhook_type": "inbound_receiving",
          "payload_format": "json",
          "inbound_inbox_id": 42
        }
        """;

        var webhook = JsonSerializer.Deserialize<Webhook>(json, MailtrapJsonSerializerOptions.Default);

        webhook.Should().NotBeNull();
        webhook!.WebhookType.Should().Be(WebhookType.InboundReceiving);
        webhook.InboundInboxId.Should().Be(42);
    }

    [Test]
    public void Serialize_CreateInboundWebhookRequest_WritesInboundInboxId()
    {
        var request = new CreateWebhookRequest
        {
            Url = new Uri("https://example.com/inbound"),
            WebhookType = WebhookType.InboundReceiving,
            InboundInboxId = 42
        };

        var json = JsonSerializer.Serialize(request, MailtrapJsonSerializerOptions.Default);

        using var doc = JsonDocument.Parse(json);
        doc.RootElement.GetProperty("webhook_type").GetString().Should().Be("inbound_receiving");
        doc.RootElement.GetProperty("inbound_inbox_id").GetInt64().Should().Be(42);
    }
}
