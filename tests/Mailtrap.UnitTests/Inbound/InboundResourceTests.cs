namespace Mailtrap.UnitTests.Inbound;


[TestFixture]
internal sealed class InboundResourceTests
{
    private readonly IRestResourceCommandFactory _commandFactoryMock = Mock.Of<IRestResourceCommandFactory>();
    private readonly Uri _resourceUri = EndpointsTestConstants.ApiDefaultUrl
        .Append(
            UrlSegmentsTestConstants.ApiRootSegment,
            UrlSegmentsTestConstants.InboundSegment);


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenCommandFactoryIsNull()
    {
        var act = () => new InboundResource(null!, _resourceUri);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        var act = () => new InboundResource(_commandFactoryMock, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ResourceUri_ShouldBeInitializedProperly()
    {
        var client = CreateResource();

        client.ResourceUri.Should().Be(_resourceUri);
    }


    private InboundResource CreateResource() => new(_commandFactoryMock, _resourceUri);
}
