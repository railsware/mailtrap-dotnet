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
        var policies = Enumerable.Empty<IHttpRequestMessagePolicy>();

        var factory = new HttpRequestMessageFactory(policies);

        var act = () => factory.CreateAsync(null!, _uri, _content);

        await act.Should().ThrowAsync<ArgumentNullException>().ConfigureAwait(false);
    }

    [Test]
    public async Task CreateAsync_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        var policies = Enumerable.Empty<IHttpRequestMessagePolicy>();

        var factory = new HttpRequestMessageFactory(policies);

        var act = () => factory.CreateAsync(_method, null!, _content);

        await act.Should().ThrowAsync<ArgumentNullException>().ConfigureAwait(false);
    }

    [Test]
    public async Task CreateAsync_ShouldThrowArgumentNullException_WhenContentIsNull()
    {
        var policies = Enumerable.Empty<IHttpRequestMessagePolicy>();

        var factory = new HttpRequestMessageFactory(policies);

        var act = () => factory.CreateAsync(_method, _uri, null!);

        await act.Should().ThrowAsync<ArgumentNullException>().ConfigureAwait(false);
    }

    [Test]
    public async Task CreateAsync_ShouldInitPropertiesCorrectly()
    {
        var policies = Enumerable.Empty<IHttpRequestMessagePolicy>();

        var factory = new HttpRequestMessageFactory(policies);

        using var message = await factory.CreateAsync(_method, _uri, _content).ConfigureAwait(false);

        message.Method.Should().Be(_method);
        message.RequestUri.Should().Be(_uri);
        message.Content.Should().Be(_content);
    }

    [Test]
    public async Task CreateAsync_ShouldApplyPolicies()
    {
        var numberOfPolicies = 3;

        var policyMocks = new List<Mock<IHttpRequestMessagePolicy>>(numberOfPolicies);

        for (var i = 0; i < numberOfPolicies; i++)
        {
            policyMocks.Add(new Mock<IHttpRequestMessagePolicy>());
        }

        var factory = new HttpRequestMessageFactory(policyMocks.Select(m => m.Object));

        using var cts = new CancellationTokenSource();

        using var message = await factory.CreateAsync(_method, _uri, _content, cts.Token).ConfigureAwait(false);

        foreach (var policyMock in policyMocks)
        {
            policyMock.Verify(x => x.ApplyPolicyAsync(message, cts.Token), Times.Once);
        }
    }
}
