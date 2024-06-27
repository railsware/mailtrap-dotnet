// -----------------------------------------------------------------------
// <copyright file="HttpRequestMessageConfigurationPolicyTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Http.Request;


[TestFixture]
internal sealed class HttpRequestMessageConfigurationPolicyTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenParameterIsNull()
    {
        var act = () => new HttpRequestMessageConfigurationPolicy(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public async Task ApplyPolicyAsync_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var authProviderMock = new Mock<IHttpRequestMessageAuthenticationProvider>();
        var policy = new HttpRequestMessageConfigurationPolicy(authProviderMock.Object);

        var act = () => policy.ApplyPolicyAsync(null!);

        await act.Should().ThrowAsync<ArgumentNullException>().ConfigureAwait(false);
    }

    [Test]
    public async Task ApplyPolicyAsync_ShouldApplyHeaders()
    {
        using var request = new HttpRequestMessage();

        var authProviderMock = new Mock<IHttpRequestMessageAuthenticationProvider>();
        var policy = new HttpRequestMessageConfigurationPolicy(authProviderMock.Object);

        await policy.ApplyPolicyAsync(request).ConfigureAwait(false);

        request.Headers.Should().ContainKey("Accept");
        request.Headers.Accept.Should().ContainSingle(h => h.MediaType == MimeTypes.Application.Json);

        authProviderMock.Verify(x => x.AuthenticateAsync(request, It.IsAny<CancellationToken>()), Times.Once);
    }
}
