// -----------------------------------------------------------------------
// <copyright file="ApiKeyHttpRequestMessageAuthenticationProviderTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Http.Request;


[TestFixture]
internal sealed class ApiKeyHttpRequestMessageAuthenticationProviderTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenParameterIsNull()
    {
        var act = () => new ApiKeyHttpRequestMessageAuthenticationProvider(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public async Task ApplyPolicyAsync_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        var tokenProviderMock = new Mock<IAccessTokenProvider>();
        var policy = new ApiKeyHttpRequestMessageAuthenticationProvider(tokenProviderMock.Object);

        var act = () => policy.AuthenticateAsync(null!);

        await act.Should().ThrowAsync<ArgumentNullException>().ConfigureAwait(false);
    }

    [Test]
    public async Task ApplyPolicyAsync_ShouldApplyHeaders()
    {
        using var request = new HttpRequestMessage();

        var token = "token";
        var tokenProviderMock = new Mock<IAccessTokenProvider>();
        tokenProviderMock.Setup(x => x.GetAccessTokenAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(token);
        var policy = new ApiKeyHttpRequestMessageAuthenticationProvider(tokenProviderMock.Object);

        await policy.AuthenticateAsync(request).ConfigureAwait(false);

        request.Headers.Should().ContainKey(HeaderNames.ApiKeyHeader);
        request.Headers.GetValues(HeaderNames.ApiKeyHeader).Should().ContainSingle(v => v == token);
    }
}
