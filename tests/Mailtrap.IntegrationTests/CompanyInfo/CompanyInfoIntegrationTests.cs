namespace Mailtrap.IntegrationTests.CompanyInfo;


[TestFixture]
internal sealed class CompanyInfoIntegrationTests
{
    private const string Feature = "CompanyInfo";


    [Test]
    public async Task GetDetails_Success()
    {
        // Arrange
        var random = TestContext.CurrentContext.Random;

        var httpMethod = HttpMethod.Get;
        var domainId = random.NextLong();
        var requestUri = CompanyInfoUri(domainId);

        var token = random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        using var responseContent = await Feature.LoadFileToStringContent();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();


        // Act
        var result = await client
            .CompanyInfo(domainId)
            .GetDetails()
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().NotBeNull();
        result.Name.Should().Be("Mailtrap");
        result.City.Should().Be("San Francisco");
        result.InfoLevel.Should().Be(CompanyInfoLevel.Business);
    }


    [Test]
    public async Task Create_Success()
    {
        // Arrange
        var random = TestContext.CurrentContext.Random;

        var httpMethod = HttpMethod.Post;
        var domainId = random.NextLong();
        var requestUri = CompanyInfoUri(domainId);

        var token = random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        var request = new CreateCompanyInfoRequest
        {
            Name = "Mailtrap",
            Address = "123 Main St",
            City = "San Francisco",
            Country = "US",
            ZipCode = "94105",
            WebsiteUrl = new Uri("https://mailtrap.io"),
            InfoLevel = CompanyInfoLevel.Business
        };

        using var responseContent = await Feature.LoadFileToStringContent();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithJsonContent(request.ToDto(), clientConfig.ToJsonSerializerOptions())
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();


        // Act
        var result = await client
            .CompanyInfo(domainId)
            .Create(request)
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().NotBeNull();
        result.Name.Should().Be("Mailtrap");
    }


    [Test]
    public async Task Update_Success()
    {
        // Arrange
        var random = TestContext.CurrentContext.Random;

        var httpMethod = HttpMethod.Patch;
        var domainId = random.NextLong();
        var requestUri = CompanyInfoUri(domainId);

        var token = random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        var request = new UpdateCompanyInfoRequest
        {
            City = "New York",
            ZipCode = "10001"
        };

        using var responseContent = await Feature.LoadFileToStringContent();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithJsonContent(request.ToDto(), clientConfig.ToJsonSerializerOptions())
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();


        // Act
        var result = await client
            .CompanyInfo(domainId)
            .Update(request)
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().NotBeNull();
    }


    private static string CompanyInfoUri(long domainId)
        => EndpointsTestConstants.ApiDefaultUrl
            .Append(UrlSegmentsTestConstants.ApiRootSegment)
            .Append(UrlSegmentsTestConstants.DomainsSegment)
            .Append(domainId)
            .Append(UrlSegmentsTestConstants.CompanyInfoSegment)
            .AbsoluteUri;
}
