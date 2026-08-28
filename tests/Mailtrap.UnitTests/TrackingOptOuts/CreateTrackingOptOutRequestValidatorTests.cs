namespace Mailtrap.UnitTests.TrackingOptOuts;


[TestFixture]
internal sealed class CreateTrackingOptOutRequestValidatorTests
{
    private const long SendingDomainId = 4321;

    private static readonly CreateTrackingOptOutRequestValidator s_validator = CreateTrackingOptOutRequestValidator.Instance;


    [Test]
    public void WithRequiredFields_ShouldPass()
    {
        var result = s_validator.TestValidate(ValidRequest());

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Test]
    public void WithEmptyEmail_ShouldFail()
    {
        var request = ValidRequest() with { Email = string.Empty };

        var result = s_validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.Email);
    }

    [Test]
    public void WithNonPositiveDomainId_ShouldFail()
    {
        var request = ValidRequest() with { DomainId = 0 };

        var result = s_validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(r => r.DomainId);
    }


    private static CreateTrackingOptOutRequest ValidRequest() => new()
    {
        Email = "test@demomailtrap.co",
        DomainId = SendingDomainId
    };
}
