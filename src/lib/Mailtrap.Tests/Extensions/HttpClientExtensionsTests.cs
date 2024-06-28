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


    [Test]
    public void WithBaseAddress_ShouldThrowArgumentNullException_WhenHttpClientIsNull()
    {
        var act = () => HttpClientExtensions.WithBaseAddress(null!, _uri);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void WithBaseAddress_ShouldSetBaseAddress_WhenItIsNull()
    {
        using var client = new HttpClient();

        client.WithBaseAddress(_uri);

        client.BaseAddress.Should().Be(_uri);
    }

    [Test]
    public void WithBaseAddress_ShouldNotOverrideBaseAddress_WhenItWasSet()
    {
        var httpUri = new Uri("https://domain.com");

        using var client = new HttpClient()
        {
            BaseAddress = httpUri
        };

        client.WithBaseAddress(_uri);

        client.BaseAddress.Should().Be(httpUri);
    }

    [Test]
    public void WithBaseAddress_ShouldOverrideBaseAddress_WhenItWasSetAndForceFlag()
    {
        var httpUri = new Uri("https://domain.com");

        using var client = new HttpClient()
        {
            BaseAddress = httpUri
        };

        client.WithBaseAddress(_uri, true);

        client.BaseAddress.Should().Be(_uri);
    }

    [Test]
    public void WithBaseAddress_ShouldResetBaseAddress_WhenItWasSetAndForceFlag()
    {
        var httpUri = new Uri("https://domain.com");

        using var client = new HttpClient()
        {
            BaseAddress = httpUri
        };

        client.WithBaseAddress(null, true);

        client.BaseAddress.Should().BeNull();
    }
}
