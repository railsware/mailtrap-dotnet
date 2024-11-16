// -----------------------------------------------------------------------
// <copyright file="HttpResponseHandlerTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Http;


[TestFixture]
internal sealed class HttpResponseHandlerTests
{
    [TestCase(HttpStatusCode.InternalServerError)]
    [TestCase(HttpStatusCode.BadGateway)]
    public async Task ProcessResponse_ShouldThrowException_WhenHttpCodeIs5xx(HttpStatusCode statusCode)
    {
        // Arrange
        using var httpMessage = new HttpResponseMessage(statusCode)
        {
            RequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://test.com")
        };

        var handler = new StatusCodeHttpResponseHandler(
            MailtrapClientOptions.Default.ToJsonSerializerOptions(), httpMessage);

        var act = () => handler.ProcessResponse();


        // Assert
        await act.Should()
            .ThrowAsync<HttpRequestFailedException>()
            .Where(ex => ex.StatusCode == statusCode);
    }

    [Test]
    public async Task ProcessResponse_ShouldThrowExceptionWithDetails_WhenHttpCodeIs4xx()
    {
        // Arrange
        var statusCode = HttpStatusCode.NotFound;

        using var httpMessage = new HttpResponseMessage(statusCode)
        {
            RequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://test.com")
        };

        var handler = new StatusCodeHttpResponseHandler(
            MailtrapClientOptions.Default.ToJsonSerializerOptions(), httpMessage);

        var act = () => handler.ProcessResponse();


        // Assert
        await act.Should()
            .ThrowAsync<HttpRequestFailedException>()
            .Where(ex => ex.StatusCode == statusCode);
    }
}
