namespace Mailtrap.IntegrationTests.Inbound;


[TestFixture]
internal sealed class InboundInboxesIntegrationTests
{
    private const string Feature = "Inbound/Inboxes";


    private static Uri InboxesUri(long folderId)
        => EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.InboundSegment,
                UrlSegmentsTestConstants.FoldersSegment)
            .Append(folderId)
            .Append(UrlSegmentsTestConstants.InboxesSegment);


    [Test]
    public async Task GetAll_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var folderId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = InboxesUri(folderId).AbsoluteUri;

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

        var result = await client.Inbound().Folder(folderId).Inboxes().GetAll().ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.Should().NotBeNull().And.HaveCount(2);
        result[0].Address.Should().Be("support@inbound-mailtrap.io");
        result[0].DomainId.Should().BeNull();
        result[1].DomainId.Should().Be(6);
    }

    [Test]
    public async Task GetDetails_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var folderId = TestContext.CurrentContext.Random.NextLong();
        var inboxId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = InboxesUri(folderId).Append(inboxId).AbsoluteUri;

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

        var result = await client.Inbound().Folder(folderId).Inbox(inboxId).GetDetails().ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.Id.Should().Be(201);
        result.Address.Should().Be("support@inbound-mailtrap.io");
    }

    [Test]
    public async Task Create_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var folderId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = InboxesUri(folderId).AbsoluteUri;
        var request = new CreateInboundInboxRequest { Name = "Custom domain inbox", DomainId = 6 };

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

        var result = await client.Inbound().Folder(folderId).Inboxes().Create(request).ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.DomainId.Should().Be(6);
    }

    [Test]
    public async Task Update_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var folderId = TestContext.CurrentContext.Random.NextLong();
        var inboxId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = InboxesUri(folderId).Append(inboxId).AbsoluteUri;
        var request = new UpdateInboundInboxRequest { Name = "Renamed inbox" };

        using var responseContent = await Feature.LoadFileToStringContent();
        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(HttpMethod.Patch, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .WithJsonContent(request, clientConfig.ToJsonSerializerOptions())
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);
        using var services = serviceCollection.BuildServiceProvider();
        var client = services.GetRequiredService<IMailtrapClient>();

        var result = await client.Inbound().Folder(folderId).Inbox(inboxId).Update(request).ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.Name.Should().Be("Renamed inbox");
    }

    [Test]
    public async Task Delete_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var folderId = TestContext.CurrentContext.Random.NextLong();
        var inboxId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = InboxesUri(folderId).Append(inboxId).AbsoluteUri;

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

        await client.Inbound().Folder(folderId).Inbox(inboxId).Delete().ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
    }
}
