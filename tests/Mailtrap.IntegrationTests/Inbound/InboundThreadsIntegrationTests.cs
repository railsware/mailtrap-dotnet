namespace Mailtrap.IntegrationTests.Inbound;


[TestFixture]
internal sealed class InboundThreadsIntegrationTests
{
    private const string Feature = "Inbound/Threads";
    private const string ThreadId = "thr_1";


    private static Uri ThreadsUri(long inboxId)
        => EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.InboundSegment,
                UrlSegmentsTestConstants.InboxesSegment)
            .Append(inboxId)
            .Append(UrlSegmentsTestConstants.ThreadsSegment);


    [Test]
    public async Task List_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var inboxId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = ThreadsUri(inboxId).AbsoluteUri;

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

        var result = await client.Inbound().Inbox(inboxId).Threads().List().ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.Data.Should().HaveCount(2);
        result.TotalCount.Should().Be(2);
        result.LastId.Should().Be("thr_2");
        result.Data[0].Subject.Should().Be("Support request");
        result.Data[0].MessageCount.Should().Be(3);
    }

    [Test]
    public async Task GetDetails_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var inboxId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = ThreadsUri(inboxId).Append(ThreadId).AbsoluteUri;

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

        var result = await client.Inbound().Inbox(inboxId).Thread(ThreadId).GetDetails().ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.Messages.Should().HaveCount(2);
        result.Messages[0].Direction.Should().Be(ThreadMessageDirection.Inbound);
        result.Messages[0].VisibilityStatus.Should().Be(ThreadMessageVisibilityStatus.Available);
        result.Messages[1].Direction.Should().Be(ThreadMessageDirection.Outbound);
        result.Messages[1].DeliveryStatus.Should().Be(EmailLogStatus.Delivered);
    }

    [Test]
    public async Task Delete_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var inboxId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = ThreadsUri(inboxId).Append(ThreadId).AbsoluteUri;

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

        await client.Inbound().Inbox(inboxId).Thread(ThreadId).Delete().ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
    }
}
