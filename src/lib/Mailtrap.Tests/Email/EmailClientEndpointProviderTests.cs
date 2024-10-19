// -----------------------------------------------------------------------
// <copyright file="EmailClientEndpointProviderTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email;


[TestFixture]
internal sealed class EmailClientEndpointProviderTests
{
    private EmailClientEndpointProvider _emailClientEndpointProvider;


    [SetUp]
    public void Setup()
    {
        _emailClientEndpointProvider = new EmailClientEndpointProvider();
    }


    [Test]
    public void GetSendRequestUri_ShouldReturnSendDefaultUrl_WhenIsNotBulkAndInboxIdIsNull()
    {
        // Arrange
        var isBulk = false;
        long? inboxId = null;
        var expectedUrl = Endpoints.SendDefaultUrl.Append(
            UrlSegments.ApiRootSegment, UrlSegments.SendEmailSegment);

        // Act
        var result = _emailClientEndpointProvider.GetSendRequestUri(isBulk, inboxId);

        // Assert
        result.Should().Be(expectedUrl);
    }

    [Test]
    public void GetSendRequestUri_ShouldReturnBulkDefaultUrl_WhenIsBulkAndInboxIdIsNull()
    {
        // Arrange
        var isBulk = true;
        long? inboxId = null;
        var expectedUrl = Endpoints.BulkDefaultUrl.Append(
            UrlSegments.ApiRootSegment, UrlSegments.SendEmailSegment);

        // Act
        var result = _emailClientEndpointProvider.GetSendRequestUri(isBulk, inboxId);

        // Assert
        result.Should().Be(expectedUrl);
    }

    [Test]
    public void GetSendRequestUri_ShouldReturnTestDefaultUrl_WhenInboxIdIsNotNull([Values] bool isBulk)
    {
        // Arrange
        long inboxId = 12345;
        var expectedUrl = Endpoints.TestDefaultUrl.Append(
            UrlSegments.ApiRootSegment, UrlSegments.SendEmailSegment, inboxId.ToString(CultureInfo.InvariantCulture));

        // Act
        var result = _emailClientEndpointProvider.GetSendRequestUri(isBulk, inboxId);

        // Assert
        result.Should().Be(expectedUrl);
    }
}
