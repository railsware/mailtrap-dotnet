namespace Mailtrap.UnitTests.ContactFields.Requests;


[TestFixture]
internal sealed class CreateContactsFieldRequestTests
{
    [Test]
    public void CopyConstructor_ShouldUpdateFieldsCorrectly()
    {
        var originalRequest = new CreateContactsFieldRequest("validName", "validMergeTag", ContactsFieldDataType.Boolean);
        var copiedRequest = originalRequest with
        {
            Name = "newValidName",
            MergeTag = "newValidMergeTag",
            DataType = ContactsFieldDataType.Number
        };
        copiedRequest.Name.Should().Be("newValidName");
        copiedRequest.MergeTag.Should().Be("newValidMergeTag");
        copiedRequest.DataType.Should().Be(ContactsFieldDataType.Number);
    }

    [TestCase(null, "validMergeTag", "name")]
    [TestCase("", "validMergeTag", "name")]
    [TestCase("validName", null, "mergeTag")]
    [TestCase("validName", "", "mergeTag")]
    public void Constructor_ShouldThrowArgumentNullException_WhenInputsInvalid(string? name, string? mergeTag, string expectedParam)
    {
        var act = () => new CreateContactsFieldRequest(name!, mergeTag!, ContactsFieldDataType.Text);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be(expectedParam);
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsNull()
    {
        var act = () => new CreateContactsFieldRequest(null!, "validMergeTag", ContactsFieldDataType.Text);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsEmpty()
    {
        var act = () => new CreateContactsFieldRequest(string.Empty, "validMergeTag", ContactsFieldDataType.Boolean);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenMergeTagIsNull()
    {
        var act = () => new CreateContactsFieldRequest("validName", null!, ContactsFieldDataType.Text);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenMergeTagIsEmpty()
    {
        var act = () => new CreateContactsFieldRequest("validName", string.Empty, ContactsFieldDataType.Number);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameAndMergeTagIsNull()
    {
        var act = () => new CreateContactsFieldRequest(null!, null!, ContactsFieldDataType.Boolean);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameAndMergeTagIsEmpty()
    {
        var act = () => new CreateContactsFieldRequest(string.Empty, string.Empty, ContactsFieldDataType.Boolean);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldInitializeFieldsCorrectly()
    {
        // Arrange
        var name = TestContext.CurrentContext.Random.GetString(5);
        var mergeTag = TestContext.CurrentContext.Random.GetString(5);
        var dataType = ContactsFieldDataType.Boolean;

        // Act
        var request = new CreateContactsFieldRequest(name, mergeTag, dataType);

        // Assert
        request.Name.Should().Be(name);
        request.MergeTag.Should().Be(mergeTag);
        request.DataType.Should().Be(dataType);
    }

    [Test]
    public void Validate_ShouldPass_OnBoundaryLengths([Values(1, 80)] int length)
    {
        var testString = TestContext.CurrentContext.Random.GetString(length);
        var request = new CreateContactsFieldRequest(testString, testString, ContactsFieldDataType.Boolean);
        request.Validate().IsValid.Should().BeTrue();
    }

    [Test]
    public void Validate_ShouldFail_WhenProvidedNameLengthIsInvalid([Values(81)] int length)
    {
        // Arrange
        var name = TestContext.CurrentContext.Random.GetString(length);
        var request = new CreateContactsFieldRequest(name, "validMergeTag", ContactsFieldDataType.Date);

        // Act
        var result = request.Validate();

        // Assert
        result.IsValid.Should().BeFalse();
    }

    [Test]
    public void Validate_ShouldFail_WhenProvidedMergeTagLengthIsInvalid([Values(81)] int length)
    {
        // Arrange
        var mergeTag = TestContext.CurrentContext.Random.GetString(length);
        var request = new CreateContactsFieldRequest("validName", mergeTag, ContactsFieldDataType.Boolean);

        // Act
        var result = request.Validate();

        // Assert
        result.IsValid.Should().BeFalse();
    }
}
