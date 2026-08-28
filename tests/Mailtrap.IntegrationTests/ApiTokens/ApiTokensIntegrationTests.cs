namespace Mailtrap.IntegrationTests.ApiTokens;


[TestFixture]
internal sealed class ApiTokensIntegrationTests
{
    private const string Feature = "ApiTokens";
    private const string ResetSegment = "reset";

    private readonly long _accountId;
    private readonly Uri _resourceUri;
    private readonly MailtrapClientOptions _clientConfig;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ApiTokensIntegrationTests()
    {
        var random = TestContext.CurrentContext.Random;

        _accountId = random.NextLong();
        _resourceUri = EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.AccountsSegment)
            .Append(_accountId)
            .Append(UrlSegmentsTestConstants.ApiTokensSegment);

        var token = random.GetString();
        _clientConfig = new MailtrapClientOptions(token);
        _jsonSerializerOptions = _clientConfig.ToJsonSerializerOptions();
    }


    [Test]
    public async Task GetAll_Success()
    {
        // Arrange
        using var responseContent = await Feature.LoadFileToStringContent();
        var expectedResponse = await responseContent.DeserializeStringContentAsync<List<ApiToken>>(_jsonSerializerOptions);
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
            .Account(_accountId)
            .ApiTokens()
            .GetAll()
            .ConfigureAwait(false);

        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().BeEquivalentTo(expectedResponse);
    }

    [Test]
    public async Task Create_Success()
    {
        // Arrange
        var request = new CreateApiTokenRequest { Name = "My API Token" };
        request.Resources.Add(new ApiTokenAccessRequest(ResourceType.Account, 3229, AccessLevel.Admin));

        using var responseContent = await Feature.LoadFileToStringContent();
        var expectedResponse = await responseContent.DeserializeStringContentAsync<CreateApiTokenResponse>(_jsonSerializerOptions);
        expectedResponse.Should().NotBeNull();

        using var mockHttp = new MockHttpMessageHandler();
        using var clientScope = mockHttp.ConfigureAndCreateClient(
            HttpMethod.Post,
            _resourceUri.AbsoluteUri,
            responseContent,
            HttpStatusCode.OK,
            _clientConfig);

        // Act
        var result = await clientScope.Client
            .Account(_accountId)
            .ApiTokens()
            .Create(request)
            .ConfigureAwait(false);

        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().BeEquivalentTo(expectedResponse);
    }

    [Test]
    public async Task Create_WithExpiration_Success()
    {
        // Arrange
        var request = new CreateApiTokenRequest
        {
            Name = "My API Token",
            ExpiresAt = ApiTokenExpiration.At(DateTimeOffset.Parse("2027-06-01T00:00:00Z", CultureInfo.InvariantCulture))
        };
        request.Resources.Add(new ApiTokenAccessRequest(ResourceType.Account, 3229, AccessLevel.Admin));

        const string expectedRequestBody =
            """{"name":"My API Token","expires_at":"2027-06-01T00:00:00+00:00","resources":[{"resource_type":"account","resource_id":3229,"access_level":100}]}""";

        // Act
        var result = await RunCreateSuccessAsync(request, expectedRequestBody);

        // Assert
        result.ExpiresAt.Should().Be(DateTimeOffset.Parse("2027-06-01T00:00:00Z", CultureInfo.InvariantCulture));
    }

    [Test]
    public async Task Create_WithNeverExpiration_Success()
    {
        // Arrange
        var request = new CreateApiTokenRequest
        {
            Name = "My API Token",
            ExpiresAt = ApiTokenExpiration.Never
        };
        request.Resources.Add(new ApiTokenAccessRequest(ResourceType.Account, 3229, AccessLevel.Admin));

        const string expectedRequestBody =
            """{"name":"My API Token","expires_at":null,"resources":[{"resource_type":"account","resource_id":3229,"access_level":100}]}""";

        // Act
        var result = await RunCreateSuccessAsync(request, expectedRequestBody);

        // Assert
        result.ExpiresAt.Should().BeNull();
    }

    [Test]
    public async Task Create_ShouldThrow_WhenExpirationIsRejected()
    {
        // Arrange
        var request = new CreateApiTokenRequest
        {
            Name = "My API Token",
            ExpiresAt = ApiTokenExpiration.At(DateTimeOffset.Parse("2020-01-01T00:00:00Z", CultureInfo.InvariantCulture))
        };
        request.Resources.Add(new ApiTokenAccessRequest(ResourceType.Account, 3229, AccessLevel.Admin));

        const string expectedRequestBody =
            """{"name":"My API Token","expires_at":"2020-01-01T00:00:00+00:00","resources":[{"resource_type":"account","resource_id":3229,"access_level":100}]}""";

        using var responseContent = await Feature.LoadFileToStringContent();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(HttpMethod.Post, _resourceUri.AbsoluteUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithContent(expectedRequestBody)
            .Respond(HttpStatusCode.UnprocessableEntity, responseContent);

        using var services = BuildServiceProvider(mockHttp);
        var client = services.GetRequiredService<IMailtrapClient>();

        // Act
        var act = () => client
            .Account(_accountId)
            .ApiTokens()
            .Create(request);

        // Assert
        var assertion = await act.Should().ThrowAsync<HttpRequestFailedException>();
        assertion.Which.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        assertion.Which.Message.Should().Contain("Expiration date must be in the future");

        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Test]
    public async Task GetDetails_Success()
    {
        // Arrange
        var apiTokenId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = _resourceUri.Append(apiTokenId).AbsoluteUri;

        using var responseContent = await Feature.LoadFileToStringContent();
        var expectedResponse = await responseContent.DeserializeStringContentAsync<ApiToken>(_jsonSerializerOptions);
        expectedResponse.Should().NotBeNull();

        using var mockHttp = new MockHttpMessageHandler();
        using var clientScope = mockHttp.ConfigureAndCreateClient(
            HttpMethod.Get,
            requestUri,
            responseContent,
            HttpStatusCode.OK,
            _clientConfig);

        // Act
        var result = await clientScope.Client
            .Account(_accountId)
            .ApiToken(apiTokenId)
            .GetDetails()
            .ConfigureAwait(false);

        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().BeEquivalentTo(expectedResponse);
    }

    [Test]
    public async Task Delete_Success()
    {
        // Arrange
        var apiTokenId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = _resourceUri.Append(apiTokenId).AbsoluteUri;

        using var responseContent = new StringContent(string.Empty);

        using var mockHttp = new MockHttpMessageHandler();
        using var clientScope = mockHttp.ConfigureAndCreateClient(
            HttpMethod.Delete,
            requestUri,
            responseContent,
            HttpStatusCode.NoContent,
            _clientConfig);

        // Act
        await clientScope.Client
            .Account(_accountId)
            .ApiToken(apiTokenId)
            .Delete()
            .ConfigureAwait(false);

        // Assert
        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Test]
    public async Task Reset_Success()
    {
        // Arrange
        var apiTokenId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = _resourceUri.Append(apiTokenId).Append(ResetSegment).AbsoluteUri;

        using var responseContent = await Feature.LoadFileToStringContent();
        var expectedResponse = await responseContent.DeserializeStringContentAsync<ApiTokenResetResponse>(_jsonSerializerOptions);
        expectedResponse.Should().NotBeNull();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(HttpMethod.Post, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .With(message => message.Content is null)
            .Respond(HttpStatusCode.OK, responseContent);

        using var services = BuildServiceProvider(mockHttp);
        var client = services.GetRequiredService<IMailtrapClient>();

        // Act
        var result = await client
            .Account(_accountId)
            .ApiToken(apiTokenId)
            .Reset()
            .ConfigureAwait(false);

        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().BeEquivalentTo(expectedResponse);
    }

    [Test]
    public async Task Reset_WithExpiration_Success()
    {
        // Arrange
        var request = new ResetApiTokenRequest
        {
            ExpiresAt = ApiTokenExpiration.At(DateTimeOffset.Parse("2027-06-01T00:00:00Z", CultureInfo.InvariantCulture))
        };

        const string expectedRequestBody = """{"expires_at":"2027-06-01T00:00:00+00:00"}""";

        // Act
        var result = await RunResetSuccessAsync(request, expectedRequestBody);

        // Assert
        result.ExpiresAt.Should().Be(DateTimeOffset.Parse("2027-06-01T00:00:00Z", CultureInfo.InvariantCulture));
    }

    [Test]
    public async Task Reset_WithNeverExpiration_Success()
    {
        // Arrange
        var request = new ResetApiTokenRequest
        {
            ExpiresAt = ApiTokenExpiration.Never
        };

        const string expectedRequestBody = """{"expires_at":null}""";

        // Act
        var result = await RunResetSuccessAsync(request, expectedRequestBody);

        // Assert
        result.ExpiresAt.Should().BeNull();
    }


    private async Task<CreateApiTokenResponse> RunCreateSuccessAsync(CreateApiTokenRequest request, string expectedRequestBody)
    {
        using var responseContent = await Feature.LoadFileToStringContent();
        var expectedResponse = await responseContent.DeserializeStringContentAsync<CreateApiTokenResponse>(_jsonSerializerOptions);
        expectedResponse.Should().NotBeNull();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(HttpMethod.Post, _resourceUri.AbsoluteUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithContent(expectedRequestBody)
            .Respond(HttpStatusCode.OK, responseContent);

        using var services = BuildServiceProvider(mockHttp);
        var client = services.GetRequiredService<IMailtrapClient>();

        var result = await client
            .Account(_accountId)
            .ApiTokens()
            .Create(request)
            .ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().BeEquivalentTo(expectedResponse);

        return result;
    }

    private async Task<ApiTokenResetResponse> RunResetSuccessAsync(ResetApiTokenRequest request, string expectedRequestBody)
    {
        var apiTokenId = TestContext.CurrentContext.Random.NextLong();
        var requestUri = _resourceUri.Append(apiTokenId).Append(ResetSegment).AbsoluteUri;

        using var responseContent = await Feature.LoadFileToStringContent();
        var expectedResponse = await responseContent.DeserializeStringContentAsync<ApiTokenResetResponse>(_jsonSerializerOptions);
        expectedResponse.Should().NotBeNull();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(HttpMethod.Post, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithContent(expectedRequestBody)
            .Respond(HttpStatusCode.OK, responseContent);

        using var services = BuildServiceProvider(mockHttp);
        var client = services.GetRequiredService<IMailtrapClient>();

        var result = await client
            .Account(_accountId)
            .ApiToken(apiTokenId)
            .Reset(request)
            .ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();

        result.Should().BeEquivalentTo(expectedResponse);

        return result;
    }

    private ServiceProvider BuildServiceProvider(MockHttpMessageHandler mockHttp)
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        return serviceCollection.BuildServiceProvider();
    }
}
