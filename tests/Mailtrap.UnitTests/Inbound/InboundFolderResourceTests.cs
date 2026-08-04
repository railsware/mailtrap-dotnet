namespace Mailtrap.UnitTests.Inbound;


[TestFixture]
internal sealed class InboundFolderResourceTests
{
    private readonly IRestResourceCommandFactory _commandFactoryMock = Mock.Of<IRestResourceCommandFactory>();
    private readonly Uri _resourceUri = EndpointsTestConstants.ApiDefaultUrl
        .Append(
            UrlSegmentsTestConstants.ApiRootSegment,
            UrlSegmentsTestConstants.InboundSegment,
            UrlSegmentsTestConstants.FoldersSegment)
        .Append(TestContext.CurrentContext.Random.NextLong());


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenCommandFactoryIsNull()
    {
        var act = () => new InboundFolderResource(null!, _resourceUri);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        var act = () => new InboundFolderResource(_commandFactoryMock, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ResourceUri_ShouldBeInitializedProperly()
    {
        var client = CreateResource();

        client.ResourceUri.Should().Be(_resourceUri);
    }


    private InboundFolderResource CreateResource() => new(_commandFactoryMock, _resourceUri);
}
