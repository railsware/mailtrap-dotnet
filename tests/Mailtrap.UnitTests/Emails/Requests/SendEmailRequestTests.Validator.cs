namespace Mailtrap.UnitTests.Emails.Requests;


[TestFixture]
internal sealed class SendEmailRequestTests_Validator
{
    private string _validEmail { get; } = "someone@domain.com";
    private string _invalidEmail { get; } = "someone";
    private string _templateId { get; } = "ID";



    #region Request

    [Test]
    public void Validation_Should_Fail_WhenNoRecipientsPresent()
    {
        var request = SendEmailRequest.Create();

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor("Recipients");
    }

    [Test]
    public void Validation_Should_Pass_WhenOnlyToRecipientsPresent()
    {
        var request = SendEmailRequest
            .Create()
            .To(_validEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r);
    }

    [Test]
    public void Validation_Should_Pass_WhenOnlyCcRecipientsPresent()
    {
        var request = SendEmailRequest
            .Create()
            .Cc(_validEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r);
    }

    [Test]
    public void Validation_Should_Pass_WhenOnlyBccRecipientsPresent()
    {
        var request = SendEmailRequest
            .Create()
            .Bcc(_validEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r);
    }

    #endregion



    #region From

    [Test]
    public void Validation_Should_Fail_WhenSenderEmailIsInvalid()
    {
        var request = SendEmailRequest
            .Create()
            .From(_invalidEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.From!.Email);
    }

    [Test]
    public void Validation_Should_Pass_WhenSenderEmailIsValid()
    {
        var request = SendEmailRequest
            .Create()
            .From(_validEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.From);
        result.ShouldNotHaveValidationErrorFor(r => r.From!.Email);
    }

    #endregion



    #region ReplyTo

    [Test]
    public void Validation_Should_Pass_WhenReplyToIsNull()
    {
        var request = SendEmailRequest.Create();

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.ReplyTo);
        result.ShouldNotHaveValidationErrorFor(r => r.ReplyTo!.Email);
    }

    [Test]
    public void Validation_Should_Fail_WhenReplyToEmailIsInvalid()
    {
        var request = SendEmailRequest
            .Create()
            .ReplyTo(_invalidEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.ReplyTo!.Email);
    }

    [Test]
    public void Validation_Should_Pass_WhenReplyToEmailIsValid()
    {
        var request = SendEmailRequest
            .Create()
            .ReplyTo(_validEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.ReplyTo);
        result.ShouldNotHaveValidationErrorFor(r => r.ReplyTo!.Email);
    }

    #endregion



    #region To

    [Test]
    public void Validation_Should_Fail_WhenToLengthExceedsLimit([Values(1001)] int count)
    {
        var request = SendEmailRequest.Create();
        request.To = Enumerable.Repeat(new EmailAddress(_validEmail), count).ToList();

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.To);
    }

    [Test]
    public void Validation_Should_Pass_WhenToLengthWithinLimit([Values(1, 500, 1000)] int count)
    {
        var request = SendEmailRequest.Create();
        request.To = Enumerable.Repeat(new EmailAddress(_validEmail), count).ToList();

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.To);
    }

    [Test]
    public void Validation_Should_Fail_WhenAtLEastOneToEmailIsInvalid()
    {
        var request = SendEmailRequest
            .Create()
            .To(_validEmail)
            .To(_invalidEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        // Unfortunately we can't use expressions for collection properties,
        // we can't use nameof with indexer either,
        // thus hardcoding the property name.
        result.ShouldHaveValidationErrorFor($"{nameof(SendEmailRequest.To)}[1].{nameof(EmailAddress.Email)}");
    }

    [Test]
    public void Validation_Should_Pass_WhenAllToEmailsAreValid()
    {
        var request = SendEmailRequest
            .Create()
            .To(_validEmail)
            .To("other@domain.com");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.To);
        result.ShouldNotHaveValidationErrorFor($"{nameof(SendEmailRequest.To)}[0].{nameof(EmailAddress.Email)}");
        result.ShouldNotHaveValidationErrorFor($"{nameof(SendEmailRequest.To)}[1].{nameof(EmailAddress.Email)}");
    }

    #endregion



    #region Cc

    [Test]
    public void Validation_Should_Fail_WhenCcLengthExceedsLimit()
    {
        var request = SendEmailRequest.Create();

        for (var i = 1; i <= 1001; i++)
        {
            request.Cc($"recipient{i}.domain.com");
        }

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.Cc);
    }

    [Test]
    public void Validation_Should_Pass_WhenCcLengthWithinLimit()
    {
        var request = SendEmailRequest.Create();

        for (var i = 1; i <= 1000; i++)
        {
            request.Cc($"recipient{i}.domain.com");
        }

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.Cc);
    }

    [Test]
    public void Validation_Should_Fail_WhenAtLEastOneCcEmailIsInvalid()
    {
        var request = SendEmailRequest
            .Create()
            .Cc(_validEmail)
            .Cc(_invalidEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor($"{nameof(SendEmailRequest.Cc)}[1].{nameof(EmailAddress.Email)}");
    }

    [Test]
    public void Validation_Should_Pass_WhenAllCcEmailsAreValid()
    {
        var request = SendEmailRequest
            .Create()
            .Cc(_validEmail)
            .Cc("other@domain.com");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.Cc);
        result.ShouldNotHaveValidationErrorFor($"{nameof(SendEmailRequest.Cc)}[0].{nameof(EmailAddress.Email)}");
        result.ShouldNotHaveValidationErrorFor($"{nameof(SendEmailRequest.Cc)}[1].{nameof(EmailAddress.Email)}");
    }

    #endregion



    #region Bcc

    [Test]
    public void Validation_Should_Fail_WhenBccLengthExceedsLimit()
    {
        var request = SendEmailRequest.Create();

        for (var i = 1; i <= 1001; i++)
        {
            request.Bcc($"recipient{i}.domain.com");
        }

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.Bcc);
    }

    [Test]
    public void Validation_Should_Pass_WhenBccLengthWithinLimit()
    {
        var request = SendEmailRequest.Create();

        for (var i = 1; i <= 1000; i++)
        {
            request.Bcc($"recipient{i}.domain.com");
        }

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.Bcc);
    }

    [Test]
    public void Validation_Should_Fail_WhenAtLEastOneBccEmailIsInvalid()
    {
        var request = SendEmailRequest
            .Create()
            .Bcc(_validEmail)
            .Bcc(_invalidEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor($"{nameof(SendEmailRequest.Bcc)}[1].{nameof(EmailAddress.Email)}");
    }

    [Test]
    public void Validation_Should_Pass_WhenAllBccEmailsAreValid()
    {
        var request = SendEmailRequest
            .Create()
            .Bcc(_validEmail)
            .Bcc("other@domain.com");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.Bcc);
        result.ShouldNotHaveValidationErrorFor($"{nameof(SendEmailRequest.Bcc)}[0].{nameof(EmailAddress.Email)}");
        result.ShouldNotHaveValidationErrorFor($"{nameof(SendEmailRequest.Bcc)}[1].{nameof(EmailAddress.Email)}");
    }

    #endregion



    #region Attachments

    [Test]
    public void Validation_Should_Fail_WhenAtLEastOneAttachmentIsInvalid()
    {
        var request = SendEmailRequest
            .Create()
            .Attach("Any content", "file1.txt")
            .Attach("Any content", "file2.txt", mimeType: string.Empty);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor($"{nameof(SendEmailRequest.Attachments)}[1].{nameof(Attachment.MimeType)}");
    }

    [Test]
    public void Validation_Should_Pass_WhenAllAttachmentsAreValid()
    {
        var request = SendEmailRequest
            .Create()
            .Attach("Any content", "file1.txt")
            .Attach("Any content", "file2.txt");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.Attachments);
        result.ShouldNotHaveValidationErrorFor($"{nameof(SendEmailRequest.Attachments)}[0].{nameof(Attachment.MimeType)}");
        result.ShouldNotHaveValidationErrorFor($"{nameof(SendEmailRequest.Attachments)}[1].{nameof(Attachment.MimeType)}");
    }

    #endregion



    #region Templated

    [Test]
    public void Validation_Should_Fail_WhenTemplateIdIsSetAndSubjectProvided()
    {
        var request = SendEmailRequest
            .Create()
            .Template(_templateId)
            .Subject("Subject");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.Subject);
    }

    [Test]
    public void Validation_Should_Fail_WhenTemplateIdIsSetAndTextProvided()
    {
        var request = SendEmailRequest
            .Create()
            .Template(_templateId)
            .Text("Content");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.TextBody);
    }

    [Test]
    public void Validation_Should_Fail_WhenTemplateIdIsSetAndHtmlProvided()
    {
        var request = SendEmailRequest
            .Create()
            .Template(_templateId)
            .Html("<h1>Header</h1>");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.HtmlBody);
    }

    [Test]
    public void Validation_Should_Pass_WhenTemplateIdIsSetAndNoForbiddenPropertiesAreSet()
    {
        var request = SendEmailRequest
            .Create()
            .From(_validEmail)
            .To(_validEmail)
            .Template(_templateId);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.IsValid.Should().BeTrue();
    }

    #endregion



    #region Subject

    [Test]
    public void Validation_Should_Fail_WhenSubjectIsNull()
    {
        var request = SendEmailRequest.Create();

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.Subject);
    }

    [Test]
    public void Validation_Should_Pass_WhenSubjectProvided()
    {
        var request = SendEmailRequest.Create()
            .Subject("Subject");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.Subject);
    }

    #endregion



    #region Category

    [Test]
    public void Validation_Should_Fail_WhenCategoryExceedsAllowedLength()
    {
        var request = SendEmailRequest
            .Create()
            .Category(TestContext.CurrentContext.Random.GetString(256));

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.Category);
    }

    [Test]
    public void Validation_Should_Pass_WhenCategoryFitsAllowedLength()
    {
        var request = SendEmailRequest
            .Create()
            .Category(TestContext.CurrentContext.Random.GetString(255));

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.Category);
    }

    #endregion



    #region Body

    [Test]
    public void Validation_Should_Fail_WhenBothHtmlAndTextBodyAreNull()
    {
        var request = SendEmailRequest.Create();

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.TextBody);
        result.ShouldHaveValidationErrorFor(r => r.HtmlBody);
    }

    [Test]
    public void Validation_Should_Fail_WhenBothHtmlAndTextBodyAreEmpty()
    {
        var request = SendEmailRequest
            .Create()
            .Text(string.Empty)
            .Html(string.Empty);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.TextBody);
        result.ShouldHaveValidationErrorFor(r => r.HtmlBody);
    }

    [Test]
    public void Validation_Should_Pass_WhenTextBodyIsNotEmpty()
    {
        var request = SendEmailRequest
            .Create()
            .Text("Text");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.TextBody);
        result.ShouldNotHaveValidationErrorFor(r => r.HtmlBody);
    }

    [Test]
    public void Validation_Should_Pass_WhenHtmlBodyIsNotEmpty()
    {
        var request = SendEmailRequest
            .Create()
            .Html("<h1>Html</h1>");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.TextBody);
        result.ShouldNotHaveValidationErrorFor(r => r.HtmlBody);
    }

    [Test]
    public void Validation_Should_Pass_WhenBothHtmlAndTextBodyAreNotEmpty()
    {
        var request = SendEmailRequest
            .Create()
            .Text("Text")
            .Html("<h1>Html</h1>");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.TextBody);
        result.ShouldNotHaveValidationErrorFor(r => r.HtmlBody);
    }

    #endregion
}
