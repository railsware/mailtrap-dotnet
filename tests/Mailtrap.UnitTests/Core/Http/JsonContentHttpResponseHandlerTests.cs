// -----------------------------------------------------------------------
// <copyright file="JsonContentHttpResponseHandlerTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Core.Http;


[TestFixture]
internal sealed class JsonContentHttpResponseHandlerTests
{
    [Test]
    public async Task ProcessResponse_ShouldThrowJsonException_WhenResponseHasNoContent()
    {
        // Arrange
        var statusCode = HttpStatusCode.OK;
        var httpMethod = HttpMethod.Get;

        using var httpMessage = new HttpResponseMessage(statusCode)
        {
            RequestMessage = new HttpRequestMessage(httpMethod, "http://test.com")
        };

        var handler = new JsonContentHttpResponseHandler<string>(
            MailtrapClientOptions.Default.ToJsonSerializerOptions(), httpMessage);

        var act = () => handler.ProcessResponse();


        // Assert
        await act.Should().ThrowAsync<JsonException>();
    }

    [Test]
    public async Task ProcessResponse_ShouldThrowJsonException_WhenResponseContentIsEmpty()
    {
        // Arrange
        var statusCode = HttpStatusCode.OK;
        var httpMethod = HttpMethod.Get;

        using var httpMessage = new HttpResponseMessage(statusCode)
        {
            RequestMessage = new HttpRequestMessage(httpMethod, "http://test.com"),
            Content = new StringContent(string.Empty)
        };

        var handler = new JsonContentHttpResponseHandler<string>(
            MailtrapClientOptions.Default.ToJsonSerializerOptions(), httpMessage);

        var act = () => handler.ProcessResponse();


        // Assert
        await act.Should().ThrowAsync<JsonException>();
    }

    [Test]
    public async Task ProcessResponse_ShouldThrowEmptyResponseException_WhenResponseContentIsNull()
    {
        // Arrange
        var statusCode = HttpStatusCode.OK;
        var httpMethod = HttpMethod.Get;

        using var httpMessage = new HttpResponseMessage(statusCode)
        {
            RequestMessage = new HttpRequestMessage(httpMethod, "http://test.com"),
            Content = new StringContent("null")
        };

        var handler = new JsonContentHttpResponseHandler<string>(
            MailtrapClientOptions.Default.ToJsonSerializerOptions(), httpMessage);

        var act = () => handler.ProcessResponse();


        // Assert
        await act.Should()
            .ThrowAsync<EmptyResponseException>()
            .Where(ex => ex.HttpMethod == httpMethod);
    }
}
