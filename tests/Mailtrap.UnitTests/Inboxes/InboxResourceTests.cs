// -----------------------------------------------------------------------
// <copyright file="InboxResourceTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Inboxes;


[TestFixture]
internal sealed class InboxResourceTests
{
    private readonly IRestResourceCommandFactory _commandFactoryMock = Mock.Of<IRestResourceCommandFactory>();
    private readonly Uri _resourceUri = EndpointsTestConstants.ApiDefaultUrl
        .Append(
            UrlSegmentsTestConstants.ApiRootSegment,
            UrlSegmentsTestConstants.AccountsSegment)
        .Append(TestContext.CurrentContext.Random.NextLong())
        .Append(UrlSegmentsTestConstants.InboxesSegment)
        .Append(TestContext.CurrentContext.Random.NextLong());


    #region Constructor

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenCommandFactoryIsNull()
    {
        // Act
        var act = () => new InboxResource(null!, _resourceUri);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        // Act
        var act = () => new InboxResource(_commandFactoryMock, null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ResourceUri_ShouldBeInitializedProperly()
    {
        // Arrange
        var client = CreateResource();

        // Assert
        client.ResourceUri.Should().Be(_resourceUri);
    }

    #endregion


    #region Messages

    [Test]
    public void Messages_ShouldReturnTestingMessageCollectionResource()
    {
        // Arrange
        var client = CreateResource();

        // Act
        var result = client.Messages();

        // Assert
        ResourceValidator.Validate<ITestingMessageCollectionResource, TestingMessageCollectionResource>(
            result, client.ResourceUri.Append(UrlSegmentsTestConstants.MessagesSegment));
    }

    [Test]
    public void Message_ShouldReturnTestingMessageResource()
    {
        // Arrange
        var client = CreateResource();
        var emailId = TestContext.CurrentContext.Random.NextLong();

        // Act
        var result = client.Message(emailId);

        // Assert
        ResourceValidator.Validate<ITestingMessageResource, TestingMessageResource>(
            result, client.ResourceUri.Append(UrlSegmentsTestConstants.MessagesSegment).Append(emailId));
    }

    [Test]
    public void Message_ShouldThrowOutOfRangeException_WhenIdIsEqualOrLessThanZero([Values(0, -1)] long messageId)
    {
        // Arrange
        var client = CreateResource();

        // Act
        var act = () => client.Message(messageId);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    #endregion


    private InboxResource CreateResource() => new(_commandFactoryMock, _resourceUri);
}
