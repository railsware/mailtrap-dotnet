// -----------------------------------------------------------------------
// <copyright file="MailtrapClientTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests;


[TestFixture]
internal sealed class MailtrapClientTests
{
    private IEmailClient _emailClient;
    private readonly IRestResourceCommandFactory _commandFactoryMock = Mock.Of<IRestResourceCommandFactory>();


    [SetUp]
    public void Setup()
    {
        _emailClient = Mock.Of<IEmailClient>();
    }


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenEmailFactoryIsNull()
    {
        // Act
        var act = () => new MailtrapClient(null!, _commandFactoryMock);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenCommandFactoryIsNull()
    {
        // Act
        var act = () => new MailtrapClient(Mock.Of<IEmailClientFactory>(), null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }


    [Test]
    public void Email_ShouldReturnDefaultEmailClient()
    {
        // Arrange
        var emailClientFactoryMock = new Mock<IEmailClientFactory>();
        emailClientFactoryMock
            .Setup(f => f.CreateDefault())
            .Returns(_emailClient);
        var client = new MailtrapClient(emailClientFactoryMock.Object, _commandFactoryMock);

        // Act
        var result = client.Email();

        // Assert
        result.Should().BeSameAs(_emailClient);
    }

    [Test]
    public void Transactional_ShouldReturnNewEmailClient()
    {
        // Arrange
        var emailClientFactoryMock = new Mock<IEmailClientFactory>();
        emailClientFactoryMock
            .Setup(f => f.CreateTransactional())
            .Returns(_emailClient);
        var client = new MailtrapClient(emailClientFactoryMock.Object, _commandFactoryMock);

        // Act
        var result = client.Transactional();

        // Assert
        result.Should().BeSameAs(_emailClient);
    }

    [Test]
    public void Bulk_ShouldReturnNewBulkEmailClient()
    {
        // Arrange
        var emailClientFactoryMock = new Mock<IEmailClientFactory>();
        emailClientFactoryMock
            .Setup(f => f.CreateBulk())
            .Returns(_emailClient);
        var client = new MailtrapClient(emailClientFactoryMock.Object, _commandFactoryMock);

        // Act
        var result = client.Bulk();

        // Assert
        result.Should().BeSameAs(_emailClient);
    }

    [Test]
    public void Test_ShouldReturnNewEmailClientWithInboxId()
    {
        // Arrange
        var inboxId = 123;
        var emailClientFactoryMock = new Mock<IEmailClientFactory>();
        emailClientFactoryMock
            .Setup(f => f.CreateTest(inboxId))
            .Returns(_emailClient);
        var client = new MailtrapClient(emailClientFactoryMock.Object, _commandFactoryMock);

        // Act
        var result = client.Test(inboxId);

        // Assert
        result.Should().BeSameAs(_emailClient);
    }
}
