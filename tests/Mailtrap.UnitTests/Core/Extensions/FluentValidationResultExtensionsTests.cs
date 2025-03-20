namespace Mailtrap.UnitTests.Core.Extensions;


[TestFixture]
internal sealed class FluentValidationResultExtensionsTests
{
    [Test]
    public void ToMailtrapValidationResult_ShouldThrowArgumentNullException_WhenResultIsNull()
    {
        var act = () => FluentValidationResultExtensions.ToMailtrapValidationResult(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ToMailtrapValidationResult_ShouldProperlyInitializeResultObject()
    {
        var errors = new List<ValidationFailure>
        {
            new("Error A", "Property A"),
            new("Error B", "Property B")
        };
        var fluentValidatorResult = new ValidationResult(errors);

        var validationResult = fluentValidatorResult.ToMailtrapValidationResult();

        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(errors.Select(x => x.ToString()));
    }
}
