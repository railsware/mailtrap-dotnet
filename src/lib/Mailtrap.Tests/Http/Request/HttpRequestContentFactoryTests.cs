// -----------------------------------------------------------------------
// <copyright file="HttpRequestContentFactoryTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Http.Request;


[TestFixture]
internal sealed class HttpRequestContentFactoryTests
{
    [Test]
    public async Task CreateAsync_ShouldThrowArgumentNullException_WhenContentIsNull()
    {
        var factory = new HttpRequestContentFactory();

        var act = () => factory.CreateAsync(null!);

        await act.Should().ThrowAsync<ArgumentNullException>().ConfigureAwait(false);
    }

    [Test]
    public async Task CreateAsync_ShouldNotThrowException_WhenContentIsEmpty()
    {
        var factory = new HttpRequestContentFactory();

        var act = () => factory.CreateAsync(string.Empty);

        await act.Should().NotThrowAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task CreateAsync_ShouldApplyHeaders()
    {
        var factory = new HttpRequestContentFactory();

        using var content = await factory.CreateAsync(string.Empty).ConfigureAwait(false);

        content.Should().NotBeNull();
        content.Headers.Should().ContainKey("Content-Type");
        content.Headers.ContentType.Should().NotBeNull();
        content.Headers.ContentType!.MediaType.Should().Be(MimeTypes.Application.Json);
    }

    [Test]
    public async Task CreateAsync_ShouldSetContentPropely()
    {
        var factory = new HttpRequestContentFactory();

        var json = "content";

        using var content = await factory.CreateAsync(json).ConfigureAwait(false);

        var result = await content.ReadAsStringAsync().ConfigureAwait(false);

        result.Should().Be(json);
    }
}
