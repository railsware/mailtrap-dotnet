// -----------------------------------------------------------------------
// <copyright file="HttpContentExtensionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Core.Extensions;


[TestFixture]
internal sealed class HttpContentExtensionsTests
{
    [Test]
    public void ApplyJsonContentTypeHeader_ShouldThrowArgumentNullException_WhenContentIsNull()
    {
        var act = () => HttpContentExtensions.ApplyJsonContentTypeHeader<HttpContent>(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ApplyJsonContentTypeHeader_ShouldApplyHeader()
    {
        using var content = new StringContent("content");

        content.ApplyJsonContentTypeHeader();

        content.Headers.ContentType!.MediaType.Should().Be(MimeTypes.Application.Json);
    }
}
