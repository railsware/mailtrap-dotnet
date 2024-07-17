// -----------------------------------------------------------------------
// <copyright file="HeadersHttpRequestMessagePolicyTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Http.Request;


[TestFixture]
internal sealed class HeadersHttpRequestMessagePolicyTests
{
    [Test]
    public async Task ApplyPolicyAsync_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var policy = new HeadersHttpRequestMessagePolicy();

        var act = () => policy.ApplyPolicyAsync(null!);

        await act.Should().ThrowAsync<ArgumentNullException>().ConfigureAwait(false);
    }

    [Test]
    public async Task ApplyPolicyAsync_ShouldApplyHeaders()
    {
        var policy = new HeadersHttpRequestMessagePolicy();

        using var request = new HttpRequestMessage();

        await policy.ApplyPolicyAsync(request).ConfigureAwait(false);

        request.Headers.Should().ContainKey("Accept");
        request.Headers.Accept.Should()
            .NotBeNull().And
            .ContainSingle(h => h.MediaType == MimeTypes.Application.Json);

        request.Headers.Should().ContainKey("User-Agent");
        request.Headers.UserAgent.Should()
            .NotBeNull().And
            .ContainSingle(h =>
                h.Product!.Name == HeaderValues.UserAgentName &&
                h.Product!.Version == HeaderValues.UserAgentVersion);
    }
}
