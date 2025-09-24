namespace Mailtrap.UnitTests.Contacts;


[TestFixture]
internal sealed class ContactCollectionResourceTests
{
    private readonly IRestResourceCommandFactory _commandFactoryMock = Mock.Of<IRestResourceCommandFactory>();
    private readonly Uri _resourceUri = EndpointsTestConstants.ApiDefaultUrl
        .Append(
            UrlSegmentsTestConstants.ApiRootSegment,
            UrlSegmentsTestConstants.AccountsSegment)
        .Append(TestContext.CurrentContext.Random.NextLong())
        .Append(UrlSegmentsTestConstants.ContactsSegment);


    #region Constructor

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenCommandFactoryIsNull()
    {
        // Act
        var act = () => new ContactCollectionResource(null!, _resourceUri);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenUriIsNull()
    {
        // Act
        var act = () => new ContactCollectionResource(_commandFactoryMock, null!);

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

    #region Imports

    [Test]
    public void Imports_ShouldReturnContactsImportCollectionResource()
    {
        // Arrange
        var client = CreateResource();

        // Act
        var result = client.Imports();

        // Assert
        ResourceValidator.Validate<IContactsImportCollectionResource, ContactsImportCollectionResource>(
            result, client.ResourceUri.Append(UrlSegmentsTestConstants.ImportsSegment));
    }

    [Test]
    public void Import_ShouldReturnContactsImportResource()
    {
        // Arrange
        var client = CreateResource();
        var importId = TestContext.CurrentContext.Random.NextLong();

        // Act
        var result = client.Import(importId);

        // Assert
        ResourceValidator.Validate<IContactsImportResource, ContactsImportResource>(
            result, client.ResourceUri.Append(UrlSegmentsTestConstants.ImportsSegment).Append(importId));
    }

    [Test]
    public void Import_ShouldThrowArgumentOutOfRangeException_WhenIdIsEqualOrLessThanZero([Values(0, -1)] long importId)
    {
        // Arrange
        var client = CreateResource();

        // Act
        var act = () => client.Import(importId);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    #endregion

    #region Lists

    [Test]
    public void Lists_ShouldReturnContactsListCollectionResource()
    {
        // Arrange
        var client = CreateResource();

        // Act
        var result = client.Lists();

        // Assert
        ResourceValidator.Validate<IContactsListCollectionResource, ContactsListCollectionResource>(
            result, client.ResourceUri.Append(UrlSegmentsTestConstants.ListsSegment));
    }

    [Test]
    public void List_ShouldReturnContactsListResource()
    {
        // Arrange
        var client = CreateResource();
        var listId = TestContext.CurrentContext.Random.NextLong();

        // Act
        var result = client.List(listId);

        // Assert
        ResourceValidator.Validate<IContactsListResource, ContactsListResource>(
            result, client.ResourceUri.Append(UrlSegmentsTestConstants.ListsSegment).Append(listId));
    }

    [Test]
    public void List_ShouldThrowArgumentOutOfRangeException_WhenIdIsEqualOrLessThanZero([Values(0, -1)] long listId)
    {
        // Arrange
        var client = CreateResource();

        // Act
        var act = () => client.List(listId);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    #endregion

    #region Fields

    [Test]
    public void Fields_ShouldReturnContactsFieldCollectionResource()
    {
        // Arrange
        var client = CreateResource();

        // Act
        var result = client.Fields();

        // Assert
        ResourceValidator.Validate<IContactsFieldCollectionResource, ContactsFieldCollectionResource>(
            result, client.ResourceUri.Append(UrlSegmentsTestConstants.FieldsSegment));
    }

    [Test]
    public void Field_ShouldReturnContactsFieldResource()
    {
        // Arrange
        var client = CreateResource();
        var fieldId = TestContext.CurrentContext.Random.NextLong();

        // Act
        var result = client.Field(fieldId);

        // Assert
        ResourceValidator.Validate<IContactsFieldResource, ContactsFieldResource>(
            result, client.ResourceUri.Append(UrlSegmentsTestConstants.FieldsSegment).Append(fieldId));
    }

    [Test]
    public void Field_ShouldThrowArgumentOutOfRangeException_WhenIdIsEqualOrLessThanZero([Values(0, -1)] long fieldId)
    {
        // Arrange
        var client = CreateResource();

        // Act
        var act = () => client.Field(fieldId);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    #endregion

    #region Events

    [Test]
    public void Events_ShouldReturnContactsEventCollectionResource()
    {
        // Arrange
        var client = CreateResource();
        var contactId = TestContext.CurrentContext.Random.NextGuid().ToString();

        // Act
        var result = client.Events(contactId);

        // Assert
        ResourceValidator.Validate<IContactsEventCollectionResource, ContactsEventCollectionResource>(
            result, client.ResourceUri.Append(contactId).Append(UrlSegmentsTestConstants.EventsSegment));
    }

    #endregion

    private ContactCollectionResource CreateResource() => new(_commandFactoryMock, _resourceUri);
}
