namespace Mailtrap.UnitTests.Inbound;


[TestFixture]
internal sealed class InboundMessageResourceTests
{
    private readonly IRestResourceCommandFactory _commandFactoryMock = Mock.Of<IRestResourceCommandFactory>();
    private readonly Uri _resourceUri = EndpointsTestConstants.ApiDefaultUrl
        .Append(
            UrlSegmentsTestConstants.ApiRootSegment,
            UrlSegmentsTestConstants.InboundSegment,
            UrlSegmentsTestConstants.InboxesSegment)
        .Append(TestContext.CurrentContext.Random.NextLong())
        .Append(
            UrlSegmentsTestConstants.MessagesSegment,
            "1700000000000123");


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenCommandFactoryIsNull()
    {
        var act = () => new InboundMessageResource(null!, _resourceUri);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        var act = () => new InboundMessageResource(_commandFactoryMock, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ResourceUri_ShouldBeInitializedProperly()
    {
        var client = CreateResource();

        client.ResourceUri.Should().Be(_resourceUri);
    }


    private InboundMessageResource CreateResource() => new(_commandFactoryMock, _resourceUri);
}
