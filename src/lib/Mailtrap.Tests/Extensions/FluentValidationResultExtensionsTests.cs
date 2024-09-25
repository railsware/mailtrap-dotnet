// -----------------------------------------------------------------------
// <copyright file="FluentValidationResultExtensionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------



namespace Mailtrap.Tests.Extensions;


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
        var fluentValidatorResult = new FluentValidation.Results.ValidationResult(errors);

        var validationResult = fluentValidatorResult.ToMailtrapValidationResult();

        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().BeEquivalentTo(errors.Select(x => x.ToString()));

    }
}
