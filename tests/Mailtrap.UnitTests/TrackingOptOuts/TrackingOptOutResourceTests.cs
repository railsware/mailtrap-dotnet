namespace Mailtrap.UnitTests.TrackingOptOuts;


[TestFixture]
internal sealed class TrackingOptOutResourceTests
{
    private readonly IRestResourceCommandFactory _commandFactoryMock = Mock.Of<IRestResourceCommandFactory>();
    private readonly Uri _resourceUri = EndpointsTestConstants.ApiDefaultUrl
        .Append(UrlSegmentsTestConstants.ApiRootSegment)
        .Append(UrlSegmentsTestConstants.TrackingOptOutsSegment)
        .Append(TestContext.CurrentContext.Random.NextGuid().ToString());


    #region Constructor

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenCommandFactoryIsNull()
    {
        // Act
        var act = () => new TrackingOptOutResource(null!, _resourceUri);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        // Act
        var act = () => new TrackingOptOutResource(_commandFactoryMock, null!);

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



    private TrackingOptOutResource CreateResource() => new(_commandFactoryMock, _resourceUri);
}
