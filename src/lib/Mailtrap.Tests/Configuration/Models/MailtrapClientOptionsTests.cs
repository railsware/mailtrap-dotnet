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
    public void Default_ShouldReturnNewObjectEveryTime_WhenCalled()
    {
        var options1 = MailtrapClientOptions.Default;
        var options2 = MailtrapClientOptions.Default;

        options1.Should().NotBeSameAs(options2);
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenApiTokenIsNull()
    {
        string? token = null;

        var act = () => new MailtrapClientOptions(token!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenApiTokenIsEmpty()
    {
        var act = () => new MailtrapClientOptions(string.Empty);

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
