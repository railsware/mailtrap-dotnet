// -----------------------------------------------------------------------
// <copyright file="AccessTokenProviderTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Authentication;


[TestFixture]
internal sealed class AccessTokenProviderTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenOptionsAreNull()
    {
        var act = () => new AccessTokenProvider(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenApiTokenIsEmpty()
    {
        var options = Options.Create(MailtrapClientOptions.Default);

        var act = () => new AccessTokenProvider(options);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public async Task GetAccessTokenAsync_ShouldProvideToken_WhenWasInitialized()
    {
        var options = Options.Create(MailtrapClientOptions.Default with
        {
            Authentication = new MailtrapClientAuthenticationOptions("token")
        });

        var provider = new AccessTokenProvider(options);

        var token = await provider.GetAccessTokenAsync().ConfigureAwait(false);

        token.Should().Be(options.Value.Authentication.ApiToken);
    }
}
