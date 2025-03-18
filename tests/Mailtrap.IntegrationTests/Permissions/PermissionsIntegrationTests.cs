namespace Mailtrap.IntegrationTests.Permissions;


[TestFixture]
internal sealed class PermissionsIntegrationTests
{
    private const string Feature = "Permissions";


    [Test]
    public async Task GetAll_Success()
    {
        // Arrange
        var random = TestContext.CurrentContext.Random;

        var httpMethod = HttpMethod.Get;
        var accountId = random.NextLong();
        var requestUri = EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.AccountsSegment)
            .Append(accountId)
            .Append(
                UrlSegmentsTestConstants.PermissionsSegment,
                UrlSegmentsTestConstants.PermissionsForResourcesSegment)
            .AbsoluteUri;
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
            .Account(accountId)
            .Permissions()
            .GetAll()
            .ConfigureAwait(false);


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .ContainSingle();
    }
}
