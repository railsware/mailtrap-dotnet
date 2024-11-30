// -----------------------------------------------------------------------
// <copyright file="EmailClientEndpointProviderTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Email;


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
        var expectedUrl = EndpointsTestConstants.SendDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.SendEmailSegment);

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
        var expectedUrl = EndpointsTestConstants.BulkDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.SendEmailSegment);

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
        var expectedUrl = EndpointsTestConstants.TestDefaultUrl
            .Append(
                UrlSegmentsTestConstants.ApiRootSegment,
                UrlSegmentsTestConstants.SendEmailSegment)
            .Append(inboxId);

        // Act
        var result = _emailClientEndpointProvider.GetSendRequestUri(isBulk, inboxId);

        // Assert
        result.Should().Be(expectedUrl);
    }
}
