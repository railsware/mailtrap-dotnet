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
}
