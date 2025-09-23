namespace Mailtrap.UnitTests.ContactEvents.Requests;


[TestFixture]
internal sealed class CreateContactsEventRequestTests
{
    [Test]
    public void CopyConstructor_ShouldUpdateFieldsCorrectly()
    {
        var originalRequest = new CreateContactsEventRequest("validName", new Dictionary<string, object?> { { "key1", "value1" } });
        var copiedRequest = originalRequest with
        {
            Name = "newValidName",
        };
        copiedRequest.Name.Should().Be("newValidName");
        copiedRequest.Params.Should().BeEquivalentTo(originalRequest.Params);
    }

    [TestCase(null, "name")]
    [TestCase("", "name")]
    public void Constructor_ShouldThrowArgumentNullException_WhenInputsInvalid(string? name, string expectedParam)
    {
        var act = () => new CreateContactsEventRequest(name!);
        act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be(expectedParam);
    }

    [Test]
    public void Constructor_ShouldInitializeFieldsCorrectly()
    {
        // Arrange
        var name = TestContext.CurrentContext.Random.GetString(5);
        Dictionary<string, object?> parameters = new()
        {
            { "param1", 123 },
            { "param2", "value" },
            { "param3", true },
            { "param4", null }
        };

        // Act
        var request = new CreateContactsEventRequest(name, parameters);

        // Assert
        request.Name.Should().Be(name);
        request.Params.Should().BeEquivalentTo(parameters);
    }

    [Test]
    public void Constructor_ShouldDefensivelyCopyParams()
    {
        // Arrange
        var src = new Dictionary<string, object?> { { "key", "value" } };
        var request = new CreateContactsEventRequest("name", src);

        // Act
        src["key"] = "changed";
        src["new"] = 123;

        // Assert
        request.Params.Should().BeEquivalentTo(new Dictionary<string, object?> { { "key", "value" } });
    }

    [Test]
    public void Validate_ShouldPass_WhenNameOnBoundaryLengths([Values(1, 255)] int length)
    {
        var testString = TestContext.CurrentContext.Random.GetString(length);
        var request = new CreateContactsEventRequest(testString);
        request.Validate().IsValid.Should().BeTrue();
    }

    [Test]
    public void Validate_ShouldPass_WhenParamsTagOnBoundaryLengths([Values(1, 255)] int length)
    {
        var testString = TestContext.CurrentContext.Random.GetString(length);
        var request = new CreateContactsEventRequest("validName", new Dictionary<string, object?> { { testString, "validValue" } });
        request.Validate().IsValid.Should().BeTrue();
    }

    [Test]
    public void Validate_ShouldFail_WhenProvidedNameLengthIsInvalid([Values(256)] int length)
    {
        // Arrange
        var name = TestContext.CurrentContext.Random.GetString(length);
        var request = new CreateContactsEventRequest(name);

        // Act
        var result = request.Validate();

        // Assert
        result.IsValid.Should().BeFalse();
    }

    [Test]
    public void Validate_ShouldFail_WhenProvidedParamTagLengthIsInvalid([Values(256)] int length)
    {
        // Arrange
        var paramTag = TestContext.CurrentContext.Random.GetString(length);
        var request = new CreateContactsEventRequest("validName", new Dictionary<string, object?> { { paramTag, "validValue" } });

        // Act
        var result = request.Validate();

        // Assert
        result.IsValid.Should().BeFalse();
    }
}
