// -----------------------------------------------------------------------
// <copyright file="StaticHttpClientLifetimeAdapterFactoryTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Http.Lifetime;


[TestFixture]
internal sealed class StaticHttpClientLifetimeAdapterFactoryTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenParameterIsNull()
    {
        var act = () => new StaticHttpClientLifetimeAdapterFactory(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public async Task GetClientAsync_ShouldProvidePreconfiguredHttpClientInstance()
    {
        var client = Mock.Of<HttpClient>();

        var factory = new StaticHttpClientLifetimeAdapterFactory(client);

        using var adapter = await factory.CreateAsync(MailtrapClientEndpointOptions.SendDefault).ConfigureAwait(false);

        adapter.Client.Should().BeSameAs(client);
    }

    [Test]
    public async Task GetClientAsync_ShouldReturnSameHttpClientInstanceEveryTime()
    {
        var client = Mock.Of<HttpClient>();

        var factory = new StaticHttpClientLifetimeAdapterFactory(client);

        using var adapter1 = await factory.CreateAsync(MailtrapClientEndpointOptions.SendDefault).ConfigureAwait(false);
        using var adapter2 = await factory.CreateAsync(MailtrapClientEndpointOptions.SendDefault).ConfigureAwait(false);

        adapter2.Client.Should().BeSameAs(adapter1.Client);
    }
}
