// -----------------------------------------------------------------------
// <copyright file="StaticHttpClientLifetimeAdapterTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Tests.Http.Lifetime;


[TestFixture]
internal sealed class StaticHttpClientLifetimeAdapterTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenParameterIsNull()
    {
        var act = () => new StaticHttpClientLifetimeAdapter(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldAssignProvidedHttpClientInstance()
    {
        var client = Mock.Of<HttpClient>();

        using var adapter = new StaticHttpClientLifetimeAdapter(client);

        adapter.HttpClient.Should().BeSameAs(client);
    }

    [Test]
    public void Dispose_ShouldNotDisposeProvidedHttpClientInstance()
    {
        // Unfortunately it is impossible to mock HttpClient.Dispose() method,
        // since it cannot be mocked or overrided,
        // thus using real HttpClient instance and exceptions for testing.

        using var client = new HttpClient();

        var adapter = new StaticHttpClientLifetimeAdapter(client);
        adapter.Dispose();

        var act = () => client.BaseAddress = new Uri("http://example.com");

        act.Should().NotThrow();
    }
}
