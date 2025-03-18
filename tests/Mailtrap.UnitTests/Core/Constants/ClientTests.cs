namespace Mailtrap.UnitTests.Core.Constants;


[TestFixture]
internal sealed class ClientTests
{
    [Test]
    public void Name_ShouldContainCorrectValue()
    {
        Client.Name.Should().Be(ClientTestConstants.Name);
    }
}
