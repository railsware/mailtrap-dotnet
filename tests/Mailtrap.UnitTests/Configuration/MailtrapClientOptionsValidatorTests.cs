namespace Mailtrap.UnitTests.Configuration;


[TestFixture]
internal sealed class MailtrapClientOptionsValidatorTests
{
    [Test]
    public void Validation_ShouldFail_WhenAuthenticationIsNotInitialized()
    {
        var options = MailtrapClientOptions.Default;

        var result = MailtrapClientOptionsValidator.Instance.TestValidate(options);

        result.ShouldHaveValidationErrorFor(r => r.ApiToken);
    }
}
