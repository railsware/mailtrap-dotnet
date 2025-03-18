namespace Mailtrap.IntegrationTests.Accounts;


[TestFixture]
internal sealed class AccountsIntegrationTests
{
    private const string Feature = "Accounts";


    [Test]
    public async Task GetAll_Success([Values] AccessLevel accessLevel)
    {
        // Arrange
        var random = TestContext.CurrentContext.Random;

        var httpMethod = HttpMethod.Get;
        var requestUri = EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.AccountsSegment)
            .AbsoluteUri;
        var token = random.GetString();
        var clientConfig = new MailtrapClientOptions(token);

        var accountId = random.NextLong();
        var accountName = random.GetString();
        var accessLevelJson = JsonSerializer.Serialize(accessLevel);
        var responseString =
            $"[{{" +
            $"\"id\":{accountId}," +
            $"\"name\":{accountName.AddDoubleQuote()}," +
            $"\"access_levels\":[{accessLevelJson}]" +
            $"}}]";
        using var responseContent = new StringContent(responseString);

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
            .Accounts()
            .GetAll();


        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .ContainSingle()
       .Which.Should()
            .NotBeNull().And
            .Match<Account>(a =>
                a.Id == accountId &&
                a.Name == accountName &&
                a.AccessLevels.Single() == accessLevel);
    }

    [Test]
    public async Task GetAll_Unauthorized()
    {
        // Arrange
        var random = TestContext.CurrentContext.Random;

        var httpMethod = HttpMethod.Get;
        var requestUri = EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.AccountsSegment)
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
            .Respond(HttpStatusCode.Unauthorized, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();

        var act = () => client.Accounts().GetAll();


        // Assert
        await act.Should()
            .ThrowAsync<HttpRequestFailedException>()
            .WithMessage("*'Incorrect API token'*");

        mockHttp.VerifyNoOutstandingExpectation();
    }
}
