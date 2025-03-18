namespace Mailtrap.UnitTests.Core.Http;


[TestFixture]
internal sealed class PlainTextHttpResponseHandlerTests
{
    [Test]
    public async Task ProcessResponse_ShouldReturnNullOrEmpty_WhenResponseHasNoContent()
    {
        // Arrange
        var statusCode = HttpStatusCode.OK;
        var httpMethod = HttpMethod.Get;

        using var httpMessage = new HttpResponseMessage(statusCode)
        {
            RequestMessage = new HttpRequestMessage(httpMethod, "http://test.com")
        };

        var handler = new PlainTextContentHttpResponseHandler(
            MailtrapClientOptions.Default.ToJsonSerializerOptions(), httpMessage);


        // Act
        var result = await handler.ProcessResponse();


        // Assert
        result.Should().BeNullOrEmpty();
    }

    [Test]
    public async Task ProcessResponse_ShouldReturnNullOrEmpty_WhenResponseContentIsEmpty()
    {
        // Arrange
        var statusCode = HttpStatusCode.OK;
        var httpMethod = HttpMethod.Get;

        using var httpMessage = new HttpResponseMessage(statusCode)
        {
            RequestMessage = new HttpRequestMessage(httpMethod, "http://test.com"),
            Content = new StringContent(string.Empty)
        };

        var handler = new PlainTextContentHttpResponseHandler(
            MailtrapClientOptions.Default.ToJsonSerializerOptions(), httpMessage);


        // Act
        var result = await handler.ProcessResponse();


        // Assert
        result.Should().BeNullOrEmpty();
    }

    [Test]
    public async Task ProcessResponse_ShouldReturnContent()
    {
        // Arrange
        var statusCode = HttpStatusCode.OK;
        var httpMethod = HttpMethod.Get;
        var content = TestContext.CurrentContext.Random.GetString();

        using var httpMessage = new HttpResponseMessage(statusCode)
        {
            RequestMessage = new HttpRequestMessage(httpMethod, "http://test.com"),
            Content = new StringContent(content)
        };

        var handler = new PlainTextContentHttpResponseHandler(
            MailtrapClientOptions.Default.ToJsonSerializerOptions(), httpMessage);


        // Act
        var result = await handler.ProcessResponse();


        // Assert
        result.Should().Be(content);
    }
}
