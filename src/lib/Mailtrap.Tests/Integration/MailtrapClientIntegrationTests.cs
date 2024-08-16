// -----------------------------------------------------------------------
// <copyright file="MailtrapClientTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Integration;


[Ignore("Enable integration tests when factory or DI will be available to simplify setup.")]
[TestFixture]
internal sealed class MailtrapClientIntegrationTests
{
    [Test]
    public async Task Send_Integration()
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

        var request = CreateValidRequest();
        var jsonSerializerOptions = config.Serialization.AsJsonSerializerOptions();

        var messageId = new MessageId(TestContext.CurrentContext.Random.NextGuid().ToString());
        var response = new SendEmailResponse(true, [messageId]);
        using var responseContent = JsonContent.Create(response);

        using var mockHttp = new MockHttpMessageHandler();
        mockHttp
            .Expect(httpMethod, sendUrl.AbsoluteUri)
            .WithJsonContent(request, jsonSerializerOptions)
            .WithHeaders("Authorization", $"Bearer {config.Authentication.ApiToken}")
            .WithHeaders("Accept", MimeTypes.Application.Json)
            .WithHeaders("User-Agent", HeaderValues.UserAgent.ToString())
            .With(r =>
                r.Content?.Headers.Contains("Content-Type") == true &&
                r.Content?.Headers.ContentType?.MediaType == MimeTypes.Application.Json)
            .Respond(HttpStatusCode.OK, responseContent);

        using var cts = new CancellationTokenSource();

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
