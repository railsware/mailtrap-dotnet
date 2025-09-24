namespace Mailtrap.UnitTests.ContactFields.Requests;


[TestFixture]
internal sealed class CreateContactFieldRequestTests
{
    [Test]
    public void CopyConstructor_ShouldUpdateFieldsCorrectly()
    {
        var originalRequest = new CreateContactFieldRequest("validName", "validMergeTag", ContactFieldDataType.Boolean);
        var copiedRequest = originalRequest with
        {
            Name = "newValidName",
            MergeTag = "newValidMergeTag",
            DataType = ContactFieldDataType.Number
        };
        copiedRequest.Name.Should().Be("newValidName");
        copiedRequest.MergeTag.Should().Be("newValidMergeTag");
        copiedRequest.DataType.Should().Be(ContactFieldDataType.Number);
    }

    [TestCase(null, "validMergeTag", "name")]
    [TestCase("", "validMergeTag", "name")]
    [TestCase("validName", null, "mergeTag")]
    [TestCase("validName", "", "mergeTag")]
    public void Constructor_ShouldThrowArgumentNullException_WhenInputsInvalid(string? name, string? mergeTag, string expectedParam)
    {
        var act = () => new CreateContactFieldRequest(name!, mergeTag!, ContactFieldDataType.Text);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be(expectedParam);
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsNull()
    {
        var act = () => new CreateContactFieldRequest(null!, "validMergeTag", ContactFieldDataType.Text);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsEmpty()
    {
        var act = () => new CreateContactFieldRequest(string.Empty, "validMergeTag", ContactFieldDataType.Boolean);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenMergeTagIsNull()
    {
        var act = () => new CreateContactFieldRequest("validName", null!, ContactFieldDataType.Text);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenMergeTagIsEmpty()
    {
        var act = () => new CreateContactFieldRequest("validName", string.Empty, ContactFieldDataType.Number);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameAndMergeTagIsNull()
    {
        var act = () => new CreateContactFieldRequest(null!, null!, ContactFieldDataType.Boolean);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameAndMergeTagIsEmpty()
    {
        var act = () => new CreateContactFieldRequest(string.Empty, string.Empty, ContactFieldDataType.Boolean);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldInitializeFieldsCorrectly()
    {
        // Arrange
        var name = TestContext.CurrentContext.Random.GetString(5);
        var mergeTag = TestContext.CurrentContext.Random.GetString(5);
        var dataType = ContactFieldDataType.Boolean;

        // Act
        var request = new CreateContactFieldRequest(name, mergeTag, dataType);

        // Assert
        request.Name.Should().Be(name);
        request.MergeTag.Should().Be(mergeTag);
        request.DataType.Should().Be(dataType);
    }

    [Test]
    public void Validate_ShouldPass_OnBoundaryLengths([Values(1, 80)] int length)
    {
        var testString = TestContext.CurrentContext.Random.GetString(length);
        var request = new CreateContactFieldRequest(testString, testString, ContactFieldDataType.Boolean);
        request.Validate().IsValid.Should().BeTrue();
    }

    [Test]
    public void Validate_ShouldFail_WhenProvidedNameLengthIsInvalid([Values(81)] int length)
    {
        // Arrange
        var name = TestContext.CurrentContext.Random.GetString(length);
        var request = new CreateContactFieldRequest(name, "validMergeTag", ContactFieldDataType.Date);

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
        var request = new CreateContactFieldRequest("validName", mergeTag, ContactFieldDataType.Boolean);

        // Act
        var result = request.Validate();

        // Assert
        result.IsValid.Should().BeFalse();
    }
}
