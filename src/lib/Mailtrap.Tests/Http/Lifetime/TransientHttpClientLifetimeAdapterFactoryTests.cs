// -----------------------------------------------------------------------
// <copyright file="TransientHttpClientLifetimeAdapterFactoryTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Http.Request;


[TestFixture]
internal sealed class TransientHttpClientLifetimeAdapterFactoryTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenParameterIsNull()
    {
        var act = () => new TransientHttpClientLifetimeAdapterFactory(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public async Task GetClientAsync_ThrowArgumentNullException_WhenParameterIsNull()
    {
        var clientFactory = new Mock<IHttpClientFactory>();

        var factory = new TransientHttpClientLifetimeAdapterFactory(clientFactory.Object);

        var act = () => factory.GetClientAsync(null!);

        await act.Should().ThrowAsync<ArgumentNullException>().ConfigureAwait(false);
    }

    [Test]
    public async Task GetClientAsync_ShouldProvideDefaultConfiguredHttpClientInstance_WhenNoClientNameSpecified()
    {
        var client = Mock.Of<HttpClient>();

        var clientFactory = new Mock<IHttpClientFactory>();
        clientFactory.Setup(f => f.CreateClient(Options.DefaultName)).Returns(client);

        var factory = new TransientHttpClientLifetimeAdapterFactory(clientFactory.Object);

        var config = MailtrapClientEndpointOptions.SendDefault;

        using var adapter = await factory.GetClientAsync(config).ConfigureAwait(false);

        adapter.Should().NotBeNull();
        adapter.HttpClient.Should().NotBeNull().And.BeSameAs(client);

        clientFactory.Verify(f => f.CreateClient(Options.DefaultName), Times.Once);
    }

    [Test]
    public async Task GetClientAsync_ShouldProvideNamedConfiguredHttpClientInstance_WhenClientNameSpecified()
    {
        var client = Mock.Of<HttpClient>();
        var clientName = "send";

        var clientFactory = new Mock<IHttpClientFactory>();
        clientFactory.Setup(f => f.CreateClient(clientName)).Returns(client);

        var factory = new TransientHttpClientLifetimeAdapterFactory(clientFactory.Object);

        var config = MailtrapClientEndpointOptions.SendDefault with
        {
            HttpClientName = clientName
        };

        using var adapter = await factory.GetClientAsync(config).ConfigureAwait(false);

        adapter.Should().NotBeNull();
        adapter.HttpClient.Should().NotBeNull().And.BeSameAs(client);

        clientFactory.Verify(f => f.CreateClient(clientName), Times.Once);
    }
}
