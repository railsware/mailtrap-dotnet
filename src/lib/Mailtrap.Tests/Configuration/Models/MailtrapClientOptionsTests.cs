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
        var options = MailtrapClientOptions.Default;

        options.Serialization.Should().Be(MailtrapClientSerializationOptions.Default);
        options.Authentication.Should().Be(MailtrapClientAuthenticationOptions.Empty);
        options.SendEndpoint.Should().Be(MailtrapClientEndpointOptions.SendDefault);
        options.BulkEndpoint.Should().Be(MailtrapClientEndpointOptions.BulkDefault);
        options.TestEndpoint.Should().Be(MailtrapClientEndpointOptions.TestDefault);
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
        var act = () => new MailtrapClientOptions(null!);

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

    [Test]
    public void Init_ShouldThrowArgumentNullException_WhenSourceIsNull()
    {
        var act = () => MailtrapClientOptions.Default.Init(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Init_ShouldCopyFieldsFromSource()
    {
        var source = MailtrapClientOptions.Default;
        var target = new MailtrapClientOptions("token");

        target.Init(source);

        target.Should().BeEquivalentTo(source);
        target.Authentication.Should().BeSameAs(source.Authentication);
        target.Serialization.Should().BeSameAs(source.Serialization);
        target.SendEndpoint.Should().BeSameAs(source.SendEndpoint);
        target.BulkEndpoint.Should().BeSameAs(source.BulkEndpoint);
        target.TestEndpoint.Should().BeSameAs(source.TestEndpoint);
    }

    [Test]
    public void GetSendEndpointConfiguration_ShouldThrowArgumentNullException_WhenEndpointIsNull()
    {
        var act = () => MailtrapClientOptions.Default.GetSendEndpointConfiguration(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void GetSendEndpointConfiguration_ShouldThrowArgumentException_WhenUnsupportedEndpointValueProvided()
    {
        var act = () => MailtrapClientOptions.Default.GetSendEndpointConfiguration(SendEndpoint.None);

        act.Should().Throw<ArgumentException>();
    }

    [Test]
    public void GetSendEndpointConfiguration_ShouldReturnProperValue_ForSendEndpoint()
    {
        var config = MailtrapClientOptions.Default;

        var endpoint = config.GetSendEndpointConfiguration(SendEndpoint.Transactional);

        endpoint.Should().BeSameAs(config.SendEndpoint);
    }

    [Test]
    public void GetSendEndpointConfiguration_ShouldReturnProperValue_ForBulkEndpoint()
    {
        var config = MailtrapClientOptions.Default;

        var endpoint = config.GetSendEndpointConfiguration(SendEndpoint.Bulk);

        endpoint.Should().BeSameAs(config.BulkEndpoint);
    }

    [Test]
    public void GetSendEndpointConfiguration_ShouldReturnProperValue_ForTestEndpoint()
    {
        var config = MailtrapClientOptions.Default;

        var endpoint = config.GetSendEndpointConfiguration(SendEndpoint.Test);

        endpoint.Should().BeSameAs(config.TestEndpoint);
    }
}
