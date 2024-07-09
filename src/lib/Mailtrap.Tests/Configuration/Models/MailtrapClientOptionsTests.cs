// -----------------------------------------------------------------------
// <copyright file="MailtrapClientOptionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Configuration.Models;


[TestFixture]
internal sealed class MailtrapClientOptionsTests
{
    [Test]
    public void Default_ShouldReturnValidDefaults()
    {
        MailtrapClientOptions.Default.Serialization.Should().Be(MailtrapClientSerializationOptions.Default);
        MailtrapClientOptions.Default.Authentication.Should().Be(MailtrapClientAuthenticationOptions.Empty);
        MailtrapClientOptions.Default.SendEndpoint.Should().Be(MailtrapClientEndpointOptions.SendDefault);
        MailtrapClientOptions.Default.BulkEndpoint.Should().Be(MailtrapClientEndpointOptions.BulkDefault);
        MailtrapClientOptions.Default.TestEndpoint.Should().Be(MailtrapClientEndpointOptions.TestDefault);
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenAuthenticationSettingsIsNull()
    {
        MailtrapClientAuthenticationOptions? options = null;

        var act = () => new MailtrapClientOptions(options!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldAssignAuthenticationSettings()
    {
        var auth = new MailtrapClientAuthenticationOptions("token");

        var options = new MailtrapClientOptions(auth);

        options.Authentication.Should().BeSameAs(auth);
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenApiKeyIsNull()
    {
        string? apiKey = null;

        var act = () => new MailtrapClientOptions(apiKey!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldAssignApiTokenSettings()
    {
        var token = "token";

        var options = new MailtrapClientOptions(token);

        options.Authentication.ApiToken.Should().Be(token);
    }
}
