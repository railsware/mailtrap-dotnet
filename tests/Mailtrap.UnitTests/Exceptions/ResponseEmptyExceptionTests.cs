// -----------------------------------------------------------------------
// <copyright file="ResponseEmptyExceptionTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.UnitTests.Exceptions;


[TestFixture]
internal sealed class ResponseEmptyExceptionTests
{
    private readonly HttpMethod _httpMethod = HttpMethod.Get;
    private readonly Uri _requestUri = new("https://api.test.com");


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenRequestUriIsNull()
    {
        var act = () => new EmptyResponseException(null!, _httpMethod);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenMethodIsNull()
    {
        var act = () => new EmptyResponseException(_requestUri, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldInitializePropertiesCorrectly()
    {
        var ex = new EmptyResponseException(_requestUri, _httpMethod);

        ex.Message.Should().Be("Response received from the API call has no content.");
        ex.HttpMethod.Should().Be(_httpMethod);
        ex.RequestUri.Should().Be(_requestUri);
    }
}
