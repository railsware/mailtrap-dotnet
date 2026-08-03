namespace Mailtrap.IntegrationTests.Inbound;


[TestFixture]
internal sealed class InboundMessagesIntegrationTests
{
    private const string Feature = "Inbound/Messages";
    private const string MessageId = "1700000000000123";


    private static Uri MessagesUri(long inboxId)
        => EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.InboundSegment,
                UrlSegmentsTestConstants.InboxesSegment)
            .Append(inboxId)
            .Append(UrlSegmentsTestConstants.MessagesSegment);

    private static Uri MessageUri(long inboxId)
        => MessagesUri(inboxId).Append(MessageId);


    [Test]
    public async Task List_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var inboxId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = MessagesUri(inboxId).AbsoluteUri;

        using var responseContent = await Feature.LoadFileToStringContent();
        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(HttpMethod.Get, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);
        using var services = serviceCollection.BuildServiceProvider();
        var client = services.GetRequiredService<IMailtrapClient>();

        var result = await client.Inbound().Inbox(inboxId).Messages().List().ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.Data.Should().HaveCount(2);
        result.TotalCount.Should().Be(2);
        result.LastId.Should().Be("msg_2");
        result.Data[0].ThreadId.Should().Be("thr_1");
        result.Data[0].RfcMessageId.Should().Be("<abc123@example.com>");
    }

    [Test]
    public async Task List_WithCursor_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var inboxId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = MessagesUri(inboxId)
            .AppendQueryParameters([new KeyValuePair<string, string>("last_id", "msg_2")])
            .AbsoluteUri;

        using var responseContent = await Feature.LoadFileToStringContent();
        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(HttpMethod.Get, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);
        using var services = serviceCollection.BuildServiceProvider();
        var client = services.GetRequiredService<IMailtrapClient>();

        var result = await client.Inbound().Inbox(inboxId).Messages().List("msg_2").ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.Data.Should().HaveCount(2);
    }

    [Test]
    public async Task GetDetails_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var inboxId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = MessageUri(inboxId).AbsoluteUri;

        using var responseContent = await Feature.LoadFileToStringContent();
        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(HttpMethod.Get, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);
        using var services = serviceCollection.BuildServiceProvider();
        var client = services.GetRequiredService<IMailtrapClient>();

        var result = await client.Inbound().Inbox(inboxId).Message(MessageId).GetDetails().ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.HtmlBody.Should().Be("<p>Hello, I need help.</p>");
        result.Attachments.Should().ContainSingle();
        result.Attachments[0].DownloadUrl.Should().Be("https://example.com/download/att_1");
        result.ThreadId.Should().Be("thr_1");
    }

    [Test]
    public async Task Delete_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var inboxId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = MessageUri(inboxId).AbsoluteUri;

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(HttpMethod.Delete, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .Respond(HttpStatusCode.NoContent);

        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);
        using var services = serviceCollection.BuildServiceProvider();
        var client = services.GetRequiredService<IMailtrapClient>();

        await client.Inbound().Inbox(inboxId).Message(MessageId).Delete().ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Test]
    public async Task Reply_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var inboxId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = MessageUri(inboxId).Append(UrlSegmentsTestConstants.ReplySegment).AbsoluteUri;
        var request = new ReplyInboundMessageRequest
        {
            To = [new EmailAddress("customer@example.com")],
            Text = "Thanks for reaching out!"
        };

        using var responseContent = await Feature.LoadFileToStringContent();
        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(HttpMethod.Post, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .WithJsonContent(request, clientConfig.ToJsonSerializerOptions())
            .Respond(HttpStatusCode.Created, responseContent);

        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);
        using var services = serviceCollection.BuildServiceProvider();
        var client = services.GetRequiredService<IMailtrapClient>();

        var result = await client.Inbound().Inbox(inboxId).Message(MessageId).Reply(request).ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.MessageIds.Should().ContainSingle().Which.Should().Be("0000000000000001");
    }

    [Test]
    public async Task ReplyAll_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var inboxId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = MessageUri(inboxId).Append(UrlSegmentsTestConstants.ReplyAllSegment).AbsoluteUri;
        var request = new ReplyInboundMessageRequest { Text = "Looping everyone in." };

        using var responseContent = await Feature.LoadFileToStringContent();
        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(HttpMethod.Post, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .WithJsonContent(request, clientConfig.ToJsonSerializerOptions())
            .Respond(HttpStatusCode.Created, responseContent);

        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);
        using var services = serviceCollection.BuildServiceProvider();
        var client = services.GetRequiredService<IMailtrapClient>();

        var result = await client.Inbound().Inbox(inboxId).Message(MessageId).ReplyAll(request).ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.MessageIds.Should().ContainSingle();
    }

    [Test]
    public async Task Forward_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var inboxId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = MessageUri(inboxId).Append(UrlSegmentsTestConstants.ForwardSegment).AbsoluteUri;
        var request = new ForwardInboundMessageRequest
        {
            To = [new EmailAddress("teammate@example.com")],
            Text = "Please take a look."
        };

        using var responseContent = await Feature.LoadFileToStringContent();
        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(HttpMethod.Post, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .WithJsonContent(request, clientConfig.ToJsonSerializerOptions())
            .Respond(HttpStatusCode.Created, responseContent);

        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);
        using var services = serviceCollection.BuildServiceProvider();
        var client = services.GetRequiredService<IMailtrapClient>();

        var result = await client.Inbound().Inbox(inboxId).Message(MessageId).Forward(request).ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.MessageIds.Should().ContainSingle();
    }

    [Test]
    public async Task Forward_ShouldThrowValidationException_WhenToIsEmpty()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var inboxId = TestContext.CurrentContext.Random.NextLong();
        var request = new ForwardInboundMessageRequest { Text = "FYI" };

        using var mockHttp = new MockHttpMessageHandler();

        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);
        using var services = serviceCollection.BuildServiceProvider();
        var client = services.GetRequiredService<IMailtrapClient>();

        var act = () => client.Inbound().Inbox(inboxId).Message(MessageId).Forward(request);

        await act.Should().ThrowAsync<RequestValidationException>();
        mockHttp.VerifyNoOutstandingExpectation();
    }
}
