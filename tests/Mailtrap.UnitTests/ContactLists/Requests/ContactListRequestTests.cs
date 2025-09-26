namespace Mailtrap.UnitTests.ContactLists.Requests;


[TestFixture]
internal sealed class ContactListRequestTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsNull()
    {
        var act = () => new ContactListRequest(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsEmpty()
    {
        var act = () => new ContactListRequest(string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldInitializeFieldsCorrectly()
    {
        // Arrange
        var name = TestContext.CurrentContext.Random.GetString(5);

        // Act
        var request = new ContactListRequest(name);

        // Assert
        request.Name.Should().Be(name);
    }

    [Test]
    public void Validate_ShouldFail_WhenProvidedNameLengthIsInvalid([Values(256)] int length)
    {
        // Arrange
        var name = TestContext.CurrentContext.Random.GetString(length);
        var request = new ContactListRequest(name);

        // Act
        var result = request.Validate();

        // Assert
        result.IsValid.Should().BeFalse();
    }
}
