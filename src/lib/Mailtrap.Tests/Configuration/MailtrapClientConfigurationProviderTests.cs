// -----------------------------------------------------------------------
// <copyright file="MailtrapClientConfigurationProviderTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Configuration;


[TestFixture]
internal sealed class MailtrapClientConfigurationProviderTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenOptionsAreNull()
    {
        var act = () => new MailtrapClientConfigurationProvider(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentException_WhenOptionsAreInvalid()
    {
        var options = Options.Create(MailtrapClientOptions.Default);

        var act = () => new MailtrapClientConfigurationProvider(options);

        act.Should().Throw<ArgumentException>();
    }

    [Test]
    public void Configuration_ShouldProvideConfiguredValue()
    {
        var config = MailtrapClientOptions.Default with
        {
            Authentication = new MailtrapClientAuthenticationOptions("token")
        };

        var options = Options.Create(config);

        var provider = new MailtrapClientConfigurationProvider(options);

        provider.Configuration.Should().Be(config);
    }
}
