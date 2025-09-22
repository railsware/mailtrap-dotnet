namespace Mailtrap.IntegrationTests.ContactEvents;


[TestFixture]
internal sealed class ContactsEventIntegrationTests
{
    private const string Feature = "ContactEvents";

    private readonly long _accountId;
    private readonly string _contactId;
    private readonly Uri _resourceUri = null!;
    private readonly MailtrapClientOptions _clientConfig = null!;
    private readonly JsonSerializerOptions _jsonSerializerOptions = null!;


    public ContactsEventIntegrationTests()
    {
        var random = TestContext.CurrentContext.Random;

        _accountId = random.NextLong();
        _contactId = random.NextGuid().ToString();
        _resourceUri = EndpointsTestConstants.ApiDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.AccountsSegment)
            .Append(_accountId)
            .Append(UrlSegmentsTestConstants.ContactsSegment)
            .Append(_contactId)
            .Append(UrlSegmentsTestConstants.EventsSegment);

        var token = random.GetString();
        _clientConfig = new MailtrapClientOptions(token);
        _jsonSerializerOptions = _clientConfig.ToJsonSerializerOptions();
    }

    [Test]
    public async Task Create_WithParams_Success()
    {
        // Arrange
        var httpMethod = HttpMethod.Post;
        var requestUri = _resourceUri.AbsoluteUri;

        var fileName = TestContext.CurrentContext.Test.MethodName;

        var requestContent = await Feature.LoadFileToString(fileName + "_Request");
        var request = JsonSerializer.Deserialize<CreateContactsEventRequest>(requestContent, _jsonSerializerOptions);
        request.Should().NotBeNull();

        using var responseContent = await Feature.LoadFileToStringContent(fileName + "_Response");
        var expectedResponse = await responseContent.DeserializeStringContentAsync<ContactsEvent>(_jsonSerializerOptions);
        expectedResponse.Should().NotBeNull();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(HttpStatusCode.Created, responseContent);

        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();
        var client = services.GetRequiredService<IMailtrapClient>();

        // Act
        var result = await client
            .Account(_accountId)
            .Contacts()
            .Events(_contactId)
            .Create(request)
            .ConfigureAwait(false);

        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        // result.Should().NotBeNull().And.BeEquivalentTo(expectedResponse);
        result.ShouldBeEquivalentToContactResponse(expectedResponse);
    }

    [Test]
    public async Task Create_Plain_Success()
    {
        // Arrange
        var httpMethod = HttpMethod.Post;
        var requestUri = _resourceUri.AbsoluteUri;

        var fileName = TestContext.CurrentContext.Test.MethodName;

        var requestContent = await Feature.LoadFileToString(fileName + "_Request");
        var request = JsonSerializer.Deserialize<CreateContactsEventRequest>(requestContent, _jsonSerializerOptions);
        request.Should().NotBeNull();

        using var responseContent = await Feature.LoadFileToStringContent(fileName + "_Response");
        var expectedResponse = await responseContent.DeserializeStringContentAsync<ContactsEvent>(_jsonSerializerOptions);
        expectedResponse.Should().NotBeNull();

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(HttpStatusCode.Created, responseContent);

        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();
        var client = services.GetRequiredService<IMailtrapClient>();

        // Act
        var result = await client
            .Account(_accountId)
            .Contacts()
            .Events(_contactId)
            .Create(request)
            .ConfigureAwait(false);

        // Assert
        mockHttp.VerifyNoOutstandingExpectation();

        result.ShouldBeEquivalentToContactResponse(expectedResponse);
    }

    [Test]
    public async Task Create_ShouldFailValidation_WhenNameIsNotValid([Values(256)] int length)
    {
        // Arrange
        var httpMethod = HttpMethod.Post;
        var requestUri = _resourceUri.AbsoluteUri;

        var contactsEventName = TestContext.CurrentContext.Random.GetString(length);
        var request = new CreateContactsEventRequest(contactsEventName);

        using var mockHttp = new MockHttpMessageHandler();
        var mockedRequest = mockHttp
            .When(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(HttpStatusCode.UnprocessableContent);

        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();
        var client = services.GetRequiredService<IMailtrapClient>();

        // Act
        var act = () => client
            .Account(_accountId)
            .Contacts()
            .Events(_contactId)
            .Create(request);

        // Assert
        await act.Should().ThrowAsync<RequestValidationException>();

        mockHttp.GetMatchCount(mockedRequest).Should().Be(0);
    }

    [Test]
    public async Task Create_ShouldFailValidation_WhenParamTagIsNotValid([Values(256)] int length)
    {
        // Arrange
        var httpMethod = HttpMethod.Post;
        var requestUri = _resourceUri.AbsoluteUri;

        var contactsEventName = "validName";
        var invalidParams = new Dictionary<string, object?> {
                { "validParamName", 10 },
                { TestContext.CurrentContext.Random.GetString(length), "validValue" }
            };
        var request = new CreateContactsEventRequest(contactsEventName, invalidParams);

        using var mockHttp = new MockHttpMessageHandler();
        var mockedRequest = mockHttp
            .When(httpMethod, requestUri)
            .WithHeaders("Authorization", $"Bearer {_clientConfig.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(HttpStatusCode.UnprocessableContent);

        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddMailtrapClient(_clientConfig)
            .ConfigurePrimaryHttpMessageHandler(() => mockHttp);

        using var services = serviceCollection.BuildServiceProvider();
        var client = services.GetRequiredService<IMailtrapClient>();

        // Act
        var act = () => client
            .Account(_accountId)
            .Contacts()
            .Events(_contactId)
            .Create(request);

        // Assert
        await act.Should().ThrowAsync<RequestValidationException>();

        mockHttp.GetMatchCount(mockedRequest).Should().Be(0);
    }
}
