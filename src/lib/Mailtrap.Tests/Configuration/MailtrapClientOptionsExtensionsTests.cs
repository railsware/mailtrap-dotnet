// -----------------------------------------------------------------------
// <copyright file="MailtrapClientOptionsExtensionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Tests.Configuration;


[TestFixture]
internal sealed class MailtrapClientOptionsExtensionsTests
{
    [Test]
    public void GetEndpoint_ShouldThrowArgumentNullException_WhenOptionsAreNull()
    {
        var act = () => MailtrapClientOptionsExtensions.GetEndpoint(null!, Endpoint.Send);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void GetEndpoint_ShouldThrowArgumentOutOfRangeException_WhenUnknownEndpointValueProvided()
    {
        var act = () => MailtrapClientOptions.Default.GetEndpoint((Endpoint)42);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Test]
    public void GetEndpoint_ShouldReturnProperValue_ForSendEndpoint()
    {
        var config = MailtrapClientOptions.Default.GetEndpoint(Endpoint.Send);

        config.Should().BeSameAs(MailtrapClientOptions.Default.SendEndpoint);
    }

    [Test]
    public void GetEndpoint_ShouldReturnProperValue_ForBulkEndpoint()
    {
        var config = MailtrapClientOptions.Default.GetEndpoint(Endpoint.Bulk);

        config.Should().BeSameAs(MailtrapClientOptions.Default.BulkEndpoint);
    }

    [Test]
    public void GetEndpoint_ShouldReturnProperValue_ForTestEndpoint()
    {
        var config = MailtrapClientOptions.Default.GetEndpoint(Endpoint.Test);

        config.Should().BeSameAs(MailtrapClientOptions.Default.TestEndpoint);
    }
}
