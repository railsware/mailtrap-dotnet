// -----------------------------------------------------------------------
// <copyright file="EmailClientTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email;


[TestFixture]
internal sealed class EmailClientTests
{
    #region Constructor

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenHttpClientFactoryIsNull()
    {
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();
        var sendUri = new Uri("https://localhost/api/send");

        var act = () => new EmailClient(
            null!,
            httpRequestMessageFactoryMock,
            httpRequestContentFactoryMock,
            JsonSerializerOptions.Default,
            sendUri);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenHttpRequestMessageFactoryIsNull()
    {
        var httpClientFactoryMock = Mock.Of<IHttpClientFactory>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();
        var sendUri = new Uri("https://localhost/api/send");

        var act = () => new EmailClient(
            httpClientFactoryMock,
            null!,
            httpRequestContentFactoryMock,
            JsonSerializerOptions.Default,
            sendUri);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenHttpRequestContentFactoryIsNull()
    {
        var httpClientFactoryMock = Mock.Of<IHttpClientFactory>();
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();
        var sendUri = new Uri("https://localhost/api/send");

        var act = () => new EmailClient(
            httpClientFactoryMock,
            httpRequestMessageFactoryMock,
            null!,
            JsonSerializerOptions.Default,
            sendUri);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenJsonSerializerOptionsIsNull()
    {
        var httpClientFactoryMock = Mock.Of<IHttpClientFactory>();
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();
        var sendUri = new Uri("https://localhost/api/send");

        var act = () => new EmailClient(
            httpClientFactoryMock,
            httpRequestMessageFactoryMock,
            httpRequestContentFactoryMock,
            null!,
            sendUri);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenSendUriIsNull()
    {
        var httpClientFactoryMock = Mock.Of<IHttpClientFactory>();
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();

        var act = () => new EmailClient(
            httpClientFactoryMock,
            httpRequestMessageFactoryMock,
            httpRequestContentFactoryMock,
            JsonSerializerOptions.Default,
            null!);

        act.Should().Throw<ArgumentNullException>();
    }

    #endregion


    [Test]
    public async Task Send_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var client = CreateEmailClient();

        var act = () => client.Send(null!);

        await act.Should()
            .ThrowAsync<ArgumentNullException>()
            .ConfigureAwait(false);
    }

    [Test]
    public async Task Send_ShouldThrowArgumentException_WhenRequestContainsInvalidData()
    {
        var client = CreateEmailClient();

        var request = SendEmailRequest.Create();

        var act = () => client.Send(request);

        await act.Should()
            .ThrowAsync<ArgumentException>()
            .ConfigureAwait(false);
    }

    [Test]
    public async Task Send_ShouldCallPostWithRequestInformation()
    {
        // Arrange
        var token = "token";
        var sendUri = new Uri("https://localhost/api/send");
        var httpMethod = HttpMethod.Post;

        var config = new MailtrapClientOptions(token);

        var request = CreateValidRequest();
        var jsonSerializerOptions = config.ToJsonSerializerOptions();

        var messageId = new MessageId("1");
        var response = new SendEmailResponse(true, [messageId]);
        using var responseContent = JsonContent.Create(response);

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, sendUri.AbsoluteUri)
            .WithJsonContent(request, jsonSerializerOptions)
            .Respond(HttpStatusCode.OK, responseContent);

        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        httpClientFactoryMock
            .Setup(f => f.CreateClient(Client.Name))
            .Returns(mockHttp.ToHttpClient());

        using var cts = new CancellationTokenSource();

        var requestJson = JsonSerializer.Serialize(request, jsonSerializerOptions);
        using var requestContent = new StringContent(requestJson);

        var httpRequestContentFactoryMock = new Mock<IHttpRequestContentFactory>();
        httpRequestContentFactoryMock
            .Setup(f => f.CreateStringContent(requestJson))
            .Returns(requestContent);

        using var requestMessage = new HttpRequestMessage(httpMethod, sendUri.AbsoluteUri)
        {
            Content = requestContent
        };

        var httpRequestMessageFactoryMock = new Mock<IHttpRequestMessageFactory>();
        httpRequestMessageFactoryMock
            .Setup(f => f.Create(httpMethod, sendUri, requestContent))
            .Returns(requestMessage);

        var client = new EmailClient(
            httpClientFactoryMock.Object,
            httpRequestMessageFactoryMock.Object,
            httpRequestContentFactoryMock.Object,
            jsonSerializerOptions,
            sendUri);

        // Act
        var result = await client.Send(request, cts.Token).ConfigureAwait(false);


        // Assert
        httpClientFactoryMock.Verify(f => f.CreateClient(Client.Name), Times.Once);

        httpRequestContentFactoryMock.Verify(f => f.CreateStringContent(requestJson), Times.Once);

        httpRequestMessageFactoryMock.Verify(f => f.Create(httpMethod, sendUri, requestContent), Times.Once);

        mockHttp.VerifyNoOutstandingExpectation();

        result.Should()
            .NotBeNull().And
            .BeEquivalentTo(response);

        result!.Success.Should().BeTrue();
        result!.MessageIds.Should().ContainSingle(m => m == messageId);
    }

    [Test]
    public async Task Send_ShouldReturnEmptyResponse_WhenNullResponseReturnedFromHttpCall()
    {
        // Arrange
        var token = "token";
        var sendUri = new Uri("https://localhost/api/send");
        var httpMethod = HttpMethod.Post;

        var config = new MailtrapClientOptions(token);

        var request = CreateValidRequest();
        var jsonSerializerOptions = config.ToJsonSerializerOptions();

        using var responseContent = JsonContent.Create<SendEmailResponse?>(null);
        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, sendUri.AbsoluteUri)
            .WithJsonContent(request, jsonSerializerOptions)
            .Respond(HttpStatusCode.OK, responseContent);

        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        httpClientFactoryMock
            .Setup(f => f.CreateClient(Client.Name))
            .Returns(mockHttp.ToHttpClient());

        using var cts = new CancellationTokenSource();

        var requestJson = JsonSerializer.Serialize(request, jsonSerializerOptions);
        using var requestContent = new StringContent(requestJson);

        var httpRequestContentFactoryMock = new Mock<IHttpRequestContentFactory>();
        httpRequestContentFactoryMock
            .Setup(f => f.CreateStringContent(requestJson))
            .Returns(requestContent);

        using var requestMessage = new HttpRequestMessage(httpMethod, sendUri.AbsoluteUri)
        {
            Content = requestContent
        };

        var httpRequestMessageFactoryMock = new Mock<IHttpRequestMessageFactory>();
        httpRequestMessageFactoryMock
            .Setup(f => f.Create(httpMethod, sendUri, requestContent))
            .Returns(requestMessage);

        var client = new EmailClient(
            httpClientFactoryMock.Object,
            httpRequestMessageFactoryMock.Object,
            httpRequestContentFactoryMock.Object,
            jsonSerializerOptions,
            sendUri);


        // Act
        var result = await client.Send(request, cts.Token).ConfigureAwait(false);


        // Assert
        result.Should()
            .NotBeNull().And
            .BeSameAs(SendEmailResponse.Empty);
    }


    private static EmailClient CreateEmailClient()
    {
        return new EmailClient(
            Mock.Of<IHttpClientFactory>(),
            Mock.Of<IHttpRequestMessageFactory>(),
            Mock.Of<IHttpRequestContentFactory>(),
            JsonSerializerOptions.Default,
            new Uri("https://localhost"));
    }

    private static SendEmailRequest CreateValidRequest()
    {
        return SendEmailRequest
            .Create()
            .From("john.doe@demomailtrap.com", "John Doe")
            .To("hero.bill@galaxy.net")
            .Subject("Invitation to Earth")
            .Text("Dear Bill,\nIt will be a great pleasure to see you on our blue planet next weekend.\nBest regards, John.");
    }
}
