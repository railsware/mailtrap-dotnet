// -----------------------------------------------------------------------
// <copyright file="InvalidResponseFormatExceptionTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Exceptions;


[TestFixture]
internal sealed class InvalidResponseFormatExceptionTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenApiEndpointIsNull()
    {
        var act = () => new InvalidResponseFormatException(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldInitializePropertiesCorrectly()
    {
        var method = HttpMethod.Get;
        var uri = new Uri("https://api.test.com");
        using var request = new HttpRequestMessage(method, uri);

        var ex = new InvalidResponseFormatException(request);

        ex.Message.Should().Be("Response received from the API call has an invalid format.");
        ex.HttpMethod.Should().Be(method);
        ex.ApiEndpoint.Should().Be(uri);
    }
}
