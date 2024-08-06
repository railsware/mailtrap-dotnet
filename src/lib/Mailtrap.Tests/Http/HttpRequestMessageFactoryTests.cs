// -----------------------------------------------------------------------
// <copyright file="HttpRequestMessageFactoryTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Http;


[TestFixture]
internal sealed class HttpRequestMessageFactoryTests
{
    private HttpMethod _method { get; } = HttpMethod.Post;
    private Uri _uri { get; } = new("https://domain.com");
    private StringContent _content { get; } = new("content");


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenOptionsIsNull()
    {
        var act = () => new HttpRequestMessageFactory(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Create_ShouldThrowArgumentNullException_WhenMethodIsNull()
    {
        var options = Options.Create(new MailtrapClientOptions("token"));

        var factory = new HttpRequestMessageFactory(options);

        var act = () => factory.Create(null!, _uri, _content);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Create_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        var options = Options.Create(new MailtrapClientOptions("token"));

        var factory = new HttpRequestMessageFactory(options);

        var act = () => factory.Create(_method, null!, _content);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Create_ShouldThrowArgumentNullException_WhenContentIsNull()
    {
        var options = Options.Create(new MailtrapClientOptions("token"));

        var factory = new HttpRequestMessageFactory(options);

        var act = () => factory.Create(_method, _uri, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Create_ShouldInitPropertiesCorrectly()
    {
        var options = Options.Create(new MailtrapClientOptions("token"));

        var factory = new HttpRequestMessageFactory(options);

        using var message = factory.Create(_method, _uri, _content);

        message.Method.Should().Be(_method);
        message.RequestUri.Should().Be(_uri);
        message.Content.Should().Be(_content);
    }

    [Test]
    public void Create_ShouldApplyHeaders()
    {
        var token = "token";

        var options = Options.Create(new MailtrapClientOptions(token));

        var factory = new HttpRequestMessageFactory(options);

        using var message = factory.Create(_method, _uri, _content);

        message.Headers.Should().ContainKey("Accept");
        message.Headers.Accept.Should()
            .NotBeNull().And
            .ContainSingle(h => h.MediaType == MimeTypes.Application.Json);

        message.Headers.Should().ContainKey("User-Agent");
        message.Headers.UserAgent.Should()
            .NotBeNull().And
            .ContainSingle(h =>
                h.Product!.Name == HeaderValues.UserAgentName &&
                h.Product!.Version == HeaderValues.UserAgentVersion);

        message.Headers.Should().ContainKey("Authorization");
        message.Headers.Authorization.Should()
            .NotBeNull().And
            .BeEquivalentTo(new AuthenticationHeaderValue("Bearer", token));
    }
}
