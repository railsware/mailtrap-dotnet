// -----------------------------------------------------------------------
// <copyright file="EmailClientFactoryTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Tests.Email;


[TestFixture]
internal sealed class EmailClientFactoryTests
{
    #region Constructor

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenOptionsIsNull()
    {
        var httpClientFactoryMock = Mock.Of<IHttpClientFactory>();
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();
        var emailClientEndpointProviderMock = Mock.Of<IEmailClientEndpointProvider>();

        var act = () => new EmailClientFactory(
            null!,
            httpClientFactoryMock,
            httpRequestMessageFactoryMock,
            httpRequestContentFactoryMock,
            emailClientEndpointProviderMock);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenHttpClientFactoryIsNull()
    {
        var optionsMock = Mock.Of<IOptions<MailtrapClientOptions>>();
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();
        var emailClientEndpointProviderMock = Mock.Of<IEmailClientEndpointProvider>();

        var act = () => new EmailClientFactory(
            optionsMock,
            null!,
            httpRequestMessageFactoryMock,
            httpRequestContentFactoryMock,
            emailClientEndpointProviderMock);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenHttpRequestMessageFactoryIsNull()
    {
        var optionsMock = Mock.Of<IOptions<MailtrapClientOptions>>();
        var httpClientFactoryMock = Mock.Of<IHttpClientFactory>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();
        var emailClientEndpointProviderMock = Mock.Of<IEmailClientEndpointProvider>();

        var act = () => new EmailClientFactory(
            optionsMock,
            httpClientFactoryMock,
            null!,
            httpRequestContentFactoryMock,
            emailClientEndpointProviderMock);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenHttpRequestContentFactoryIsNull()
    {
        var optionsMock = Mock.Of<IOptions<MailtrapClientOptions>>();
        var httpClientFactoryMock = Mock.Of<IHttpClientFactory>();
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();
        var emailClientEndpointProviderMock = Mock.Of<IEmailClientEndpointProvider>();

        var act = () => new EmailClientFactory(
            optionsMock,
            httpClientFactoryMock,
            httpRequestMessageFactoryMock,
            null!,
            emailClientEndpointProviderMock);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenEndpointProviderIsNull()
    {
        var optionsMock = Mock.Of<IOptions<MailtrapClientOptions>>();
        var httpClientFactoryMock = Mock.Of<IHttpClientFactory>();
        var httpRequestMessageFactoryMock = Mock.Of<IHttpRequestMessageFactory>();
        var httpRequestContentFactoryMock = Mock.Of<IHttpRequestContentFactory>();

        var act = () => new EmailClientFactory(
            optionsMock,
            httpClientFactoryMock,
            httpRequestMessageFactoryMock,
            httpRequestContentFactoryMock,
            null!);

        act.Should().Throw<ArgumentNullException>();
    }

    #endregion


    [Test]
    public void Create_ShouldReturnEmailClient([Values] bool isBulk, [Random(2)] long inboxId)
    {
        // Arrange
        var sendUri = new Uri("https://localhost/api/send");

        var emailClientEndpointProviderMock = new Mock<IEmailClientEndpointProvider>();
        emailClientEndpointProviderMock
            .Setup(x => x.GetSendRequestUri(isBulk, inboxId))
            .Returns(sendUri);

        var options = CreateOptions(isBulk, inboxId);
        var emailClientFactory = new EmailClientFactory(
            options,
            Mock.Of<IHttpClientFactory>(),
            Mock.Of<IHttpRequestMessageFactory>(),
            Mock.Of<IHttpRequestContentFactory>(),
            emailClientEndpointProviderMock.Object);

        // Act
        var result = emailClientFactory.Create(isBulk, inboxId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<EmailClient>();
        result.SendUri.Should().Be(sendUri);
    }

    [Test]
    public void CreateDefault_ShouldReturnEmailClient([Values] bool isBulk, [Random(2)] long inboxId)
    {
        // Arrange
        var sendUri = new Uri("https://localhost/api/send");

        var emailClientEndpointProviderMock = new Mock<IEmailClientEndpointProvider>();
        emailClientEndpointProviderMock
            .Setup(x => x.GetSendRequestUri(isBulk, inboxId))
            .Returns(sendUri);

        var options = CreateOptions(isBulk, inboxId);
        var emailClientFactory = new EmailClientFactory(
            options,
            Mock.Of<IHttpClientFactory>(),
            Mock.Of<IHttpRequestMessageFactory>(),
            Mock.Of<IHttpRequestContentFactory>(),
            emailClientEndpointProviderMock.Object);

        // Act
        var result = emailClientFactory.CreateDefault();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<EmailClient>();
        result.SendUri.Should().Be(sendUri);
    }

    [Test]
    public void CreateTransactional_ShouldReturnEmailClient([Values] bool isBulk, [Random(2)] long inboxId)
    {
        // Arrange
        var sendUri = new Uri("https://localhost/api/send");

        var emailClientEndpointProviderMock = new Mock<IEmailClientEndpointProvider>();
        emailClientEndpointProviderMock
            .Setup(x => x.GetSendRequestUri(false, null))
            .Returns(sendUri);

        var options = CreateOptions(isBulk, inboxId);
        var emailClientFactory = new EmailClientFactory(
            options,
            Mock.Of<IHttpClientFactory>(),
            Mock.Of<IHttpRequestMessageFactory>(),
            Mock.Of<IHttpRequestContentFactory>(),
            emailClientEndpointProviderMock.Object);

        // Act
        var result = emailClientFactory.CreateTransactional();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<EmailClient>();
        result.SendUri.Should().Be(sendUri);
    }

    [Test]
    public void CreateBulk_ShouldReturnEmailClient([Values] bool isBulk, [Random(2)] long inboxId)
    {
        // Arrange
        var sendUri = new Uri("https://localhost/api/send");

        var emailClientEndpointProviderMock = new Mock<IEmailClientEndpointProvider>();
        emailClientEndpointProviderMock
            .Setup(x => x.GetSendRequestUri(true, null))
            .Returns(sendUri);

        var options = CreateOptions(isBulk, inboxId);
        var emailClientFactory = new EmailClientFactory(
            options,
            Mock.Of<IHttpClientFactory>(),
            Mock.Of<IHttpRequestMessageFactory>(),
            Mock.Of<IHttpRequestContentFactory>(),
            emailClientEndpointProviderMock.Object);

        // Act
        var result = emailClientFactory.CreateBulk();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<EmailClient>();
        result.SendUri.Should().Be(sendUri);
    }

    [Test]
    public void CreateTest_ShouldReturnEmailClient([Values] bool isBulk, [Random(2)] long inboxId)
    {
        // Arrange
        var sendUri = new Uri("https://localhost/api/send");

        var emailClientEndpointProviderMock = new Mock<IEmailClientEndpointProvider>();
        emailClientEndpointProviderMock
            .Setup(x => x.GetSendRequestUri(false, inboxId))
            .Returns(sendUri);

        var options = CreateOptions(isBulk, inboxId);
        var emailClientFactory = new EmailClientFactory(
            options,
            Mock.Of<IHttpClientFactory>(),
            Mock.Of<IHttpRequestMessageFactory>(),
            Mock.Of<IHttpRequestContentFactory>(),
            emailClientEndpointProviderMock.Object);

        // Act
        var result = emailClientFactory.CreateTest(inboxId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<EmailClient>();
        result.SendUri.Should().Be(sendUri);
    }


    private static IOptions<MailtrapClientOptions> CreateOptions(bool isBulk, long inboxId)
    {
        var token = "token";

        var config = new MailtrapClientOptions(token)
        {
            InboxId = inboxId,
            UseBulkApi = isBulk
        };

        var options = Options.Create(config);
        return options;
    }
}
