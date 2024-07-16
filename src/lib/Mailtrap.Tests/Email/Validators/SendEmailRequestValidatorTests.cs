// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestValidatorTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Validators;


[TestFixture]
internal sealed class SendEmailRequestValidatorTests
{
    private string _validEmail { get; } = "someone@domean.com";
    private string _invalidEmail { get; } = "someone";
    private string _templateId { get; } = "ID";



    #region Request

    [Test]
    public void Validation_ShouldFail_WhenNoRecipientsPresent()
    {
        var request = SendEmailRequestBuilder.Email();

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor("Recipients");
    }

    [Test]
    public void Validation_ShouldNotFail_WhenOnlyToRecipientsPresent()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .To(_validEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenOnlyCcRecipientsPresent()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Cc(_validEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenOnlyBccRecipientsPresent()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Bcc(_validEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r);
    }

    #endregion



    #region From

    [Test]
    public void Validation_ShouldFail_WhenSenderEmailIsInvalid()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .From(_invalidEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.From!.Email);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenSenderEmailIsValid()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .From(_validEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.From);
        result.ShouldNotHaveValidationErrorFor(r => r.From!.Email);
    }

    #endregion



    #region To

    [Test]
    public void Validation_ShouldFail_WhenToLengthExceedsLimit()
    {
        var request = SendEmailRequestBuilder.Email();

        for (var i = 1; i <= 1001; i++)
        {
            request.To($"recipient{i}.domain.com");
        }

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.To);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenToLengthWithinLimit()
    {
        var request = SendEmailRequestBuilder.Email();

        for (var i = 1; i <= 1000; i++)
        {
            request.To($"recipient{i}.domain.com");
        }

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.To);
    }

    [Test]
    public void Validation_ShouldFail_WhenAtLEastOneToEmailIsInvalid()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .To(_validEmail)
            .To(_invalidEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        // Unfortunately we can't use expressions for collection properties,
        // we can't use nameof with indexer either,
        // thus hardcoding the property name.
        result.ShouldHaveValidationErrorFor($"{nameof(SendEmailRequest.To)}[1].{nameof(EmailAddress.Email)}");
    }

    [Test]
    public void Validation_ShouldNotFail_WhenAllToEmailsAreValid()
    {
        var request = SendEmailRequestBuilder
            .Email()
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
    public void Validation_ShouldFail_WhenCcLengthExceedsLimit()
    {
        var request = SendEmailRequestBuilder.Email();

        for (var i = 1; i <= 1001; i++)
        {
            request.Cc($"recipient{i}.domain.com");
        }

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.Cc);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenCcLengthWithinLimit()
    {
        var request = SendEmailRequestBuilder.Email();

        for (var i = 1; i <= 1000; i++)
        {
            request.Cc($"recipient{i}.domain.com");
        }

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.Cc);
    }

    [Test]
    public void Validation_ShouldFail_WhenAtLEastOneCcEmailIsInvalid()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Cc(_validEmail)
            .Cc(_invalidEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor($"{nameof(SendEmailRequest.Cc)}[1].{nameof(EmailAddress.Email)}");
    }

    [Test]
    public void Validation_ShouldNotFail_WhenAllCcEmailsAreValid()
    {
        var request = SendEmailRequestBuilder
            .Email()
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
    public void Validation_ShouldFail_WhenBccLengthExceedsLimit()
    {
        var request = SendEmailRequestBuilder.Email();

        for (var i = 1; i <= 1001; i++)
        {
            request.Bcc($"recipient{i}.domain.com");
        }

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.Bcc);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenBccLengthWithinLimit()
    {
        var request = SendEmailRequestBuilder.Email();

        for (var i = 1; i <= 1000; i++)
        {
            request.Bcc($"recipient{i}.domain.com");
        }

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.Bcc);
    }

    [Test]
    public void Validation_ShouldFail_WhenAtLEastOneBccEmailIsInvalid()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Bcc(_validEmail)
            .Bcc(_invalidEmail);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor($"{nameof(SendEmailRequest.Bcc)}[1].{nameof(EmailAddress.Email)}");
    }

    [Test]
    public void Validation_ShouldNotFail_WhenAllBccEmailsAreValid()
    {
        var request = SendEmailRequestBuilder
            .Email()
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
    public void Validation_ShouldFail_WhenAtLEastOneAttachmentIsInvalid()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Attach("Any content", "file1.txt")
            .Attach("Any content", "file2.txt", mimeType: string.Empty);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor($"{nameof(SendEmailRequest.Attachments)}[1].{nameof(Attachment.MimeType)}");
    }

    [Test]
    public void Validation_ShouldNotFail_WhenAllAttachmentsAreValid()
    {
        var request = SendEmailRequestBuilder
            .Email()
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
    public void Validation_ShouldFail_WhenTemplateIdIsSetAndSubjectProvided()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Template(_templateId)
            .Subject("Subject");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.Subject);
    }

    [Test]
    public void Validation_ShouldFail_WhenTemplateIdIsSetAndTextProvided()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Template(_templateId)
            .Text("Content");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.TextBody);
    }

    [Test]
    public void Validation_ShouldFail_WhenTemplateIdIsSetAndHtmlProvided()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Template(_templateId)
            .Html("<h1>Header</h1>");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.HtmlBody);
    }

    [Test]
    public void Validation_ShouldFail_WhenTemplateIdIsSetAndCategoryProvided()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Template(_templateId)
            .Category(string.Empty);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.Category);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenTemplateIdIsSetAndNoForbiddenPropertiesAreSet()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .From(_validEmail)
            .To(_validEmail)
            .Template(_templateId);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.IsValid.Should().BeTrue();
    }

    #endregion



    #region Subject

    [Test]
    public void Validation_ShouldFail_WhenSubjectIsNull()
    {
        var request = SendEmailRequestBuilder.Email();

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.Subject);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenSubjectProvided()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Subject("Subject");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.Subject);
    }

    #endregion



    #region Category

    [Test]
    public void Validation_ShouldFail_WhenCategoryExceedsAllowedLength()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Category(TestContext.CurrentContext.Random.GetString(256));

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.Category);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenCategoryFitsAllowedLength()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Category(TestContext.CurrentContext.Random.GetString(255));

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.Category);
    }

    #endregion



    #region Body

    [Test]
    public void Validation_ShouldFail_WhenBothHtmlAndTextBodyAreNull()
    {
        var request = SendEmailRequestBuilder.Email();

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.TextBody);
        result.ShouldHaveValidationErrorFor(r => r.HtmlBody);
    }

    [Test]
    public void Validation_ShouldFail_WhenBothHtmlAndTextBodyAreEmpty()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Text(string.Empty)
            .Html(string.Empty);

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.TextBody);
        result.ShouldHaveValidationErrorFor(r => r.HtmlBody);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenTextBodyIsNotEmpty()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Text("Text");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.TextBody);
        result.ShouldNotHaveValidationErrorFor(r => r.HtmlBody);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenHtmlBodyIsNotEmpty()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Html("<h1>Html</h1>");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.TextBody);
        result.ShouldNotHaveValidationErrorFor(r => r.HtmlBody);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenBothHtmlAndTextBodyAreNotEmpty()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .Text("Text")
            .Html("<h1>Html</h1>");

        var result = SendEmailRequestValidator.Instance.TestValidate(request);

        result.ShouldNotHaveValidationErrorFor(r => r.TextBody);
        result.ShouldNotHaveValidationErrorFor(r => r.HtmlBody);
    }

    #endregion
}
