// -----------------------------------------------------------------------
// <copyright file="MailtrapClientConfigurationProviderTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Authentication;


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
    public void Configuration_ShouldProvideConfiguredValue()
    {
        var options = Options.Create(MailtrapClientOptions.Default);

        var provider = new MailtrapClientConfigurationProvider(options);

        provider.Configuration.Should().Be(MailtrapClientOptions.Default);
    }
}
