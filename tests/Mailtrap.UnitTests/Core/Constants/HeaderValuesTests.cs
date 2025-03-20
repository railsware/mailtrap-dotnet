namespace Mailtrap.UnitTests.Core.Constants;


[TestFixture]
internal sealed class HeaderValuesTests
{
    [Test]
    public void UserAgentName_ShouldContainCorrectValue()
    {
        HeaderValues.UserAgentName.Should().Be(HeaderValuesTestConstants.UserAgentName);
    }
}
