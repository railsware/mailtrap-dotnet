namespace Mailtrap.IntegrationTests.Inbound;


[TestFixture]
internal sealed class InboundFoldersIntegrationTests
{
    private const string Feature = "Inbound/Folders";


    private static Uri FoldersUri()
        => EndpointsTestConstants.ApiDefaultUrl.Append(
            UrlSegmentsTestConstants.ApiRootSegment,
            UrlSegmentsTestConstants.InboundSegment,
            UrlSegmentsTestConstants.FoldersSegment);


    [Test]
    public async Task GetAll_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var requestUri = FoldersUri().AbsoluteUri;

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

        var result = await client.Inbound().Folders().GetAll().ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.Should().NotBeNull().And.HaveCount(2);
        result[0].Name.Should().Be("Support");
    }

    [Test]
    public async Task GetDetails_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var folderId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = FoldersUri().Append(folderId).AbsoluteUri;

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

        var result = await client.Inbound().Folder(folderId).GetDetails().ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.Should().NotBeNull();
        result.Id.Should().Be(101);
        result.Name.Should().Be("Support");
    }

    [Test]
    public async Task Create_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var requestUri = FoldersUri().AbsoluteUri;
        var request = new CreateInboundFolderRequest { Name = "Support" };

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

        var result = await client.Inbound().Folders().Create(request).ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.Should().NotBeNull();
        result.Name.Should().Be("Support");
    }

    [Test]
    public async Task Update_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var folderId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = FoldersUri().Append(folderId).AbsoluteUri;
        var request = new UpdateInboundFolderRequest { Name = "Renamed folder" };

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

        var result = await client.Inbound().Folder(folderId).Update(request).ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
        result.Name.Should().Be("Renamed folder");
    }

    [Test]
    public async Task Delete_Success()
    {
        var clientConfig = new MailtrapClientOptions(TestContext.CurrentContext.Random.GetString());
        var folderId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = FoldersUri().Append(folderId).AbsoluteUri;

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

        await client.Inbound().Folder(folderId).Delete().ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
    }
}
