namespace Mailtrap.UnitTests.Emails.Models;


[TestFixture]
internal sealed class EmailAddressValidatorTests
{
    [Test]
    public void Validation_Should_Fail_WhenProvidedEmailIsInvalid()
    {
        var recipient = new EmailAddress("abcdefg");

        var result = EmailAddressValidator.Instance.TestValidate(recipient);

        result.ShouldHaveValidationErrorFor(r => r.Email);
    }

    [Test]
    public void Validation_Should_Pass_WhenProvidedEmailIsValid()
    {
        var recipient = new EmailAddress("john.doe@domain.com");

        var result = EmailAddressValidator.Instance.TestValidate(recipient);

        result.ShouldNotHaveValidationErrorFor(r => r.Email);
    }

    [Test]
    public void Validation_Should_Pass_WhenDisplayNameIsEmpty()
    {
        var recipient = new EmailAddress("john.doe@domain.com");

        var result = EmailAddressValidator.Instance.TestValidate(recipient);

        result.ShouldNotHaveValidationErrorFor(r => r.DisplayName);
    }
}
