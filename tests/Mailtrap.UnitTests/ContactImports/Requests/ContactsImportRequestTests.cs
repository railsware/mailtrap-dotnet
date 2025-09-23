namespace Mailtrap.UnitTests.ContactImports.Requests;


[TestFixture]
internal sealed class ContactsImportRequestTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenProvidedCollectionIsNull()
    {
        var act = () => new ContactsImportRequest(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenProvidedCollectionIsEmpty()
    {
        var act = () => new ContactsImportRequest(Array.Empty<ContactImportRequest>());

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldInitializeFieldsCorrectly()
    {
        // Arrange
        var contacts = new List<ContactImportRequest> { RandomContactImportRequest() };

        // Act
        var request = new ContactsImportRequest(contacts);

        // Assert
        request.Contacts.Should().BeEquivalentTo(contacts);
    }


    [Test]
    public void Validate_ShouldFail_WhenProvidedCollectionSizeIsInvalid([Values(0, 50001)] int size)
    {
        // Arrange
        var contacts = new List<ContactImportRequest>(size);
        for (var i = 0; i < size; i++)
        {
            contacts.Add(RandomContactImportRequest());
        }
        var request = size == 0 ? new ContactsImportRequest() : new ContactsImportRequest(contacts);

        // Act
        var result = request.Validate();

        // Assert
        result.IsValid.Should().BeFalse();
    }

    [Test]
    public void Validate_ShouldFail_WhenProvidedCollectionContainsNull()
    {
        // Arrange
        var contacts = new List<ContactImportRequest>()
        {
            RandomContactImportRequest(),
            null!,
            RandomContactImportRequest()
        };

        var request = new ContactsImportRequest(contacts);

        // Act
        var result = request.Validate();

        // Assert
        result.IsValid.Should().BeFalse();
    }

    [Test]
    public void Validate_ShouldFail_WhenProvidedCollectionContainsInvalidRecord([Values(1, 101)] int emailLength)
    {
        // Arrange
        var contacts = new List<ContactImportRequest>()
        {
            RandomContactImportRequest(),
            new(TestContext.CurrentContext.Random.GetString(emailLength)), // Invalid email length
            RandomContactImportRequest()
        };

        var request = new ContactsImportRequest(contacts);

        // Act
        var result = request.Validate();

        // Assert
        result.IsValid.Should().BeFalse();
    }

    private static ContactImportRequest RandomContactImportRequest()
    {
        var email = TestContext.CurrentContext.Random.GetString(5)
                    + "@"
                    + TestContext.CurrentContext.Random.GetString(5)
                    + ".com";
        return new ContactImportRequest(email);
    }
}
