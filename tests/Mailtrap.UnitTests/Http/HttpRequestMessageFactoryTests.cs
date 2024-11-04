// -----------------------------------------------------------------------
// <copyright file="HttpRequestMessageFactoryTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.UnitTests.Http;


[TestFixture]
internal sealed class HttpRequestMessageFactoryTests
{
    private HttpMethod _method { get; } = HttpMethod.Post;
    private Uri _uri { get; } = new("https://domain.com");
    private string _content { get; } = "content";
    private IOptions<MailtrapClientOptions> _options { get; } =
        Options.Create(new MailtrapClientOptions("token"));


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenOptionsIsNull()
    {
        var contentFactoryMock = Mock.Of<IHttpRequestContentFactory>();

        var act = () => new HttpRequestMessageFactory(null!, contentFactoryMock);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenContentFactoryIsNull()
    {
        var act = () => new HttpRequestMessageFactory(_options, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void CreateWithContent_ShouldThrowArgumentNullException_WhenMethodIsNull()
    {
        var contentFactoryMock = Mock.Of<IHttpRequestContentFactory>();
        var factory = new HttpRequestMessageFactory(_options, contentFactoryMock);

        var act = () => factory.CreateWithContent(null!, _uri, _content);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void CreateWithContent_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        var contentFactoryMock = Mock.Of<IHttpRequestContentFactory>();
        var factory = new HttpRequestMessageFactory(_options, contentFactoryMock);

        var act = () => factory.CreateWithContent(_method, null!, _content);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void CreateWithContent_ShouldInitPropertiesCorrectly_WhenContentIsNull()
    {
        var contentFactoryMock = Mock.Of<IHttpRequestContentFactory>();
        var factory = new HttpRequestMessageFactory(_options, contentFactoryMock);

        using var message = factory.CreateWithContent<object>(_method, _uri, null);

        message.Method.Should().Be(_method);
        message.RequestUri.Should().Be(_uri);
        message.Content.Should().BeNull();
    }

    [Test]
    public void CreateWithContent_ShouldInitPropertiesCorrectly()
    {
        using var httpContent = new StringContent(_content);
        var contentFactoryMock = new Mock<IHttpRequestContentFactory>();
        contentFactoryMock
            .Setup(f => f.CreateStringContent(_content))
            .Returns(httpContent);
        var factory = new HttpRequestMessageFactory(_options, contentFactoryMock.Object);

        using var message = factory.CreateWithContent(_method, _uri, _content);

        message.Method.Should().Be(_method);
        message.RequestUri.Should().Be(_uri);
        message.Content.Should().Be(httpContent);
    }

    [Test]
    public void CreateWithContent_ShouldApplyHeaders()
    {
        var token = "token";

        var options = Options.Create(new MailtrapClientOptions(token));
        var contentFactoryMock = Mock.Of<IHttpRequestContentFactory>();

        var factory = new HttpRequestMessageFactory(options, contentFactoryMock);

        using var message = factory.CreateWithContent(_method, _uri, _content);

        message.Headers.Should().ContainKey("Accept");
        message.Headers.Accept.Should()
            .NotBeNull().And
            .ContainSingle(h => h.MediaType == MimeTypes.Application.Json);

        message.Headers.Should().ContainKey("User-Agent");
        message.Headers.UserAgent.Should()
            .NotBeNull().And
            .ContainSingle(h =>
                h.Product!.Name == HeaderValuesTestConstants.UserAgentName &&
                h.Product!.Version == HeaderValues.UserAgentVersion);

        message.Headers.Should().ContainKey("Authorization");
        message.Headers.Authorization.Should()
            .NotBeNull().And
            .BeEquivalentTo(new AuthenticationHeaderValue("Bearer", token));
    }
}
