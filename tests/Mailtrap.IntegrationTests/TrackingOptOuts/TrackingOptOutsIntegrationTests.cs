namespace Mailtrap.IntegrationTests.TrackingOptOuts;


[TestFixture]
internal sealed class TrackingOptOutsIntegrationTests
{
    private const string Feature = "TrackingOptOuts";
    private const string EmailQueryParameter = "email";
    private const string StartTimeQueryParameter = "start_time";
    private const string EndTimeQueryParameter = "end_time";
    private const string LastIdQueryParameter = "last_id";

    private readonly Uri _resourceUri;
    private readonly MailtrapClientOptions _clientConfig;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public TrackingOptOutsIntegrationTests()
    {
        var random = TestContext.CurrentContext.Random;

        _resourceUri = EndpointsTestConstants.ApiDefaultUrl
            .Append(UrlSegmentsTestConstants.ApiRootSegment)
            .Append(UrlSegmentsTestConstants.TrackingOptOutsSegment);

        var token = random.GetString();
        _clientConfig = new MailtrapClientOptions(token);
        _jsonSerializerOptions = _clientConfig.ToJsonSerializerOptions();
    }


    [Test]
    public async Task Fetch_WithoutFilter_Success()
    {
        // Arrange
        using var responseContent = await Feature.LoadFileToStringContent();
        var expectedResponse = await responseContent.DeserializeStringContentAsync<TrackingOptOutList>(_jsonSerializerOptions);
        expectedResponse.Should().NotBeNull();

        using var mockHttp = new MockHttpMessageHandler();
        using var clientScope = mockHttp.ConfigureAndCreateClient(
            HttpMethod.Get,
            _resourceUri.AbsoluteUri,
            responseContent,
            HttpStatusCode.OK,
            _clientConfig);

        // Act
        var result = await clientScope.Client
            .TrackingOptOuts()
            .Fetch()
            .ConfigureAwait(false);

        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().BeEquivalentTo(expectedResponse);
    }


    [Test]
    public async Task Fetch_WithFilter_Success()
    {
        // Arrange
        var filter = new TrackingOptOutFilter
        {
            Email = "recipient1@example.com",
            StartTime = new DateTimeOffset(2025, 9, 1, 0, 0, 0, TimeSpan.Zero),
            EndTime = new DateTimeOffset(2025, 9, 30, 0, 0, 0, TimeSpan.Zero),
            LastId = "0198f1c4-0c0f-7a1c-8b0e-3f5d2a1b4c6d"
        };

        using var responseContent = await Feature.LoadFileToStringContent();
        var expectedResponse = await responseContent.DeserializeStringContentAsync<TrackingOptOutList>(_jsonSerializerOptions);
        expectedResponse.Should().NotBeNull();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(HttpMethod.Get, _resourceUri.AbsoluteUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithExactQueryString(new Dictionary<string, string>
            {
                [EmailQueryParameter] = filter.Email,
                [StartTimeQueryParameter] = filter.StartTime.Value.ToString("O"),
                [EndTimeQueryParameter] = filter.EndTime.Value.ToString("O"),
                [LastIdQueryParameter] = filter.LastId
            })
            .Respond(HttpStatusCode.OK, responseContent);

        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();

        var client = services.GetRequiredService<IMailtrapClient>();

        // Act
        var result = await client
            .TrackingOptOuts()
            .Fetch(filter)
            .ConfigureAwait(false);

        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().BeEquivalentTo(expectedResponse);
    }


    [Test]
    public async Task Create_Success()
    {
        // Arrange
        var request = new CreateTrackingOptOutRequest
        {
            Email = "recipient1@example.com",
            DomainId = 42
        };

        using var responseContent = await Feature.LoadFileToStringContent();
        var expectedResponse = await responseContent.DeserializeStringContentAsync<TrackingOptOutResponseDto>(_jsonSerializerOptions);
        expectedResponse.Should().NotBeNull();

        using var mockHttp = new MockHttpMessageHandler();
        using var clientScope = mockHttp.ConfigureAndCreateClient(
            HttpMethod.Post,
            _resourceUri.AbsoluteUri,
            responseContent,
            HttpStatusCode.OK,
            _clientConfig,
            request);

        // Act
        var result = await clientScope.Client
            .TrackingOptOuts()
            .Create(request)
            .ConfigureAwait(false);

        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().BeEquivalentTo(expectedResponse.TrackingOptOut);
    }


    [Test]
    public async Task Delete_Success()
    {
        // Arrange
        var trackingOptOutId = TestContext.CurrentContext.Random.NextGuid().ToString();
        var requestUri = _resourceUri.Append(trackingOptOutId).AbsoluteUri;

        using var responseContent = await Feature.LoadFileToStringContent();
        var expectedResponse = await responseContent.DeserializeStringContentAsync<TrackingOptOut>(_jsonSerializerOptions);
        expectedResponse.Should().NotBeNull();

        using var mockHttp = new MockHttpMessageHandler();
        using var clientScope = mockHttp.ConfigureAndCreateClient(
            HttpMethod.Delete,
            requestUri,
            responseContent,
            HttpStatusCode.OK,
            _clientConfig);

        // Act
        var result = await clientScope.Client
            .TrackingOptOut(trackingOptOutId)
            .Delete()
            .ConfigureAwait(false);

        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().BeEquivalentTo(expectedResponse);
    }
}
