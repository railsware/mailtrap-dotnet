// -----------------------------------------------------------------------
// <copyright file="EmailResourceTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Emails;


[TestFixture]
internal sealed class EmailResourceTests
{
    private readonly IRestResourceCommandFactory _commandFactoryMock = Mock.Of<IRestResourceCommandFactory>();
    private readonly Uri _resourceUri = EndpointsTestConstants.ApiDefaultUrl
        .Append(
            UrlSegmentsTestConstants.ApiRootSegment,
            UrlSegmentsTestConstants.AccountsSegment)
        .Append(TestContext.CurrentContext.Random.NextLong())
        .Append(UrlSegmentsTestConstants.InboxesSegment)
        .Append(TestContext.CurrentContext.Random.NextLong())
        .Append(UrlSegmentsTestConstants.EmailsSegment)
        .Append(TestContext.CurrentContext.Random.NextLong());


    #region Constructor

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenCommandFactoryIsNull()
    {
        // Act
        var act = () => new EmailResource(null!, _resourceUri);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        // Act
        var act = () => new EmailResource(_commandFactoryMock, null!);

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


    #region Attachments

    [Test]
    public void Attachments_ShouldReturnAttachmentCollectionResource()
    {
        // Arrange
        var client = CreateResource();

        // Act
        var result = client.Attachments();

        // Assert
        ResourceValidator.Validate<IAttachmentCollectionResource, AttachmentCollectionResource>(
            result, client.ResourceUri.Append(UrlSegmentsTestConstants.AttachmentsSegment));
    }

    [Test]
    public void Attachment_ShouldReturnAttachmentResource()
    {
        // Arrange
        var client = CreateResource();
        var attachmentId = TestContext.CurrentContext.Random.NextLong();

        // Act
        var result = client.Attachment(attachmentId);

        // Assert
        ResourceValidator.Validate<IAttachmentResource, AttachmentResource>(
            result, client.ResourceUri.Append(UrlSegmentsTestConstants.AttachmentsSegment).Append(attachmentId));
    }

    [Test]
    public void Attachment_ShouldThrowOutOfRangeException_WhenIdIsEqualOrLessThanZero([Values(0, -1)] long messageId)
    {
        // Arrange
        var client = CreateResource();

        // Act
        var act = () => client.Attachment(messageId);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    #endregion


    private EmailResource CreateResource() => new(_commandFactoryMock, _resourceUri);
}
