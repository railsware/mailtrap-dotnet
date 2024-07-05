// -----------------------------------------------------------------------
// <copyright file="MailtrapClientTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------



namespace Mailtrap.Tests;


[TestFixture]
internal sealed class MailtrapClientTests
{
    #region DI Constructor

    [Test]
    public void Constructor_DI_ShouldThrowArgumentNullException_WhenConfigurationProviderIsNull()
    {
        var configProviderMock = Mock.Of<IMailtrapClientConfigurationProvider>();
        var httpClientLifetimeAdapterFactoryMock = Mock.Of<IHttpClientLifetimeAdapterFactory>();
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();

        var act = () => new MailtrapClient(
            null!,
            httpClientLifetimeAdapterFactoryMock,
            httpRequestMessageFactoryMock,
            httpRequestContentFactoryMock);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_DI_ShouldThrowArgumentNullException_WhenHttpClientLifetimeAdapterFactoryIsNull()
    {
        var configProviderMock = Mock.Of<IMailtrapClientConfigurationProvider>();
        var httpClientLifetimeAdapterFactoryMock = Mock.Of<IHttpClientLifetimeAdapterFactory>();
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();

        var act = () => new MailtrapClient(
            configProviderMock,
            null!,
            httpRequestMessageFactoryMock,
            httpRequestContentFactoryMock);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_DI_ShouldThrowArgumentNullException_WhenHttpRequestMessageFactoryIsNull()
    {
        var configProviderMock = Mock.Of<IMailtrapClientConfigurationProvider>();
        var httpClientLifetimeAdapterFactoryMock = Mock.Of<IHttpClientLifetimeAdapterFactory>();
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();

        var act = () => new MailtrapClient(
            configProviderMock,
            httpClientLifetimeAdapterFactoryMock,
            null!,
            httpRequestContentFactoryMock);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_DI_ShouldThrowArgumentNullException_WhenHttpRequestContentFactoryIsNull()
    {
        var configProviderMock = Mock.Of<IMailtrapClientConfigurationProvider>();
        var httpClientLifetimeAdapterFactoryMock = Mock.Of<IHttpClientLifetimeAdapterFactory>();
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();

        var act = () => new MailtrapClient(
            configProviderMock,
            httpClientLifetimeAdapterFactoryMock,
            httpRequestMessageFactoryMock,
            null!);

        act.Should().Throw<ArgumentNullException>();
    }

    #endregion


    [Test]
    public void Constructor_OptionsAndDelegate_ShouldThrowArgumentNullException_WhenConfigurationIsNull()
    {
        MailtrapClientOptions? options = null;

        var act = () => new MailtrapClient(options!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_OptionsAndDelegate_ShouldCallDelegate()
    {
        var options = new MailtrapClientOptions("token");
        var configure = new Mock<Action<IHttpClientBuilder>>();

        using var client = new MailtrapClient(options, configure.Object);

        configure.Verify(c => c.Invoke(It.IsAny<IHttpClientBuilder>()));
    }

    [Test]
    public void Constructor_OptionsAndClient_ShouldThrowArgumentNullException_WhenConfigurationIsNull()
    {
        MailtrapClientOptions? options = null;
        var httpClient = Mock.Of<HttpClient>();

        var act = () => new MailtrapClient(options!, httpClient);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_OptionsAndClient_ShouldThrowArgumentNullException_WhenHttpClientIsNull()
    {
        HttpClient? httpClient = null;

        var act = () => new MailtrapClient(MailtrapClientOptions.Default, httpClient!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public async Task Constructor_OptionsAndClient_ShouldUseClientProvided()
    {
        var config = new MailtrapClientOptions("token");

        var httpMethod = HttpMethod.Post;
        var sendUrl = config.SendEndpoint.BaseUrl.Append(UrlSegments.ApiRootSegment, UrlSegments.SendEmailSegment);
        var messageId = new MessageId("1");
        var response = new SendEmailResponse(true, [messageId]);
        using var responseContent = JsonContent.Create(response);

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, sendUrl.AbsoluteUri)
            .Respond(HttpStatusCode.OK, responseContent);

        using var client = new MailtrapClient(config, mockHttp.ToHttpClient());

        var request = SendEmailRequestBuilder
            .Email()
            .From("john.doe@demomailtrap.com", "John Doe")
            .To("hero.bill@galaxy.net")
            .Subject("Invitation to Earth")
            .Text("Dear Bill,\nIt will be a great pleasure to see you on our blue planet next weekend.\nBest regards, John.");

        var _ = await client.SendAsync(request).ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Test]
    public void Constructor_KeyAndDelegate_ShouldThrowArgumentNullException_WhenApiKeyIsNull()
    {
        string? apiKey = null;

        var act = () => new MailtrapClient(apiKey!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_KeyAndDelegate_ShouldCallDelegate()
    {
        var configure = new Mock<Action<IHttpClientBuilder>>();

        using var client = new MailtrapClient("token", configure.Object);

        configure.Verify(c => c.Invoke(It.IsAny<IHttpClientBuilder>()));
    }

    [Test]
    public void Constructor_KeyAndClient_ShouldThrowArgumentNullException_WhenApiKeyIsNull()
    {
        string? apiKey = null;
        var httpClient = Mock.Of<HttpClient>();

        var act = () => new MailtrapClient(apiKey!, httpClient);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_KeyAndClient_ShouldThrowArgumentNullException_WhenHttpClientIsNull()
    {
        HttpClient? httpClient = null;

        var act = () => new MailtrapClient("token", httpClient!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public async Task Constructor_KeyAndClient_ShouldUseClientProvided()
    {
        var httpMethod = HttpMethod.Post;
        var sendUrl = MailtrapClientOptions.Default.SendEndpoint.BaseUrl
            .Append(UrlSegments.ApiRootSegment, UrlSegments.SendEmailSegment);
        var messageId = new MessageId("1");
        var response = new SendEmailResponse(true, [messageId]);
        using var responseContent = JsonContent.Create(response);

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, sendUrl.AbsoluteUri)
            .Respond(HttpStatusCode.OK, responseContent);

        using var client = new MailtrapClient("token", mockHttp.ToHttpClient());

        var request = SendEmailRequestBuilder
            .Email()
            .From("john.doe@demomailtrap.com", "John Doe")
            .To("hero.bill@galaxy.net")
            .Subject("Invitation to Earth")
            .Text("Dear Bill,\nIt will be a great pleasure to see you on our blue planet next weekend.\nBest regards, John.");

        var _ = await client.SendAsync(request).ConfigureAwait(false);

        mockHttp.VerifyNoOutstandingExpectation();
    }

    [Test]
    public async Task Dispose_ShouldDisposeInternals_WhenShortcutConstructorIsUsed()
    {
        var client = new MailtrapClient("token");

        client.Dispose();

        var request = SendEmailRequestBuilder
            .Email()
            .From("john.doe@demomailtrap.com", "John Doe")
            .To("hero.bill@galaxy.net")
            .Subject("Invitation to Earth")
            .Text("Dear Bill,\nIt will be a great pleasure to see you on our blue planet next weekend.\nBest regards, John.");

        var act = () => client.SendAsync(request);

        await act.Should().ThrowAsync<ObjectDisposedException>().ConfigureAwait(false);
    }


    [Test]
    public async Task Send_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        using var client = new MailtrapClient("token");

        var act = () => client.SendAsync(null!);

        await act.Should().ThrowAsync<ArgumentNullException>().ConfigureAwait(false);
    }

    [Test]
    public async Task Send_ShouldThrowArgumentException_WhenRequestContainsInvalidData()
    {
        using var client = new MailtrapClient("token");

        var request = SendEmailRequestBuilder.Email();

        var act = () => client.SendAsync(request);

        await act.Should().ThrowAsync<ArgumentException>().ConfigureAwait(false);
    }

    [Test]
    public async Task Send_ShouldCallPostWithRequestInformation()
    {
        var sendEndpointOptions = new MailtrapClientEndpointOptions("https://localhost");
        var config = new MailtrapClientOptions("token")
        {
            SendEndpoint = sendEndpointOptions
        };

        var configProviderMock = new Mock<IMailtrapClientConfigurationProvider>();
        configProviderMock
            .Setup(p => p.Configuration)
            .Returns(config);

        var httpMethod = HttpMethod.Post;
        var sendUrl = config.SendEndpoint.BaseUrl.Append(UrlSegments.ApiRootSegment, UrlSegments.SendEmailSegment);
        var messageId = new MessageId("1");
        var response = new SendEmailResponse(true, [messageId]);
        using var responseContent = JsonContent.Create(response);

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, sendUrl.AbsoluteUri)
            .Respond(HttpStatusCode.OK, responseContent);

        var httpClientLifetimeAdapterMock = new Mock<IHttpClientLifetimeAdapter>();
        httpClientLifetimeAdapterMock
            .Setup(a => a.HttpClient)
            .Returns(mockHttp.ToHttpClient());

        using var cts = new CancellationTokenSource();

        var httpClientLifetimeAdapterFactoryMock = new Mock<IHttpClientLifetimeAdapterFactory>();
        httpClientLifetimeAdapterFactoryMock
            .Setup(f => f.GetClientAsync(sendEndpointOptions, cts.Token))
            .ReturnsAsync(httpClientLifetimeAdapterMock.Object);

        var request = SendEmailRequestBuilder
            .Email()
            .From("john.doe@demomailtrap.com", "John Doe")
            .To("hero.bill@galaxy.net")
            .Subject("Invitation to Earth")
            .Text("Dear Bill,\nIt will be a great pleasure to see you on our blue planet next weekend.\nBest regards, John.");
        var jsonSerializerOptions = config.Serialization.ToJsonSerializerOptions();
        var requestJson = JsonSerializer.Serialize(request, jsonSerializerOptions);
        using var requestContent = new StringContent(requestJson);

        var httpRequestContentFactoryMock = new Mock<IHttpRequestContentFactory>();
        httpRequestContentFactoryMock
            .Setup(f => f.CreateAsync(requestJson, cts.Token))
            .ReturnsAsync(requestContent);

        using var requestMessage = new HttpRequestMessage(httpMethod, sendUrl)
        {
            Content = requestContent
        };

        var httpRequestMessageFactoryMock = new Mock<IHttpRequestMessageFactory>();
        httpRequestMessageFactoryMock
            .Setup(f => f.CreateAsync(httpMethod, sendUrl, requestContent, cts.Token))
            .ReturnsAsync(requestMessage);

        using var client = new MailtrapClient(
            configProviderMock.Object,
            httpClientLifetimeAdapterFactoryMock.Object,
            httpRequestMessageFactoryMock.Object,
            httpRequestContentFactoryMock.Object);


        var result = await client.SendAsync(request, cts.Token).ConfigureAwait(false);


        httpRequestContentFactoryMock.Verify(f => f.CreateAsync(requestJson, cts.Token), Times.Once);

        httpRequestMessageFactoryMock.Verify(f => f.CreateAsync(httpMethod, sendUrl, requestContent, cts.Token), Times.Once);

        httpClientLifetimeAdapterFactoryMock.Verify(f => f.GetClientAsync(sendEndpointOptions, cts.Token), Times.Once);

        configProviderMock.VerifyGet(p => p.Configuration, Times.Once);

        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .BeEquivalentTo(response);

        result!.IsSuccess.Should().BeTrue();
        result!.MessageIds.Should().ContainSingle(m => m == messageId);
    }
}
