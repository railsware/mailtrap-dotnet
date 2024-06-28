// -----------------------------------------------------------------------
// <copyright file="HttpRequestMessageFactoryTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Http.Request;


[TestFixture]
internal sealed class HttpRequestMessageFactoryTests
{
    private HttpMethod _method { get; } = HttpMethod.Post;
    private Uri _uri { get; } = new("https://domain.com");
    private StringContent _content { get; } = new("content");


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenPolicyIsNull()
    {
        var act = () => new HttpRequestMessageFactory(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public async Task CreateAsync_ShouldThrowArgumentNullException_WhenMethodIsNull()
    {
        var policyMock = new Mock<IHttpRequestMessageConfigurationPolicy>();

        var factory = new HttpRequestMessageFactory(policyMock.Object);

        var act = () => factory.CreateAsync(null!, _uri, _content);

        await act.Should().ThrowAsync<ArgumentNullException>().ConfigureAwait(false);
    }

    [Test]
    public async Task CreateAsync_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        var policyMock = new Mock<IHttpRequestMessageConfigurationPolicy>();

        var factory = new HttpRequestMessageFactory(policyMock.Object);

        var act = () => factory.CreateAsync(_method, null!, _content);

        await act.Should().ThrowAsync<ArgumentNullException>().ConfigureAwait(false);
    }

    [Test]
    public async Task CreateAsync_ShouldThrowArgumentNullException_WhenContentIsNull()
    {
        var policyMock = new Mock<IHttpRequestMessageConfigurationPolicy>();

        var factory = new HttpRequestMessageFactory(policyMock.Object);

        var act = () => factory.CreateAsync(_method, _uri, null!);

        await act.Should().ThrowAsync<ArgumentNullException>().ConfigureAwait(false);
    }

    [Test]
    public async Task CreateAsync_ShouldInitPropertiesCorrectly()
    {
        var policyMock = new Mock<IHttpRequestMessageConfigurationPolicy>();

        var factory = new HttpRequestMessageFactory(policyMock.Object);

        using var message = await factory.CreateAsync(_method, _uri, _content).ConfigureAwait(false);

        message.Method.Should().Be(_method);
        message.RequestUri.Should().Be(_uri);
        message.Content.Should().Be(_content);
    }

    [Test]
    public async Task CreateAsync_ShouldApplyPolicy()
    {
        var policyMock = new Mock<IHttpRequestMessageConfigurationPolicy>();

        var factory = new HttpRequestMessageFactory(policyMock.Object);
        using var cts = new CancellationTokenSource();

        using var message = await factory.CreateAsync(_method, _uri, _content, cts.Token).ConfigureAwait(false);

        policyMock.Verify(x => x.ApplyPolicyAsync(message, cts.Token), Times.Once);
    }
}
