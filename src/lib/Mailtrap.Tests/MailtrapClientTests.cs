// -----------------------------------------------------------------------
// <copyright file="MailtrapClientTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests;


[TestFixture]
internal sealed class MailtrapClientTests
{
    #region Constructor

    [Test]
    public void Constructor_DI_ShouldThrowArgumentNullException_WhenConfigurationIsNull()
    {
        var httpClientMock = Mock.Of<HttpClient>();
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();

        var act = () => new MailtrapClient(
            null!,
            httpClientMock,
            httpRequestMessageFactoryMock,
            httpRequestContentFactoryMock);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_DI_ShouldThrowArgumentNullException_WhenHttpClientIsNull()
    {
        var optionsMock = Mock.Of<IOptions<MailtrapClientOptions>>();
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();

        var act = () => new MailtrapClient(
            optionsMock,
            null!,
            httpRequestMessageFactoryMock,
            httpRequestContentFactoryMock);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_DI_ShouldThrowArgumentNullException_WhenHttpRequestMessageFactoryIsNull()
    {
        var optionsMock = Mock.Of<IOptions<MailtrapClientOptions>>();
        var httpClientMock = Mock.Of<HttpClient>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();

        var act = () => new MailtrapClient(
            optionsMock,
            httpClientMock,
            null!,
            httpRequestContentFactoryMock);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_DI_ShouldThrowArgumentNullException_WhenHttpRequestContentFactoryIsNull()
    {
        var optionsMock = Mock.Of<IOptions<MailtrapClientOptions>>();
        var httpClientMock = Mock.Of<HttpClient>();
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();

        var act = () => new MailtrapClient(
            optionsMock,
            httpClientMock,
            httpRequestMessageFactoryMock,
            null!);

        act.Should().Throw<ArgumentNullException>();
    }

    #endregion


    [Test]
    public async Task Send_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var client = CreateMailtrapClient();

        var act = () => client.SendEmail(null!);

        await act.Should().ThrowAsync<ArgumentNullException>().ConfigureAwait(false);
    }

    [Test]
    public async Task Send_ShouldThrowArgumentException_WhenRequestContainsInvalidData()
    {
        var client = CreateMailtrapClient();

        var request = SendEmailRequest.Create();

        var act = () => client.SendEmail(request);

        await act.Should().ThrowAsync<ArgumentException>().ConfigureAwait(false);
    }

    [Test]
    public async Task Send_ShouldCallPostWithRequestInformation()
    {
        // Arrange
        var sendEndpointOptions = new MailtrapClientEndpointOptions("https://localhost");
        var config = new MailtrapClientOptions("token")
        {
            SendEndpoint = sendEndpointOptions
        };

        var optionsMock = new Mock<IOptions<MailtrapClientOptions>>();
        optionsMock
            .Setup(p => p.Value)
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

        using var cts = new CancellationTokenSource();

        var request = SendEmailRequest
            .Create()
            .From("john.doe@demomailtrap.com", "John Doe")
            .To("hero.bill@galaxy.net")
            .Subject("Invitation to Earth")
            .Text("Dear Bill,\nIt will be a great pleasure to see you on our blue planet next weekend.\nBest regards, John.");
        var jsonSerializerOptions = config.Serialization.AsJsonSerializerOptions();
        var requestJson = JsonSerializer.Serialize(request, jsonSerializerOptions);
        using var requestContent = new StringContent(requestJson);

        var httpRequestContentFactoryMock = new Mock<IHttpRequestContentFactory>();
        httpRequestContentFactoryMock
            .Setup(f => f.CreateStringContent(requestJson))
            .Returns(requestContent);

        using var requestMessage = new HttpRequestMessage(httpMethod, sendUrl)
        {
            Content = requestContent
        };

        var httpRequestMessageFactoryMock = new Mock<IHttpRequestMessageFactory>();
        httpRequestMessageFactoryMock
            .Setup(f => f.Create(httpMethod, sendUrl, requestContent))
            .Returns(requestMessage);

        var client = new MailtrapClient(
            optionsMock.Object,
            mockHttp.ToHttpClient(),
            httpRequestMessageFactoryMock.Object,
            httpRequestContentFactoryMock.Object);


        // Act
        var result = await client.SendEmail(request, cancellationToken: cts.Token).ConfigureAwait(false);


        // Assert
        httpRequestContentFactoryMock.Verify(f => f.CreateStringContent(requestJson), Times.Once);

        httpRequestMessageFactoryMock.Verify(f => f.Create(httpMethod, sendUrl, requestContent), Times.Once);

        optionsMock.VerifyGet(p => p.Value, Times.Once);

        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .BeEquivalentTo(response);

        result!.Success.Should().BeTrue();
        result!.MessageIds.Should().ContainSingle(m => m == messageId);
    }

    [Test]
    public async Task Send_ShouldUseTestEndpoint_WhenInboxIdProvided()
    {
        // Arrange
        var sendEndpointOptions = new MailtrapClientEndpointOptions("https://send.api.mailtrap.io");
        var testEndpointOptions = new MailtrapClientEndpointOptions("https://test.api.mailtrap.io");

        var config = new MailtrapClientOptions("token")
        {
            SendEndpoint = sendEndpointOptions,
            TestEndpoint = testEndpointOptions
        };

        var optionsMock = new Mock<IOptions<MailtrapClientOptions>>();
        optionsMock
            .Setup(p => p.Value)
            .Returns(config);

        var inboxId = 1244;
        var httpMethod = HttpMethod.Post;
        var sendUrl = config.TestEndpoint.BaseUrl.Append(
            UrlSegments.ApiRootSegment,
            UrlSegments.SendEmailSegment,
            inboxId.ToString(CultureInfo.InvariantCulture));
        var messageId = new MessageId("1");
        var response = new SendEmailResponse(true, [messageId]);
        using var responseContent = JsonContent.Create(response);

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, sendUrl.AbsoluteUri)
            .Respond(HttpStatusCode.OK, responseContent);

        using var cts = new CancellationTokenSource();

        var request = SendEmailRequest
            .Create()
            .From("john.doe@demomailtrap.com", "John Doe")
            .To("hero.bill@galaxy.net")
            .Subject("Invitation to Earth")
            .Text("Dear Bill,\nIt will be a great pleasure to see you on our blue planet next weekend.\nBest regards, John.");
        var jsonSerializerOptions = config.Serialization.AsJsonSerializerOptions();
        var requestJson = JsonSerializer.Serialize(request, jsonSerializerOptions);
        using var requestContent = new StringContent(requestJson);

        var httpRequestContentFactoryMock = new Mock<IHttpRequestContentFactory>();
        httpRequestContentFactoryMock
            .Setup(f => f.CreateStringContent(requestJson))
            .Returns(requestContent);

        using var requestMessage = new HttpRequestMessage(httpMethod, sendUrl)
        {
            Content = requestContent
        };

        var httpRequestMessageFactoryMock = new Mock<IHttpRequestMessageFactory>();
        httpRequestMessageFactoryMock
            .Setup(f => f.Create(httpMethod, sendUrl, requestContent))
            .Returns(requestMessage);

        var client = new MailtrapClient(
            optionsMock.Object,
            mockHttp.ToHttpClient(),
            httpRequestMessageFactoryMock.Object,
            httpRequestContentFactoryMock.Object);


        // Act
        var result = await client.SendEmail(request, inboxId: inboxId, cancellationToken: cts.Token).ConfigureAwait(false);


        // Assert
        httpRequestContentFactoryMock.Verify(f => f.CreateStringContent(requestJson), Times.Once);

        httpRequestMessageFactoryMock.Verify(f => f.Create(httpMethod, sendUrl, requestContent), Times.Once);

        optionsMock.VerifyGet(p => p.Value, Times.Once);

        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .BeEquivalentTo(response);

        result!.Success.Should().BeTrue();
        result!.MessageIds.Should().ContainSingle(m => m == messageId);
    }


    private static MailtrapClient CreateMailtrapClient()
    {
        var options = Options.Create(new MailtrapClientOptions("token"));
        var httpClientMock = Mock.Of<HttpClient>();
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();

        return new MailtrapClient(options, httpClientMock, httpRequestMessageFactoryMock, httpRequestContentFactoryMock);
    }
}
