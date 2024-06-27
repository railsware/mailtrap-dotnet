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

        var authProviderMock = new Mock<IHttpRequestMessageAuthenticationProvider>();
        var policy = new HttpRequestMessageConfigurationPolicy(authProviderMock.Object);

        using var request = new HttpRequestMessage();
        using var cts = new CancellationTokenSource();

        await policy.ApplyPolicyAsync(request, cts.Token).ConfigureAwait(false);

        authProviderMock.Verify(x => x.AuthenticateAsync(request, cts.Token), Times.Once);

        request.Headers.Should().ContainKey("Accept");
        request.Headers.Accept.Should().ContainSingle(h => h.MediaType == MimeTypes.Application.Json);
    }
}
