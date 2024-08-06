// -----------------------------------------------------------------------
// <copyright file="HttpRequestContentFactoryTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Http;


[TestFixture]
internal sealed class HttpRequestContentFactoryTests
{
    [Test]
    public void Create_ShouldThrowArgumentNullException_WhenContentIsNull()
    {
        var factory = new HttpRequestContentFactory();

        var act = () => factory.CreateStringContent(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Create_ShouldNotThrowException_WhenContentIsEmpty()
    {
        var factory = new HttpRequestContentFactory();

        var act = () => factory.CreateStringContent(string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void Create_ShouldApplyHeaders()
    {
        var factory = new HttpRequestContentFactory();

        using var content = factory.CreateStringContent(string.Empty);

        content.Should().NotBeNull();
        content.Headers.Should().ContainKey("Content-Type");
        content.Headers.ContentType.Should().NotBeNull();
        content.Headers.ContentType!.MediaType.Should().Be(MimeTypes.Application.Json);
    }

    [Test]
    public async Task Create_ShouldSetContentProperly()
    {
        var factory = new HttpRequestContentFactory();

        var json = "content";

        using var content = factory.CreateStringContent(json);

        var result = await content.ReadAsStringAsync().ConfigureAwait(false);

        result.Should().Be(json);
    }
}
