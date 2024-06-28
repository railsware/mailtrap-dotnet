// -----------------------------------------------------------------------
// <copyright file="HttpClientExtensionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Extensions;


[TestFixture]
internal sealed class HttpClientExtensionsTests
{
    private Uri _uri { get; } = new Uri("http://example.com");
    private Uri _otherUri { get; } = new Uri("https://domain.com");


    [Test]
    public void WithBaseAddress_ShouldThrowArgumentNullException_WhenHttpClientIsNull()
    {
        var act = () => HttpClientExtensions.WithBaseAddress(null!, _uri);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithBaseAddress_ShouldSetBaseAddress_WhenItIsNull()
    {
        var client = Mock.Of<HttpClient>();

        client.WithBaseAddress(_uri);

        client.BaseAddress.Should().Be(_uri);
    }

    [Test]
    public void WithBaseAddress_ShouldOverrideBaseAddress_WhenItWasSetPreviously()
    {
        var client = Mock.Of<HttpClient>();

        client.BaseAddress = _otherUri;

        client.WithBaseAddress(_uri);

        client.BaseAddress.Should().Be(_uri);
    }

    [Test]
    public void WithBaseAddress_ShouldResetBaseAddress_WhenItWasSetPreviously()
    {
        var client = Mock.Of<HttpClient>();

        client.BaseAddress = _otherUri;

        client.WithBaseAddress(null);

        client.BaseAddress.Should().BeNull();
    }
}
