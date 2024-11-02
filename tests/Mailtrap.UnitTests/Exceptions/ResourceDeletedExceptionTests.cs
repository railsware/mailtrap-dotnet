// -----------------------------------------------------------------------
// <copyright file="ResourceDeletedExceptionTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.UnitTests.Exceptions;


[TestFixture]
internal sealed class ResourceDeletedExceptionTests
{
    private readonly HttpMethod _httpMethod = HttpMethod.Get;
    private readonly Uri _requestUri = new("https://api.test.com");


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenRequestUriIsNull()
    {
        var act = () => new ResourceDeletedException(null!, _httpMethod);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenMethodIsNull()
    {
        var act = () => new ResourceDeletedException(_requestUri, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldInitializePropertiesCorrectly()
    {
        var ex = new ResourceDeletedException(_requestUri, _httpMethod);

        ex.Message.Should().Be("Resource was deleted and can't be used anymore.");
        ex.RequestUri.Should().Be(_requestUri);
    }
}
