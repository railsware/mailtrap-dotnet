namespace Mailtrap.UnitTests.EmailTemplates.Requests;


[TestFixture]
internal sealed class EmailTemplateRequestTests
{
    [Test]
    public void BaseEmailTemplateCopyConstructor_ShouldUpdateFieldsCorrectly()
    {
        // Adjusted to use a parameterless constructor or an available constructor
        var emailTemplate = new EmailTemplate
        {
            Id = TestContext.CurrentContext.Random.NextLong(),
            Name = "validName",
            Category = "validCategory",
            Subject = "validSubject",
            BodyText = "validBodyText",
            BodyHtml = "validBodyHtml",
            Uuid = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var newDateTime = DateTime.UtcNow.AddHours(1);
        var newUuid = Guid.NewGuid().ToString();

        var copiedTemplate = emailTemplate with
        {
            Name = "newValidName",
            Category = "newValidCategory",
            Subject = "newValidSubject",
            BodyText = "newValidBodyText",
            BodyHtml = "newValidBodyHtml",
            UpdatedAt = newDateTime,
            CreatedAt = newDateTime,
            Uuid = newUuid
        };
        copiedTemplate.Name.Should().Be("newValidName");
        copiedTemplate.Category.Should().Be("newValidCategory");
        copiedTemplate.Subject.Should().Be("newValidSubject");
        copiedTemplate.BodyText.Should().Be("newValidBodyText");
        copiedTemplate.BodyHtml.Should().Be("newValidBodyHtml");
        copiedTemplate.CreatedAt.Should().Be(newDateTime);
        copiedTemplate.UpdatedAt.Should().Be(newDateTime);
        copiedTemplate.Uuid.Should().Be(newUuid);
    }

    [Test]
    public void BaseRequestCopyConstructor_ShouldUpdateFieldsCorrectly()
    {
        var originalRequest = new EmailTemplateRequest("validName", "validCategory", "validSubject")
        {
            BodyText = "validBodyText",
            BodyHtml = "validBodyHtml"
        };
        var copiedRequest = originalRequest with
        {
            Name = "newValidName",
            Category = "newValidCategory",
            Subject = "newValidSubject",
            BodyText = "newValidBodyText",
            BodyHtml = "newValidBodyHtml"
        };
        copiedRequest.Name.Should().Be("newValidName");
        copiedRequest.Category.Should().Be("newValidCategory");
        copiedRequest.Subject.Should().Be("newValidSubject");
        copiedRequest.BodyText.Should().Be("newValidBodyText");
        copiedRequest.BodyHtml.Should().Be("newValidBodyHtml");
    }

    [Test]
    public void CreateRequestCopyConstructor_ShouldUpdateFieldsCorrectly()
    {
        var originalRequest = new CreateEmailTemplateRequest("validName", "validCategory", "validSubject")
        {
            BodyText = "validBodyText",
            BodyHtml = "validBodyHtml"
        };
        var copiedRequest = originalRequest with
        {
            Name = "newValidName",
            Category = "newValidCategory",
            Subject = "newValidSubject",
            BodyText = "newValidBodyText",
            BodyHtml = "newValidBodyHtml"
        };
        copiedRequest.Name.Should().Be("newValidName");
        copiedRequest.Category.Should().Be("newValidCategory");
        copiedRequest.Subject.Should().Be("newValidSubject");
        copiedRequest.BodyText.Should().Be("newValidBodyText");
        copiedRequest.BodyHtml.Should().Be("newValidBodyHtml");
    }

    [Test]
    public void UpdateRequestCopyConstructor_ShouldUpdateFieldsCorrectly()
    {
        var originalRequest = new UpdateEmailTemplateRequest("validName", "validCategory", "validSubject")
        {
            BodyText = "validBodyText",
            BodyHtml = "validBodyHtml"
        };
        var copiedRequest = originalRequest with
        {
            Name = "newValidName",
            Category = "newValidCategory",
            Subject = "newValidSubject",
            BodyText = "newValidBodyText",
            BodyHtml = "newValidBodyHtml"
        };
        copiedRequest.Name.Should().Be("newValidName");
        copiedRequest.Category.Should().Be("newValidCategory");
        copiedRequest.Subject.Should().Be("newValidSubject");
        copiedRequest.BodyText.Should().Be("newValidBodyText");
        copiedRequest.BodyHtml.Should().Be("newValidBodyHtml");
    }

    [TestCase(null, "validCategory", "validSubject", "name")]
    [TestCase("", "validCategory", "validSubject", "name")]
    [TestCase("validName", null, "validSubject", "category")]
    [TestCase("validName", "", "validSubject", "category")]
    [TestCase("validName", "validCategory", null, "subject")]
    [TestCase("validName", "validCategory", "", "subject")]
    public void Constructor_ShouldThrowArgumentNullException_WhenRequiredInputsInvalid(string? name, string? category, string? subject, string paramName)
    {
        // Act
        var act = () => new EmailTemplateRequest(name!, category!, subject!);

        // Assert
        act.Should().Throw<ArgumentNullException>().WithParameterName(paramName);
    }

    [Test]
    public void Constructor_ShouldInitializeAllFieldsCorrectly()
    {
        // Arrange
        var name = TestContext.CurrentContext.Random.GetString(5);
        var category = TestContext.CurrentContext.Random.GetString(5);
        var subject = TestContext.CurrentContext.Random.GetString(5);
        var bodyText = TestContext.CurrentContext.Random.GetString(5);
        var bodyHtml = TestContext.CurrentContext.Random.GetString(5);

        // Act
        var request = new EmailTemplateRequest(name, category, subject)
        { BodyText = bodyText, BodyHtml = bodyHtml };

        // Assert
        request.Name.Should().Be(name);
        request.Category.Should().Be(category);
        request.Subject.Should().Be(subject);
        request.BodyText.Should().Be(bodyText);
        request.BodyHtml.Should().Be(bodyHtml);
    }

    [TestCase(256, 5, 5)]
    [TestCase(5, 256, 5)]
    [TestCase(5, 5, 256)]
    [TestCase(256, 256, 5)]
    [TestCase(5, 256, 256)]
    [TestCase(256, 5, 256)]
    [TestCase(256, 256, 256)]
    public void Validate_ShouldFail_WhenProvidedRequiredInputsLengthIsInvalid(int nameLength, int categoryLength, int subjectLength)
    {
        // Arrange
        var name = TestContext.CurrentContext.Random.GetString(nameLength);
        var category = TestContext.CurrentContext.Random.GetString(categoryLength);
        var subject = TestContext.CurrentContext.Random.GetString(subjectLength);
        var request = new EmailTemplateRequest(name, category, subject);

        // Act
        var result = request.Validate();

        // Assert
        result.IsValid.Should().BeFalse();
    }

    [TestCase(255, 1, 1)]
    [TestCase(1, 255, 1)]
    [TestCase(1, 1, 255)]
    [TestCase(255, 255, 1)]
    [TestCase(1, 255, 255)]
    [TestCase(255, 1, 255)]
    [TestCase(255, 255, 255)]
    public void Validate_ShouldPass_WhenProvidedRequiredInputsLengthOnBounds(int nameLength, int categoryLength, int subjectLength)
    {
        // Arrange
        var name = TestContext.CurrentContext.Random.GetString(nameLength);
        var category = TestContext.CurrentContext.Random.GetString(categoryLength);
        var subject = TestContext.CurrentContext.Random.GetString(subjectLength);
        var request = new EmailTemplateRequest(name, category, subject);

        // Act
        var result = request.Validate();

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [TestCase(10_000_001, 5)]
    [TestCase(5, 10_000_001)]
    [TestCase(10_000_001, 10_000_001)]
    public void Validate_ShouldFail_WhenProvidedBodyInputsLengthIsInvalid(int bodyTextLength, int bodyHtmlLength)
    {
        // Arrange
        var bodyText = TestContext.CurrentContext.Random.GetString(bodyTextLength);
        var bodyHtml = TestContext.CurrentContext.Random.GetString(bodyHtmlLength);
        var request = new EmailTemplateRequest("name", "category", "subject")
        {
            BodyText = bodyText,
            BodyHtml = bodyHtml
        };

        // Act
        var result = request.Validate();

        // Assert
        result.IsValid.Should().BeFalse();
    }

    [TestCase(10_000_000, 0)]
    [TestCase(0, 10_000_000)]
    [TestCase(10_000_000, 10_000_000)]
    [TestCase(0, 0)]
    public void Validate_ShouldPass_WhenProvidedBodyInputsLengthIsOnBounds(int bodyTextLength, int bodyHtmlLength)
    {
        // Arrange
        var bodyText = TestContext.CurrentContext.Random.GetString(bodyTextLength);
        var bodyHtml = TestContext.CurrentContext.Random.GetString(bodyHtmlLength);
        var request = new EmailTemplateRequest("name", "category", "subject")
        {
            BodyText = bodyText,
            BodyHtml = bodyHtml
        };

        // Act
        var result = request.Validate();

        // Assert
        result.IsValid.Should().BeTrue();
    }
}
